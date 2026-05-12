USE UniConnectDB;
GO

INSERT INTO admins (admin_id, full_name, email, password_hash, role) VALUES
('ADM-001', 'Juan Santos',  'admin@lpu.edu.ph',     'admin123', 'ICT Admin'),
('ADM-002', 'Maria Reyes',  'registrar@lpu.edu.ph', 'admin123', 'Registrar'),
('ADM-003', 'Pedro Garcia', 'encoder@lpu.edu.ph',   'admin123', 'Encoder');

INSERT INTO students (student_id, full_name, email, password_hash, program, year_level, semester) VALUES
('2024-00001', 'Juan dela Cruz',   'juan.delacruz@lpu.edu.ph',   'student123', 'BS Computer Science',       2, '2nd Sem — AY 2025-2026'),
('2024-00002', 'Maria Clara',      'maria.clara@lpu.edu.ph',     'student123', 'BS Information Technology', 3, '2nd Sem — AY 2025-2026'),
('2024-00003', 'Padre Damaso',     'padre.damaso@lpu.edu.ph',    'student123', 'BS Computer Science',       2, '2nd Sem — AY 2025-2026'),
('2024-00004', 'Francisco Ibarra', 'francisco.ibarra@lpu.edu.ph','student123', 'BS Computer Science',       4, '2nd Sem — AY 2025-2026'),
('2024-00005', 'Elias Santos',     'elias.santos@lpu.edu.ph',    'student123', 'BS Information Technology', 1, '2nd Sem — AY 2025-2026');

INSERT INTO subjects (subject_code, subject_name, units, instructor) VALUES
('IT201', 'Object-Oriented Programming',      3, 'Prof. Reyes'),
('IT202', 'Data Structures and Algorithms',   3, 'Prof. Cruz'),
('IT203', 'Database Management Systems',      3, 'Prof. Santos'),
('IT204', 'Web Development',                  3, 'Prof. Mendoza'),
('IT205', 'Computer Networks',                3, 'Prof. Lopez'),
('IT301', 'Software Engineering',             3, 'Prof. Aquino'),
('IT104', 'Discrete Mathematics',             3, 'Prof. Bautista'),
('IT101', 'Introduction to Computing',        3, 'Prof. Aquino'),
('IT102', 'Programming Fundamentals',         3, 'Prof. Reyes'),
('IT103', 'Computer Organization',            3, 'Prof. Mendoza'),
('MATH101','College Algebra',                 3, 'Prof. Garcia'),
('ENG101', 'English Communication',           3, 'Prof. Lim'),
('GEN101', 'Understanding the Self',          3, 'Prof. Bautista'),
('GEN102', 'Readings in Philippine History',  3, 'Prof. Santos'),
('FIL101', 'Filipino sa Iba''t Ibang Disiplina', 3, 'Prof. Cruz'),
('PE102',  'Physical Education 2',            2, 'Prof. Lopez'),
('GEN103', 'Purposive Communication',         3, 'Prof. Lim'),
('GEN104', 'Mathematics in the Modern World', 3, 'Prof. Garcia'),
('PE101',  'Physical Education 1',            2, 'Prof. Lopez');

-- Current semester enrollments + grades for Juan
INSERT INTO enrollments (student_id, subject_code, semester) VALUES
('2024-00001', 'IT201', '2nd Sem — AY 2025-2026'),
('2024-00001', 'IT202', '2nd Sem — AY 2025-2026'),
('2024-00001', 'IT203', '2nd Sem — AY 2025-2026'),
('2024-00001', 'IT204', '2nd Sem — AY 2025-2026'),
('2024-00001', 'IT205', '2nd Sem — AY 2025-2026'),
('2024-00001', 'IT101',   '1st Sem — AY 2025-2026'),
('2024-00001', 'IT102',   '1st Sem — AY 2025-2026'),
('2024-00001', 'IT103',   '1st Sem — AY 2025-2026'),
('2024-00001', 'MATH101', '1st Sem — AY 2025-2026'),
('2024-00001', 'ENG101',  '1st Sem — AY 2025-2026'),
('2024-00001', 'GEN101', '2nd Sem — AY 2024-2025'),
('2024-00001', 'GEN102', '2nd Sem — AY 2024-2025'),
('2024-00001', 'FIL101', '2nd Sem — AY 2024-2025'),
('2024-00001', 'PE102',  '2nd Sem — AY 2024-2025'),
('2024-00001', 'GEN103', '1st Sem — AY 2024-2025'),
('2024-00001', 'GEN104', '1st Sem — AY 2024-2025'),
('2024-00001', 'PE101',  '1st Sem — AY 2024-2025');

