<?php
// Required headers for a GET request
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

// Include database config
include_once '../../config/database.php';

$database = new Database();
$db = $database->getConnection();

// Check if a student_id was provided in the URL
if (!isset($_GET['student_id'])) {
    http_response_code(400);
    die(json_encode(array("message" => "Missing student_id parameter.")));
}

$student_id = $_GET['student_id'];

// The SQL query joining grades and subjects
$sql = "SELECT g.grade_id, g.student_id, g.subject_code,
               s.subject_name, s.units, s.instructor,
               g.grade, g.status, g.semester, g.updated_at
        FROM grades g
        INNER JOIN subjects s ON g.subject_code = s.subject_code
        WHERE g.student_id = :student_id
        ORDER BY g.semester DESC, s.subject_code ASC";

try {
    $stmt = $db->prepare($sql);
    
    // Sanitize and bind
    $student_id = htmlspecialchars(strip_tags($student_id));
    $stmt->bindParam(":student_id", $student_id);
    
    $stmt->execute();
    
    $grades_arr = array();
    $grades_arr["records"] = array();
    $grades_arr["summary"] = array(
        "total_units" => 0,
        "subjects_passed" => 0,
        "subjects_failed" => 0
    );

    // Loop through the results
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        extract($row);
        
        $grade_item = array(
            "subject_code" => $subject_code,
            "subject_name" => $subject_name,
            "units" => (int)$units,
            "instructor" => $instructor,
            "grade" => $grade != null ? (float)$grade : null,
            "status" => $status,
            "semester" => $semester,
            "updated_at" => $updated_at // <-- FIX: This was missing!
        );
        
        array_push($grades_arr["records"], $grade_item);
        
        // Build a quick summary while we loop
        $grades_arr["summary"]["total_units"] += (int)$units;
        if ($status == 'Passed') $grades_arr["summary"]["subjects_passed"]++;
        if ($status == 'Failed') $grades_arr["summary"]["subjects_failed"]++;
    }

    if (count($grades_arr["records"]) > 0) {
        http_response_code(200);
        echo json_encode($grades_arr);
    } else {
        http_response_code(404);
        echo json_encode(array("message" => "No grades found for this student."));
    }

} catch(PDOException $e) {
    http_response_code(500);
    echo json_encode(array("message" => "Database error: " . $e->getMessage()));
}
?>