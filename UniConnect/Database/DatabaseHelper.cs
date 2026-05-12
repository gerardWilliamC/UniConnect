using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using UniConnect.Models;

namespace UniConnect.Database
{
    public class DatabaseHelper
    {
        // NOTE: Hardcoded for now. Will be moved to App.config in next phase.
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["UniConnectDB"].ConnectionString;

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public (bool success, string message) TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return (true, "Connected to UniConnectDB successfully.");
                }
            }
            catch (Exception ex)
            {
                return (false, "Connection failed: " + ex.Message);
            }
        }

        // =====================================================================
        // AUTHENTICATION
        // =====================================================================

        public Student ValidateStudent(string email, string password)
        {
            string sql = @"SELECT student_id, full_name, email, program, year_level, semester
                           FROM students
                           WHERE email = @Email AND password_hash = @Password";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                StudentId = reader["student_id"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Email = reader["email"].ToString(),
                                Program = reader["program"].ToString(),
                                YearLevel = Convert.ToInt32(reader["year_level"]),
                                Semester = reader["semester"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Admin ValidateAdmin(string email, string password)
        {
            string sql = @"SELECT admin_id, full_name, email, role
                           FROM admins
                           WHERE email = @Email AND password_hash = @Password";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Admin
                            {
                                AdminId = reader["admin_id"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Email = reader["email"].ToString(),
                                Role = reader["role"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // =====================================================================
        // STUDENT DASHBOARD QUERIES
        // =====================================================================

        public decimal? GetStudentGWA(string studentId, string semester)
        {
            string sql = @"
                SELECT SUM(g.grade * s.units) / NULLIF(SUM(s.units), 0) AS gwa
                FROM grades g
                INNER JOIN subjects s ON g.subject_code = s.subject_code
                WHERE g.student_id = @StudentId
                  AND g.semester   = @Semester
                  AND g.grade      IS NOT NULL
                  AND g.status     = 'Passed'";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@Semester", semester);

                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value) return null;
                    return Convert.ToDecimal(result);
                }
            }
        }

        public int GetEnrolledUnits(string studentId, string semester)
        {
            string sql = @"
                SELECT ISNULL(SUM(s.units), 0)
                FROM enrollments e
                INNER JOIN subjects s ON e.subject_code = s.subject_code
                WHERE e.student_id = @StudentId
                  AND e.semester   = @Semester";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@Semester", semester);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // =====================================================================
        // GRADES
        // =====================================================================

        public List<Grade> GetStudentGrades(string studentId, string semester = null)
        {
            string sql = @"
                SELECT g.grade_id, g.student_id, g.subject_code,
                       s.subject_name, s.units, s.instructor,
                       g.grade, g.status, g.semester, g.updated_by, g.updated_at
                FROM grades g
                INNER JOIN subjects s ON g.subject_code = s.subject_code
                WHERE g.student_id = @StudentId
                  AND (@Semester IS NULL OR g.semester = @Semester)
                ORDER BY s.subject_code";

            List<Grade> grades = new List<Grade>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@Semester",
                        (object)semester ?? DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grades.Add(new Grade
                            {
                                GradeId = Convert.ToInt32(reader["grade_id"]),
                                StudentId = reader["student_id"].ToString(),
                                SubjectCode = reader["subject_code"].ToString(),
                                SubjectName = reader["subject_name"].ToString(),
                                Units = Convert.ToInt32(reader["units"]),
                                Instructor = reader["instructor"].ToString(),
                                GradeValue = reader["grade"] == DBNull.Value
                                                ? (decimal?)null
                                                : Convert.ToDecimal(reader["grade"]),
                                Status = reader["status"].ToString(),
                                Semester = reader["semester"].ToString(),
                                UpdatedBy = reader["updated_by"]?.ToString(),
                                UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                            });
                        }
                    }
                }
            }
            return grades;
        }

        public (int totalUnits, int passedCount, int failedCount) GetGradesSummary(
            string studentId, string semester)
        {
            string sql = @"
                SELECT
                    ISNULL(SUM(s.units), 0) AS total_units,
                    SUM(CASE WHEN g.status = 'Passed' THEN 1 ELSE 0 END) AS passed_count,
                    SUM(CASE WHEN g.status = 'Failed' THEN 1 ELSE 0 END) AS failed_count
                FROM grades g
                INNER JOIN subjects s ON g.subject_code = s.subject_code
                WHERE g.student_id = @StudentId
                  AND g.semester   = @Semester";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@Semester", semester);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int totalUnits = reader["total_units"] == DBNull.Value ? 0 : Convert.ToInt32(reader["total_units"]);
                            int passedCount = reader["passed_count"] == DBNull.Value ? 0 : Convert.ToInt32(reader["passed_count"]);
                            int failedCount = reader["failed_count"] == DBNull.Value ? 0 : Convert.ToInt32(reader["failed_count"]);
                            return (totalUnits, passedCount, failedCount);
                        }
                    }
                }
            }
            return (0, 0, 0);
        }

        public (decimal? gwa, int totalUnits, int passedCount, int failedCount)
            GetOverallGradesSummary(string studentId)
        {
            string sql = @"
                SELECT
                    SUM(g.grade * s.units) / NULLIF(SUM(s.units), 0) AS gwa,
                    ISNULL(SUM(s.units), 0) AS total_units,
                    SUM(CASE WHEN g.status = 'Passed' THEN 1 ELSE 0 END) AS passed_count,
                    SUM(CASE WHEN g.status = 'Failed' THEN 1 ELSE 0 END) AS failed_count
                FROM grades g
                INNER JOIN subjects s ON g.subject_code = s.subject_code
                WHERE g.student_id = @StudentId
                  AND g.grade      IS NOT NULL
                  AND g.status     = 'Passed'";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal? gwa = reader["gwa"] == DBNull.Value
                                ? (decimal?)null : Convert.ToDecimal(reader["gwa"]);
                            int totalUnits = reader["total_units"] == DBNull.Value ? 0 : Convert.ToInt32(reader["total_units"]);
                            int passedCount = reader["passed_count"] == DBNull.Value ? 0 : Convert.ToInt32(reader["passed_count"]);
                            int failedCount = reader["failed_count"] == DBNull.Value ? 0 : Convert.ToInt32(reader["failed_count"]);
                            return (gwa, totalUnits, passedCount, failedCount);
                        }
                    }
                }
            }
            return (null, 0, 0, 0);
        }

        public List<string> GetStudentSemesters(string studentId)
        {
            string sql = @"
                SELECT DISTINCT semester
                FROM grades
                WHERE student_id = @StudentId";

            List<string> semesters = new List<string>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            semesters.Add(reader["semester"].ToString());
                    }
                }
            }

            // Smart sort: newer year first, then 2nd Sem before 1st Sem within same year
            semesters.Sort((a, b) =>
            {
                int yearA = ExtractStartYear(a);
                int yearB = ExtractStartYear(b);
                if (yearA != yearB) return yearB.CompareTo(yearA);

                bool aIs2nd = a.StartsWith("2nd");
                bool bIs2nd = b.StartsWith("2nd");
                if (aIs2nd && !bIs2nd) return -1;
                if (!aIs2nd && bIs2nd) return 1;
                return 0;
            });

            return semesters;
        }

        private int ExtractStartYear(string semester)
        {
            var match = System.Text.RegularExpressions.Regex.Match(semester, @"\d{4}");
            return match.Success ? int.Parse(match.Value) : 0;
        }

        // =====================================================================
        // ANNOUNCEMENTS
        // =====================================================================

        public List<Announcement> GetAnnouncements(
            string targetAudience = null,
            int limit = 50,
            string studentId = null)
        {
            string sql = @"
                SELECT TOP (@Limit)
                       a.announcement_id, a.title, a.content, a.target_audience,
                       a.posted_by, ad.full_name AS posted_by_name,
                       a.posted_at, a.is_archived,
                       CASE WHEN r.announcement_id IS NULL THEN 0 ELSE 1 END AS is_read
                FROM announcements a
                LEFT JOIN admins ad ON a.posted_by = ad.admin_id
                LEFT JOIN announcement_reads r
                       ON r.announcement_id = a.announcement_id
                      AND r.student_id      = @StudentId
                WHERE a.is_archived = 0
                  AND (@Audience IS NULL
                       OR a.target_audience = 'All'
                       OR a.target_audience = @Audience)
                ORDER BY a.posted_at DESC";

            List<Announcement> list = new List<Announcement>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Limit", limit);
                    cmd.Parameters.AddWithValue("@Audience",
                        (object)targetAudience ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StudentId",
                        (object)studentId ?? DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Announcement
                            {
                                AnnouncementId = Convert.ToInt32(reader["announcement_id"]),
                                Title = reader["title"].ToString(),
                                Content = reader["content"].ToString(),
                                TargetAudience = reader["target_audience"].ToString(),
                                PostedBy = reader["posted_by"]?.ToString(),
                                PostedByName = reader["posted_by_name"]?.ToString(),
                                PostedAt = Convert.ToDateTime(reader["posted_at"]),
                                IsArchived = Convert.ToBoolean(reader["is_archived"]),
                                IsRead = Convert.ToInt32(reader["is_read"]) == 1
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int GetUnreadAnnouncementCount(string studentId, string targetAudience = null)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM announcements a
                LEFT JOIN announcement_reads r
                       ON r.announcement_id = a.announcement_id
                      AND r.student_id      = @StudentId
                WHERE a.is_archived = 0
                  AND r.announcement_id IS NULL
                  AND (@Audience IS NULL
                       OR a.target_audience = 'All'
                       OR a.target_audience = @Audience)";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@Audience",
                        (object)targetAudience ?? DBNull.Value);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void MarkAnnouncementAsRead(string studentId, int announcementId)
        {
            string sql = @"
                IF NOT EXISTS (
                    SELECT 1 FROM announcement_reads
                    WHERE student_id = @StudentId
                      AND announcement_id = @AnnouncementId
                )
                INSERT INTO announcement_reads (student_id, announcement_id)
                VALUES (@StudentId, @AnnouncementId)";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@AnnouncementId", announcementId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =====================================================================
        // ADMIN DASHBOARD QUERIES
        // =====================================================================

        /// <summary>
        /// Returns the 4 top-line counts the admin dashboard shows:
        /// total students, total subjects, pending grades, non-archived announcements.
        /// All four pulled in one round-trip via UNION ALL.
        /// </summary>
        public (int totalStudents, int totalCourses, int pendingGrades, int announcements)
            GetAdminDashboardCounts()
        {
            string sql = @"
        SELECT
            (SELECT COUNT(*) FROM students)                                   AS total_students,
            (SELECT COUNT(*) FROM subjects)                                   AS total_courses,
            (SELECT COUNT(*) FROM grades
                WHERE grade IS NULL OR status = 'Pending')                    AS pending_grades,
            (SELECT COUNT(*) FROM announcements WHERE is_archived = 0)        AS announcement_count";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (
                            Convert.ToInt32(reader["total_students"]),
                            Convert.ToInt32(reader["total_courses"]),
                            Convert.ToInt32(reader["pending_grades"]),
                            Convert.ToInt32(reader["announcement_count"])
                        );
                    }
                }
            }
            return (0, 0, 0, 0);
        }

        /// <summary>
        /// Recent grade entries for the admin dashboard preview.
        /// Joins grades → students (for name) → subjects (for code/name) → admins (for editor name).
        /// </summary>
        public List<(string studentName, string studentId, string subjectCode,
                     string subjectName, decimal? grade, string status,
                     string editedBy, DateTime updatedAt)>
            GetRecentGradeEntries(int limit = 10)
        {
            string sql = @"
        SELECT TOP (@Limit)
               st.full_name        AS student_name,
               g.student_id,
               g.subject_code,
               s.subject_name,
               g.grade,
               g.status,
               ISNULL(ad.full_name, g.updated_by) AS edited_by,
               g.updated_at
        FROM grades g
        INNER JOIN students st ON g.student_id = st.student_id
        INNER JOIN subjects s  ON g.subject_code = s.subject_code
        LEFT JOIN  admins   ad ON g.updated_by  = ad.admin_id
        ORDER BY g.updated_at DESC";

            var rows = new List<(string, string, string, string, decimal?, string, string, DateTime)>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Limit", limit);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rows.Add((
                                reader["student_name"].ToString(),
                                reader["student_id"].ToString(),
                                reader["subject_code"].ToString(),
                                reader["subject_name"].ToString(),
                                reader["grade"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["grade"]),
                                reader["status"]?.ToString() ?? "",
                                reader["edited_by"]?.ToString() ?? "",
                                Convert.ToDateTime(reader["updated_at"])
                            ));
                        }
                    }
                }
            }
            return rows;
        }

        /// <summary>
        /// Recent audit log entries for the admin dashboard.
        /// Joins to admins to resolve performed_by → human-readable name.
        /// </summary>
        public List<AuditLog> GetRecentAuditLogs(int limit = 8)
        {
            string sql = @"
        SELECT TOP (@Limit)
               al.log_id, al.action_type, al.table_affected,
               al.performed_by,
               ISNULL(ad.full_name, al.performed_by) AS performed_by_name,
               al.details, al.timestamp
        FROM audit_logs al
        LEFT JOIN admins ad ON al.performed_by = ad.admin_id
        ORDER BY al.timestamp DESC";

            var list = new List<AuditLog>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Limit", limit);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new AuditLog
                            {
                                LogId = Convert.ToInt32(reader["log_id"]),
                                ActionType = reader["action_type"]?.ToString(),
                                TableAffected = reader["table_affected"]?.ToString(),
                                PerformedBy = reader["performed_by"]?.ToString(),
                                PerformedByName = reader["performed_by_name"]?.ToString(),
                                Details = reader["details"]?.ToString(),
                                Timestamp = Convert.ToDateTime(reader["timestamp"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        // =====================================================================
        // ENCODE GRADES — student lookup + grade update with audit
        // =====================================================================

        /// <summary>
        /// Finds a student by ID or partial name match. Returns null if not found.
        /// Used by the encoder's search box.
        /// </summary>
        public Student FindStudent(string query)
        {
            string sql = @"
        SELECT TOP 1 student_id, full_name, email, program, year_level, semester
        FROM students
        WHERE student_id = @Query
           OR full_name LIKE @Like
        ORDER BY student_id";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Query", query);
                    cmd.Parameters.AddWithValue("@Like", "%" + query + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                StudentId = reader["student_id"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Email = reader["email"].ToString(),
                                Program = reader["program"]?.ToString(),
                                YearLevel = reader["year_level"] == DBNull.Value ? 0 : Convert.ToInt32(reader["year_level"]),
                                Semester = reader["semester"]?.ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Updates a grade row AND inserts an audit log entry in a single transaction.
        /// Either both succeed or both roll back — no orphan logs, no silent grade changes.
        /// </summary>
        public void UpdateGradeWithAudit(
            string studentId,
            string subjectCode,
            decimal? newGrade,
            string newStatus,
            string semester,
            string adminId,
            string detailsForLog)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1) Update the grade row
                        string updateSql = @"
                    UPDATE grades
                    SET grade      = @Grade,
                        status     = @Status,
                        updated_by = @AdminId,
                        updated_at = GETDATE()
                    WHERE student_id   = @StudentId
                      AND subject_code = @SubjectCode
                      AND semester     = @Semester";

                        using (SqlCommand cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Grade",
                                (object)newGrade ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Status", newStatus);
                            cmd.Parameters.AddWithValue("@AdminId", adminId);
                            cmd.Parameters.AddWithValue("@StudentId", studentId);
                            cmd.Parameters.AddWithValue("@SubjectCode", subjectCode);
                            cmd.Parameters.AddWithValue("@Semester", semester);
                            cmd.ExecuteNonQuery();
                        }

                        // 2) Insert the audit log entry
                        string auditSql = @"
                    INSERT INTO audit_logs (action_type, table_affected, performed_by, details)
                    VALUES (@Action, 'grades', @AdminId, @Details)";

                        using (SqlCommand cmd = new SqlCommand(auditSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Action", "Grade Updated");
                            cmd.Parameters.AddWithValue("@AdminId", adminId);
                            cmd.Parameters.AddWithValue("@Details", detailsForLog);
                            cmd.ExecuteNonQuery();
                        }

                        // 3) Both succeeded → commit
                        tx.Commit();
                    }
                    catch
                    {
                        // Roll back BOTH operations on any failure
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Recent audit logs for grade-related actions only.
        /// Used by the encoder's "Recent Changes" sidebar.
        /// </summary>
        public List<AuditLog> GetRecentGradeAuditLogs(int limit = 8)
        {
            string sql = @"
        SELECT TOP (@Limit)
               al.log_id, al.action_type, al.table_affected,
               al.performed_by,
               ISNULL(ad.full_name, al.performed_by) AS performed_by_name,
               al.details, al.timestamp
        FROM audit_logs al
        LEFT JOIN admins ad ON al.performed_by = ad.admin_id
        WHERE al.action_type LIKE 'Grade%'
        ORDER BY al.timestamp DESC";

            var list = new List<AuditLog>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Limit", limit);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new AuditLog
                            {
                                LogId = Convert.ToInt32(reader["log_id"]),
                                ActionType = reader["action_type"]?.ToString(),
                                TableAffected = reader["table_affected"]?.ToString(),
                                PerformedBy = reader["performed_by"]?.ToString(),
                                PerformedByName = reader["performed_by_name"]?.ToString(),
                                Details = reader["details"]?.ToString(),
                                Timestamp = Convert.ToDateTime(reader["timestamp"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        // =====================================================================
        // POST ANNOUNCEMENT — insert + audit + archive
        // =====================================================================

        /// <summary>
        /// Inserts a new announcement AND a matching audit_log row in one transaction.
        /// Returns the new announcement_id on success.
        /// </summary>
        public int PostAnnouncementWithAudit(
            string title,
            string content,
            string targetAudience,
            string adminId)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1) Insert announcement, capture the new ID
                        string insertSql = @"
                    INSERT INTO announcements (title, content, target_audience, posted_by)
                    OUTPUT INSERTED.announcement_id
                    VALUES (@Title, @Content, @Audience, @AdminId)";

                        int newId;
                        using (SqlCommand cmd = new SqlCommand(insertSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Title", title);
                            cmd.Parameters.AddWithValue("@Content", content);
                            cmd.Parameters.AddWithValue("@Audience", targetAudience);
                            cmd.Parameters.AddWithValue("@AdminId", adminId);
                            newId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2) Insert audit log
                        string auditSql = @"
                    INSERT INTO audit_logs (action_type, table_affected, performed_by, details)
                    VALUES ('Announcement Posted', 'announcements', @AdminId, @Details)";

                        using (SqlCommand cmd = new SqlCommand(auditSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@AdminId", adminId);
                            cmd.Parameters.AddWithValue("@Details", "Posted: " + title);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return newId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Sets is_archived = 1 on an announcement (soft-delete) AND logs the action.
        /// </summary>
        public void ArchiveAnnouncementWithAudit(int announcementId, string adminId, string title)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string updateSql = @"
                    UPDATE announcements
                    SET is_archived = 1
                    WHERE announcement_id = @Id";

                        using (SqlCommand cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Id", announcementId);
                            cmd.ExecuteNonQuery();
                        }

                        string auditSql = @"
                    INSERT INTO audit_logs (action_type, table_affected, performed_by, details)
                    VALUES ('Announcement Archived', 'announcements', @AdminId, @Details)";

                        using (SqlCommand cmd = new SqlCommand(auditSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@AdminId", adminId);
                            cmd.Parameters.AddWithValue("@Details", "Archived: " + title);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Returns ALL announcements (including archived) — for the admin's "Posted Announcements" panel.
        /// Includes the posted_by_name and is_archived state.
        /// </summary>
        public List<Announcement> GetAllAnnouncementsForAdmin(int limit = 50)
        {
            string sql = @"
        SELECT TOP (@Limit)
               a.announcement_id, a.title, a.content, a.target_audience,
               a.posted_by, ad.full_name AS posted_by_name,
               a.posted_at, a.is_archived
        FROM announcements a
        LEFT JOIN admins ad ON a.posted_by = ad.admin_id
        ORDER BY a.posted_at DESC";

            var list = new List<Announcement>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Limit", limit);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Announcement
                            {
                                AnnouncementId = Convert.ToInt32(reader["announcement_id"]),
                                Title = reader["title"].ToString(),
                                Content = reader["content"].ToString(),
                                TargetAudience = reader["target_audience"].ToString(),
                                PostedBy = reader["posted_by"]?.ToString(),
                                PostedByName = reader["posted_by_name"]?.ToString(),
                                PostedAt = Convert.ToDateTime(reader["posted_at"]),
                                IsArchived = Convert.ToBoolean(reader["is_archived"])
                            });
                        }
                    }
                }
            }
            return list;
        }

    }
}