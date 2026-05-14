<?php
// Required headers for a POST request
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

include_once '../../config/database.php';

$database = new Database();
$db = $database->getConnection();

$data = json_decode(file_get_contents("php://input"));

// Ensure all required fields are provided
if (!empty($data->student_id) && !empty($data->subject_code) && !empty($data->semester) && isset($data->new_grade) && !empty($data->admin_id)) {

    try {
        // 🛑 START TRANSACTION
        $db->beginTransaction();

        // 1. UPDATE THE GRADE
        $updateSql = "UPDATE grades 
                      SET grade = :grade, status = :status, updated_by = :admin_id, updated_at = GETDATE()
                      WHERE student_id = :student_id AND subject_code = :subject_code AND semester = :semester";
        
        $stmt = $db->prepare($updateSql);

        // Calculate Philippine grading scale status
        $new_status = ($data->new_grade <= 3.00) ? 'Passed' : 'Failed';

        // Bind parameters
        $stmt->bindParam(":grade", $data->new_grade);
        $stmt->bindParam(":status", $new_status);
        $stmt->bindParam(":admin_id", $data->admin_id);
        $stmt->bindParam(":student_id", $data->student_id);
        $stmt->bindParam(":subject_code", $data->subject_code);
        $stmt->bindParam(":semester", $data->semester);

        $stmt->execute();

        // 2. INSERT INTO AUDIT LOGS
        $auditSql = "INSERT INTO audit_logs (action_type, table_affected, performed_by, details) 
                     VALUES ('Grade Updated', 'grades', :admin_id, :details)";
        
        $auditStmt = $db->prepare($auditSql);
        
        // Build the log message
        $details = "Updated " . $data->subject_code . " for " . $data->student_id . " to " . $data->new_grade . " (" . $new_status . ")";
        
        $auditStmt->bindParam(":admin_id", $data->admin_id);
        $auditStmt->bindParam(":details", $details);
        $auditStmt->execute();

        // ✅ COMMIT TRANSACTION (Save both successfully)
        $db->commit();

        http_response_code(200);
        echo json_encode(array(
            "message" => "Grade updated successfully.",
            "audit_log" => $details
        ));

    } catch (Exception $e) {
        // ❌ ROLLBACK TRANSACTION (Undo everything if either fails)
        $db->rollBack();
        http_response_code(500);
        echo json_encode(array("message" => "Transaction failed: " . $e->getMessage()));
    }
} else {
    // Missing inputs
    http_response_code(400);
    echo json_encode(array("message" => "Incomplete data. Cannot update grade."));
}
?>