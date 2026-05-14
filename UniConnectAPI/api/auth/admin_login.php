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
    
    // Using your exact schema from 02_create_tables.sql
    $sql = "SELECT admin_id, full_name, email, role 
            FROM admins 
            WHERE email = :email AND password_hash = :password";
    
    $stmt = $db->prepare($sql);
    
    $email = htmlspecialchars(strip_tags($data->email));
    $password = htmlspecialchars(strip_tags($data->password));
    
    $stmt->bindParam(":email", $email);
    $stmt->bindParam(":password", $password);
    
    $stmt->execute();
    
    $row = $stmt->fetch(PDO::FETCH_ASSOC);
    
    if ($row) {
        $admin_arr = array(
            "admin_id" => $row['admin_id'],
            "name" => $row['full_name'],
            "email" => $row['email'],
            "role" => $row['role']
        );
        
        http_response_code(200);
        echo json_encode(array(
            "message" => "Login successful.",
            "admin" => $admin_arr
        ));
    } else {
        http_response_code(401);
        echo json_encode(array("message" => "Invalid email or password."));
    }
} else {
    http_response_code(400);
    echo json_encode(array("message" => "Incomplete data."));
}
?>