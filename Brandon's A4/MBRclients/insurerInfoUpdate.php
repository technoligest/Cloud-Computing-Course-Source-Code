<html>
<body>

<?php
$conn = mysqli_connect('csci4145assignment4.cj5svtw0lzw5.ca-central-1.rds.amazonaws.com', 'admin', 'adminpass', 'MBRDatabase', 3306);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
  $data = json_decode(file_get_contents("php://input"));
  print_r($data);
}

$brokerID = $data->brokerID;
$insurerID = $data->insurerID;

$result = $conn->query("SELECT tableID FROM MBRclients WHERE clientID = $brokerID");
if($result->num_rows != 0) {
    $sql = "UPDATE MBRclients SET insurerInfo='$insurerID' WHERE clientID = $brokerID";

	if ($conn->query($sql) === TRUE) {
		//echo "Record updated successfully";
	} else {
		echo "Error updating record: " . $conn->error;
	}
}
	
$conn->close();
?>

</body>
</html>