<?php
class Database {
    // Database credentials
    private $serverName = "localhost\SQLEXPRESS";
    private $database = "UniConnectDB";
    public $conn;

    // Get the database connection
    public function getConnection() {
        $this->conn = null;

        try {
            $this->conn = new PDO("sqlsrv:server=" . $this->serverName . ";Database=" . $this->database);
            $this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        } catch(PDOException $e) {
            echo "Connection error: " . $e->getMessage();
        }

        return $this->conn;
    }
}
?>