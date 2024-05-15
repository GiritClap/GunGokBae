<?php
// HTTP POST 요청의 본문에서 JSON 데이터를 가져옵니다.
$json = file_get_contents('php://input');
// JSON 데이터를 PHP 배열로 변환합니다.
$data = json_decode($json, true);

// unity로부터 사용자 입력 받기
$servername = "localhost";
$username = "root";
$password = "";
$database = $data['RoomName'] . "_" . $data['masterID']; // 데이터베이스 이름 설정

// Create connection
$conn = new mysqli($servername, $username, $password, $database); // 데이터베이스 연결

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

// 테이블 생성 함수
function createTable($conn, $tableName, $fields) {
    // 테이블이 존재하는지 확인하고, 없다면 생성
    if ($conn->query("SHOW TABLES LIKE '{$tableName}'")->num_rows == 0) {
        $sql = "CREATE TABLE {$tableName} ({$fields})";
        if ($conn->query($sql) === FALSE) {
            echo "Error creating table: " . $conn->error;
        }
    }
}

// 테이블 생성
createTable($conn, "PrograssInfo", "
    id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    RoomName VARCHAR(30) NOT NULL,
    masterID VARCHAR(15) NOT NULL,
    sceneName VARCHAR(30) NOT NULL
");
//여기는 배열로 들어오느 애들 player정보
createTable($conn, "PlayersInfo", "
    id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    playerIdArray VARCHAR(45) NOT NULL,
    playerNickNameArray VARCHAR(45) NOT NULL,
    playerPositionArray VARCHAR(450) NOT NULL,
    playerRotationArray VARCHAR(450) NOT NULL,
    playerCurHp INT(6) NOT NULL,
    playerMaxHp INT(6) NOT NULL,
    currentWeapon INT(6) NOT NULL,
    cur_Bullet_Cnt FLOAT NOT NULL,
    max_Bullet_Cnt FLOAT NOT NULL,
    damage FLOAT NOT NULL
");

createTable($conn, "BagInfo", "
    id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    stone FLOAT NOT NULL,
    stone2 FLOAT NOT NULL,
    stone3 FLOAT NOT NULL,
    stone4 FLOAT NOT NULL,
    stone5 FLOAT NOT NULL,
    gun BOOLEAN NOT NULL,
    gun2 BOOLEAN NOT NULL,
    gun3 BOOLEAN NOT NULL,
    gun4 BOOLEAN NOT NULL,
    gun5 BOOLEAN NOT NULL
");

// 데이터 저장
function insertData($conn, $tableName, $fields, $values) {
    $stmt = $conn->prepare("INSERT INTO {$tableName} ({$fields}) VALUES ({$values})");
    $stmt->execute();
}

// 데이터 저장
insertData($conn, "PrograssInfo", "RoomName, masterID, sceneName", "'".$data['RoomName']."', '".$data['masterID']."', '".$data['sceneName']."'");

insertData(($conn, "PlayersInfo",
"playerIdArray, playerNickNameArray, playerPositionArray, playerRotationArray, playerCurHp, playerMaxHp, currentWeapon, cur_Bullet_Cnt, max_Bullet_Cnt, damage",
"'".$data['playerIdArray']."', '".$data['playerNickNameArray'] . "', '".$data['playerPositionArray'] . "', '".$data['playerRotationArray'] . "', ".$data['playerCurHp'] . ", ".$data['playerMaxHp'] . ", ".$data['currentWeapon'] . ", ".$data['cur_Bullet_Cnt'] . ", ".$data['max_Bullet_Cnt'] . ", ".$data['damage'])

insertData($conn, "BagInfo", "stone, stone2, stone3, stone4, stone5, gun, gun2, gun3, gun4, gun5", $data['stone'].", ".$data['stone2'].", ".$data['stone3'].", ".$data['stone4'].", ".$data['stone5'].", ".$data['gun'].", ".$data['gun2'].", ".$data['gun3'].", ".$data['gun4'].", ".$data['gun5']);

echo "New records created successfully";
$conn->close();
?>