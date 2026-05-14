<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../../config/database.php';

$database = new Database();
$db = $database->getConnection();
$response = array();

try {
    $statsSql = "SELECT
        (SELECT COUNT(*) FROM students) AS total_students,
        (SELECT COUNT(*) FROM subjects) AS total_courses,
        (SELECT COUNT(*) FROM grades WHERE grade IS NULL OR status = 'Pending') AS pending_grades,
        (SELECT COUNT(*) FROM announcements WHERE is_archived = 0) AS announcement_count";
    
    $stmtStats = $db->prepare($statsSql);
    $stmtStats->execute();
    $response['stats'] = $stmtStats->fetch(PDO::FETCH_ASSOC);

    $gradesSql = "SELECT TOP 5
           st.full_name AS student_name, s.subject_name, g.subject_code, g.grade, g.status,
           ISNULL(ad.full_name, g.updated_by) AS edited_by, g.updated_at
    FROM grades g
    INNER JOIN students st ON g.student_id = st.student_id
    INNER JOIN subjects s  ON g.subject_code = s.subject_code
    LEFT JOIN admins ad ON g.updated_by = ad.admin_id
    ORDER BY g.updated_at DESC";
    
    $stmtGrades = $db->prepare($gradesSql);
    $stmtGrades->execute();
    $response['recent_grades'] = $stmtGrades->fetchAll(PDO::FETCH_ASSOC);

    $auditSql = "SELECT TOP 5
           al.action_type, al.table_affected, ISNULL(ad.full_name, al.performed_by) AS performed_by_name,
           al.details, al.timestamp
    FROM audit_logs al
    LEFT JOIN admins ad ON al.performed_by = ad.admin_id
    ORDER BY al.timestamp DESC";
    
    $stmtAudit = $db->prepare($auditSql);
    $stmtAudit->execute();
    $response['audit_logs'] = $stmtAudit->fetchAll(PDO::FETCH_ASSOC);

    http_response_code(200);
    echo json_encode($response);

} catch (Exception $e) {
    http_response_code(500);
    echo json_encode(array("message" => "Database error: " . $e->getMessage()));
}
?>