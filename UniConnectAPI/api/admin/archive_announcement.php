<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
include_once '../../config/database.php';

$database = new Database();
$db = $database->getConnection();
$data = json_decode(file_get_contents("php://input"));

if(!empty($data->announcement_id) && !empty($data->admin_id) && !empty($data->title)) {
    try {
        $db->beginTransaction();

        $upd = "UPDATE announcements SET is_archived = 1 WHERE announcement_id = :id";
        $stmt = $db->prepare($upd);
        $stmt->bindParam(":id", $data->announcement_id);
        $stmt->execute();

        $aud = "INSERT INTO audit_logs (action_type, table_affected, performed_by, details) 
                VALUES ('Announcement Archived', 'announcements', :admin, :det)";
        $stmt2 = $db->prepare($aud);
        $det = "Archived: " . htmlspecialchars(strip_tags($data->title));
        $stmt2->bindParam(":admin", $data->admin_id);
        $stmt2->bindParam(":det", $det);
        $stmt2->execute();

        $db->commit();
        http_response_code(200);
        echo json_encode(array("message" => "Announcement archived."));
    } catch(Exception $e) {
        $db->rollBack();
        http_response_code(500);
        echo json_encode(array("message" => "Transaction failed."));
    }
} else {
    http_response_code(400);
    echo json_encode(array("message" => "Incomplete data."));
}
?>