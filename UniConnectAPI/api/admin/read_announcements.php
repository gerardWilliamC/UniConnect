<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../../config/database.php';

$database = new Database();
$db = $database->getConnection();

$sql = "SELECT a.announcement_id, a.title, a.content, a.target_audience,
               a.posted_by, ad.full_name AS posted_by_name,
               a.posted_at, a.is_archived
        FROM announcements a
        LEFT JOIN admins ad ON a.posted_by = ad.admin_id
        ORDER BY a.posted_at DESC";

try {
    $stmt = $db->prepare($sql);
    $stmt->execute();
    
    $records = array();
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        // Convert to boolean for easier JS handling
        $row['is_archived'] = $row['is_archived'] == 1 ? true : false;
        array_push($records, $row);
    }
    
    http_response_code(200);
    echo json_encode(array("records" => $records));
} catch(PDOException $e) {
    http_response_code(500);
    echo json_encode(array("message" => "Database error: " . $e->getMessage()));
}
?>