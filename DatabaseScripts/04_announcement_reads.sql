USE UniConnectDB;
GO

-- =====================================================
-- ANNOUNCEMENT READS TABLE
-- Tracks which announcements each student has marked as read.
-- =====================================================
CREATE TABLE announcement_reads (
    student_id        VARCHAR(20)  NOT NULL,
    announcement_id   INT          NOT NULL,
    read_at           DATETIME     DEFAULT GETDATE(),
    PRIMARY KEY (student_id, announcement_id),
    FOREIGN KEY (student_id)      REFERENCES students(student_id),
    FOREIGN KEY (announcement_id) REFERENCES announcements(announcement_id)
);

PRINT 'announcement_reads table created.';