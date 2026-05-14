<?php
// Required headers for a REST API
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

// Go up two folders (../../) to find the config file
include_once '../../config/database.php';

// Initialize the database connection
$database = new Database();
$db = $database->getConnection();

// The exact SQL query (matching your C# DatabaseHelper)
$sql = "SELECT student_id, full_name, email, program, year_level, semester FROM students";

try {
    // Prepare and execute the query
    $stmt = $db->prepare($sql);
    $stmt->execute();

    // Create an array to hold our JSON response
    $students_arr = array();
    $students_arr["records"] = array();

    // Loop through the database results row by row
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        
        // This extracts the row array keys into actual PHP variables 
        // (e.g., $row['student_id'] becomes $student_id)
        extract($row);

        $student_item = array(
            "student_id" => $student_id,
            "full_name" => $full_name,
            "email" => $email,
            "program" => $program,
            "year_level" => $year_level,
            "semester" => $semester
        );

        // Push this student into our main records array
        array_push($students_arr["records"], $student_item);
    }

    // Send a 200 OK HTTP status code and the JSON data
    http_response_code(200);
    echo json_encode($students_arr);

} catch(PDOException $e) {
    // If something goes wrong, return a 500 Error
    http_response_code(500);
    echo json_encode(array("message" => "Database query failed: " . $e->getMessage()));
}
?>