<?php
// Required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

include_once '../../config/database.php';

$database = new Database();
$db = $database->getConnection();

$data = json_decode(file_get_contents("php://input"));

if (!empty($data->email) && !empty($data->password)) {
    
    $sql = "SELECT student_id, full_name, email, program, year_level, semester 
            FROM students 
            WHERE email = :email AND password_hash = :password";
    
    $stmt = $db->prepare($sql);
    
    $email = htmlspecialchars(strip_tags($data->email));
    $password = htmlspecialchars(strip_tags($data->password));
    
    $stmt->bindParam(":email", $email);
    $stmt->bindParam(":password", $password);
    
    $stmt->execute();
    
    // THE FIX: Try to grab the row directly. If it has data, login succeeds!
    $row = $stmt->fetch(PDO::FETCH_ASSOC);
    
    if ($row) {
        // 200 OK
        http_response_code(200);
        echo json_encode(array(
            "message" => "Login successful.",
            "user" => $row
        ));
    } else {
        // 401 Unauthorized
        http_response_code(401);
        echo json_encode(array("message" => "Invalid email or password."));
    }
} else {
    // 400 Bad Request
    http_response_code(400);
    echo json_encode(array("message" => "Incomplete data. Email and password are required."));
}
?>