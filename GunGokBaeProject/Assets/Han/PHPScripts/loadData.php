<?php
// 클라이언트로부터 받은 데이터
$masterID = $_POST['masterID'];
$roomName = $_POST['roomName'];

$servername = "localhost";
$username = "root";
$password = "";
$dbname = $_POST['RoomName'] . "_" . $_POST['masterID'];
// 데이터베이스 연결
$conn = new mysqli($servername, $username, $password, $dbname);

// 연결 확인
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
$sql0 = "SELECT * FROM PrograssInfo";
$sql1 = "SELECT * FROM PlayersInfo";
$sql2 = "SELECT * FROM BagInfo";

$result0 = $conn->query($sql0);
$result1 = $conn->query($sql1);
$result2 = $conn->query($sql2);


if ($result0->num_rows > 0 && $result1->num_rows > 0 && $result2->num_rows > 0) {
    $row0 = $result0->fetch_assoc();
    $row1 = $result1->fetch_assoc();
    $row2 = $result2->fetch_assoc();

    $saveData = array(
        "RoomName" => $row0['RoomName'],
        "masterID" => $row0['masterID'],
        "sceneName" => $row0['sceneName'],
        "playerIdArray" => explode(",", $row1['playerIdArray']),
        "playerNickNameArray" => explode(",", $row1['playerNickNameArray']),
        "playerPositionArray" => explode(",", $row1['playerPositionArray']),
        "playerRotationArray" => explode(",", $row1['playerRotationArray']),
        "playerCurHp" => explode(",", $row1['playerCurHp']),
        "playerMaxHp" => explode(",", $row1['playerMaxHp']),
        "stone" => $row2['stone'],
        "stone2" => $row2['stone2'],
        "stone3" => $row2['stone3'],
        "stone4" => $row2['stone4'],
        "stone5" => $row2['stone5'],
        "gun" => $row2['gun'],
        "gun2" => $row2['gun2'],
        "gun3" => $row2['gun3'],
        "gun4" => $row2['gun4'],
        "gun5" => $row2['gun5'],
        "currentWeapon" => explode(",", $row1['currentWeapon']),
        "cur_Bullet_Cnt" => explode(",", $row1['cur_Bullet_Cnt']),
        "max_Bullet_Cnt" => explode(",", $row1['max_Bullet_Cnt']),
        "damage" => explode(",", $row1['damage'])
    );

    echo json_encode($saveData);
} else {
    echo "No results";
}


$conn->close();

?>