<?php
// Required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

include_once '../../config/database.php';

$database = new Database();
$db = $database->getConnection();

// Check if a student_id was provided
if (!isset($_GET['student_id'])) {
    http_response_code(400);
    die(json_encode(array("message" => "Missing student_id parameter.")));
}

$student_id = htmlspecialchars(strip_tags($_GET['student_id']));

// The exact SQL query from your C# app, translated for PHP PDO
$sql = "SELECT a.announcement_id, a.title, a.content, a.target_audience,
               ad.full_name AS posted_by_name, a.posted_at,
               CASE WHEN r.announcement_id IS NULL THEN 0 ELSE 1 END AS is_read
        FROM announcements a
        LEFT JOIN admins ad ON a.posted_by = ad.admin_id
        LEFT JOIN announcement_reads r
               ON r.announcement_id = a.announcement_id
              AND r.student_id = :student_id
        WHERE a.is_archived = 0
          AND (a.target_audience = 'All' OR a.target_audience = 'Students')
        ORDER BY a.posted_at DESC";

try {
    $stmt = $db->prepare($sql);
    $stmt->bindParam(":student_id", $student_id);
    $stmt->execute();
    
    $announcements_arr = array();
    $announcements_arr["records"] = array();
    $unread_count = 0;

    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        extract($row);
        
        $announcement_item = array(
            "announcement_id" => (int)$announcement_id,
            "title" => $title,
            "content" => $content,
            "target_audience" => $target_audience,
            "posted_by_name" => $posted_by_name,
            "posted_at" => $posted_at,
            "is_read" => (bool)$is_read
        );
        
        array_push($announcements_arr["records"], $announcement_item);
        
        // Tally up the unread announcements for the summary block
        if (!$is_read) {
            $unread_count++;
        }
    }
    
    // Add a summary block for quick dashboard stats
    $announcements_arr["summary"] = array(
        "unread_count" => $unread_count
    );

    http_response_code(200);
    echo json_encode($announcements_arr);

} catch(PDOException $e) {
    http_response_code(500);
    echo json_encode(array("message" => "Database error: " . $e->getMessage()));
}
?>