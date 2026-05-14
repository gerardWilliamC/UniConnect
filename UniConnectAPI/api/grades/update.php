<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

include_once '../../config/database.php';

$database = new Database();
$db = $database->getConnection();

$data = json_decode(file_get_contents("php://input"));

// We changed isset() to property_exists() so it accepts 'null'
if (!empty($data->student_id) && !empty($data->subject_code) && !empty($data->semester) && !empty($data->admin_id) && property_exists($data, 'new_grade')) {

    try {
        $db->beginTransaction();

        $updateSql = "UPDATE grades 
                      SET grade = :grade, status = :status, updated_by = :admin_id, updated_at = GETDATE()
                      WHERE student_id = :student_id AND subject_code = :subject_code AND semester = :semester";
        
        $stmt = $db->prepare($updateSql);

        // Check if we are removing the grade
        if ($data->new_grade === null || $data->new_grade === "") {
            $new_status = 'Pending';
            $stmt->bindValue(":grade", null, PDO::PARAM_NULL);
            
            // Format log perfectly for our Javascript Regex: "Updated IT201 for 2024-00001 to Pending"
            $details = "Updated " . $data->subject_code . " for " . $data->student_id . " to Pending";
        } else {
            $grade_val = (float)$data->new_grade;
            $new_status = ($grade_val <= 3.00) ? 'Passed' : 'Failed';
            $stmt->bindValue(":grade", $grade_val);
            
            $details = "Updated " . $data->subject_code . " for " . $data->student_id . " to " . number_format($grade_val, 2) . " (" . $new_status . ")";
        }

        $stmt->bindValue(":status", $new_status);
        $stmt->bindValue(":admin_id", $data->admin_id);
        $stmt->bindValue(":student_id", $data->student_id);
        $stmt->bindValue(":subject_code", $data->subject_code);
        $stmt->bindValue(":semester", $data->semester);

        $stmt->execute();

        $auditSql = "INSERT INTO audit_logs (action_type, table_affected, performed_by, details) 
                     VALUES ('Grade Updated', 'grades', :admin_id, :details)";
        
        $auditStmt = $db->prepare($auditSql);
        $auditStmt->bindValue(":admin_id", $data->admin_id);
        $auditStmt->bindValue(":details", $details);
        $auditStmt->execute();

        $db->commit();

        http_response_code(200);
        echo json_encode(array(
            "message" => "Grade updated successfully.",
            "audit_log" => $details
        ));

    } catch (Exception $e) {
        $db->rollBack();
        http_response_code(500);
        echo json_encode(array("message" => "Transaction failed: " . $e->getMessage()));
    }
} else {
    http_response_code(400);
    echo json_encode(array("message" => "Incomplete data. Cannot update grade."));
}
?>