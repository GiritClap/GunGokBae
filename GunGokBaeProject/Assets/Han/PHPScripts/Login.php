<?php
// unity로부터 사용자 입력 받기
$user = $_POST['Input_user']; // 사용자 이름 받기
$pass = $_POST['Input_pass']; // 사용자 비밀번호 받기
$servername = "localhost";
$username = "root";
$password = "";
// Create connection
$conn = new mysqli($servername, $username, $password, "userinterface"); // 데이터베이스 연결


// 데이터베이스 연결 실패 시 에러 메시지 출력
if ($conn->connect_error) {
    die("Cannot connect: " . $conn->connect_error); // 데이터베이스 연결 실패 메시지 출력
}else{
    echo "Success to connect to database!  \n"; // 데이터베이스 연결 성공 메시지 출력
}


// 사용자 입력을 사용하여 데이터베이스 조회를 위한 준비된 명령문 생성
$sql = "SELECT * FROM account WHERE user = '".$user."'"; // 사용자 이름을 이용하여 데이터베이스 조회
$result = $conn->query($sql); // 데이터베이스 조회 결과를 변수에 저장

if($result->num_rows > 0){ // 데이터베이스 조회 결과가 0보다 크면
    while($row = $result->fetch_assoc()){ // 데이터베이스 조회 결과를 배열로 저장
        if($pass == $row['pass']){ // 사용자 비밀번호와 데이터베이스 비밀번호가 일치하면
            echo("'". $row['info']. "'  \n");   // 사용자 정보 출력
            die("Login successful!!"); // 로그인 성공 메시지 출력
        }else{
            die("Incorrect password!  \n"); // 비밀번호가 일치하지 않을 경우 에러 메시지 출력
        }
    }
}else{
    die("Incorrect username!"); // 사용자 이름이 일치하지 않을 경우 에러 메시지 출력
}
// 명령문 종료
$stmt->close(); 
// 데이터베이스 연결 종료
$conn->close();
?>