INSERT INTO grades (student_id, subject_code, grade, status, semester, updated_by) VALUES
('2024-00001', 'IT201', 1.50, 'Passed', '2nd Sem — AY 2025-2026', 'ADM-001'),
('2024-00001', 'IT202', 1.75, 'Passed', '2nd Sem — AY 2025-2026', 'ADM-001'),
('2024-00001', 'IT203', 2.00, 'Passed', '2nd Sem — AY 2025-2026', 'ADM-003'),
('2024-00001', 'IT204', 1.25, 'Passed', '2nd Sem — AY 2025-2026', 'ADM-001'),
('2024-00001', 'IT205', 2.25, 'Passed', '2nd Sem — AY 2025-2026', 'ADM-003'),
('2024-00001', 'IT101',   1.25, 'Passed', '1st Sem — AY 2025-2026', 'ADM-001'),
('2024-00001', 'IT102',   1.50, 'Passed', '1st Sem — AY 2025-2026', 'ADM-001'),
('2024-00001', 'IT103',   1.75, 'Passed', '1st Sem — AY 2025-2026', 'ADM-003'),
('2024-00001', 'MATH101', 2.00, 'Passed', '1st Sem — AY 2025-2026', 'ADM-001'),
('2024-00001', 'ENG101',  1.50, 'Passed', '1st Sem — AY 2025-2026', 'ADM-001'),
('2024-00001', 'GEN101', 1.75, 'Passed', '2nd Sem — AY 2024-2025', 'ADM-001'),
('2024-00001', 'GEN102', 2.00, 'Passed', '2nd Sem — AY 2024-2025', 'ADM-001'),
('2024-00001', 'FIL101', 1.50, 'Passed', '2nd Sem — AY 2024-2025', 'ADM-003'),
('2024-00001', 'PE102',  1.25, 'Passed', '2nd Sem — AY 2024-2025', 'ADM-001'),
('2024-00001', 'GEN103', 1.75, 'Passed', '1st Sem — AY 2024-2025', 'ADM-001'),
('2024-00001', 'GEN104', 2.00, 'Passed', '1st Sem — AY 2024-2025', 'ADM-001'),
('2024-00001', 'PE101',  1.50, 'Passed', '1st Sem — AY 2024-2025', 'ADM-001');

INSERT INTO announcements (title, content, target_audience, posted_by) VALUES
('Synchronous Online Class',
 'In observance of the Holy Week, classes will transition to Synchronous Online Class on March 30-31, 2026. Classes and transactions will resume on April 6. Please coordinate with your respective department for more information.',
 'All', 'ADM-002'),
('Holy Week Advisory',
 'As we observe Holy Week, please take note of the important dates for classes and office transactions. Let this sacred season inspire deep reflection and meaningful connections. Classes and transactions resume on April 6.',
 'All', 'ADM-001'),
('Midterm Examination Schedule Now Available',
 'The final examination schedule for the 2nd Semester has been posted. Please check your respective schedule or contact your instructors.',
 'Students', 'ADM-002'),
('Tuition Payment Deadline — April 16',
 'Reminder: The last day to pay tuition without late payment penalty is April 16, 2026. Students with outstanding balances may not be allowed to take final exams.',
 'Students', 'ADM-002');

INSERT INTO audit_logs (action_type, table_affected, performed_by, details) VALUES
('Grade Updated',       'grades',        'ADM-001', 'Updated grade for 2024-00001 in IT201'),
('Announcement Posted', 'announcements', 'ADM-002', 'Posted: Synchronous Online Class'),
('Grade Updated',       'grades',        'ADM-003', 'Updated grade for 2024-00001 in IT203'),
('Announcement Posted', 'announcements', 'ADM-001', 'Posted: Holy Week Advisory'),
('Grade Updated',       'grades',        'ADM-001', 'Updated grade for 2024-00001 in IT204');