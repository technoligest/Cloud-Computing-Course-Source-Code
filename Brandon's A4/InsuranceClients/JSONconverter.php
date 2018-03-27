<html>
<head>
<title>Data Submission</title>
</head>
<body>
<?php 
// Create connection
$conn = mysqli_connect('csci4145assignment4.cj5svtw0lzw5.ca-central-1.rds.amazonaws.com', 'admin', 'adminpass', 'MBRDatabase', 3306);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
else{
	//echo "Connected successfully<br>";
}

$myObj->brokerID = $_POST['brokerID'];
$myObj->insurerID = $_POST['clientID'];

$myJSON = json_encode($myObj);

echo $myJSON;
?>
<p id="function"></p>
<script>
function postJSON() {
  var xhttp = new XMLHttpRequest();
  xhttp.open("POST", "https://prod-25.canadaeast.logic.azure.com:443/workflows/45a885f3d8314851a6cc6393001c133d/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=TBcR1VFj_lVBmTFijg2WQ4XLzzv3KqOv3wVBGX3pIMg", true);
  xhttp.setRequestHeader("Content-type", "application/json");
  xhttp.send('<?php echo $myJSON ?>');
}
document.getElementById("function").innerHTML = postJSON();
</script>
<p>Data Sent!  </p><p><a href="index.php">Back</a></p>
</body>
</html>