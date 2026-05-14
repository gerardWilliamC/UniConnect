USE UniConnectDB;
GO

CREATE TABLE students (
    student_id      VARCHAR(20) PRIMARY KEY,
    full_name       NVARCHAR(150) NOT NULL,
    email           NVARCHAR(150) NOT NULL UNIQUE,
    password_hash   NVARCHAR(255) NOT NULL,
    program         NVARCHAR(100),
    year_level      INT,
    semester        NVARCHAR(50),
    created_at      DATETIME DEFAULT GETDATE()
);

CREATE TABLE admins (
    admin_id        VARCHAR(20) PRIMARY KEY,
    full_name       NVARCHAR(150) NOT NULL,
    email           NVARCHAR(150) NOT NULL UNIQUE,
    password_hash   NVARCHAR(255) NOT NULL,
    role            NVARCHAR(50),
    created_at      DATETIME DEFAULT GETDATE()
);

CREATE TABLE subjects (
    subject_code    VARCHAR(20) PRIMARY KEY,
    subject_name    NVARCHAR(150) NOT NULL,
    units           INT NOT NULL,
    instructor      NVARCHAR(150)
);

CREATE TABLE enrollments (
    enrollment_id   INT PRIMARY KEY IDENTITY(1,1),
    student_id      VARCHAR(20) NOT NULL,
    subject_code    VARCHAR(20) NOT NULL,
    semester        NVARCHAR(50),
    enrolled_at     DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (student_id)   REFERENCES students(student_id),
    FOREIGN KEY (subject_code) REFERENCES subjects(subject_code)
);

CREATE TABLE grades (
    grade_id        INT PRIMARY KEY IDENTITY(1,1),
    student_id      VARCHAR(20) NOT NULL,
    subject_code    VARCHAR(20) NOT NULL,
    grade           DECIMAL(3,2),
    status          NVARCHAR(20),
    semester        NVARCHAR(50),
    updated_by      VARCHAR(20),
    updated_at      DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (student_id)   REFERENCES students(student_id),
    FOREIGN KEY (subject_code) REFERENCES subjects(subject_code)
);

CREATE TABLE announcements (
    announcement_id INT PRIMARY KEY IDENTITY(1,1),
    title           NVARCHAR(200) NOT NULL,
    content         NVARCHAR(MAX),
    target_audience NVARCHAR(50),
    posted_by       VARCHAR(20),
    posted_at       DATETIME DEFAULT GETDATE(),
    is_archived     BIT DEFAULT 0,
    FOREIGN KEY (posted_by) REFERENCES admins(admin_id)
);

CREATE TABLE audit_logs (
    log_id          INT PRIMARY KEY IDENTITY(1,1),
    action_type     NVARCHAR(100),
    table_affected  NVARCHAR(50),
    performed_by    VARCHAR(20),
    details         NVARCHAR(500),
    timestamp       DATETIME DEFAULT GETDATE()
);

CREATE TABLE announcement_reads (
    student_id        VARCHAR(20)  NOT NULL,
    announcement_id   INT          NOT NULL,
    read_at           DATETIME     DEFAULT GETDATE(),
    PRIMARY KEY (student_id, announcement_id),
    FOREIGN KEY (student_id)      REFERENCES students(student_id),
    FOREIGN KEY (announcement_id) REFERENCES announcements(announcement_id)
);