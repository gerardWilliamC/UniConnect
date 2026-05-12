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
    }
}