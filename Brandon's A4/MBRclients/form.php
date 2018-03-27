<!DOCTYPE HTML>  

<html>
<head>
<style>
.error {color: #FF0000;}
</style>
</head>
<header>
	<title>MBR New Mortgage</title>
	<h1>MBR New Mortgage Form</h1>
</header>
<body>
	<p><a href="index.php">Back</a></p>

<?php
// define variables and set to empty values
$nameErr = $addressErr = $phoneNumErr = $employerErr = $brokerIDErr = "";
$name = $address = $phoneNum = $employer = $brokerID = "";
$canSend = False;
$sent = False;

if ($_SERVER["REQUEST_METHOD"] == "POST") {
  if (empty($_POST["name"])) {
    $nameErr = "Name is required";
  } else {
    $name = test_input($_POST["name"]);
    if (!preg_match("/^[a-zA-Z ]*$/",$name)) {
      $nameErr = "Only letters and white space allowed"; 
    }
  }
  
  if (empty($_POST["address"])) {
    $addressErr = "Email is required";
  } else {
    $address = test_input($_POST["address"]);
    // check if e-mail address is well-formed
    if (!filter_var($address, FILTER_VALIDATE_EMAIL)) {
      $addressErr = "Invalid email format"; 
    }
  }
  
  if (empty($_POST["phoneNum"])) {
    $phoneNumErr = "Phone Number is required";
  } else {
    $phoneNum = test_input($_POST["phoneNum"]);
    if (!preg_match("/^[0-9 ]*$/",$phoneNum)) {
      $phoneNumErr = "Only numbers and white space allowed"; 
    }
  }
  
  if (empty($_POST["brokerID"])) {
    $brokerIDErr = "Broker ID is required";
  } else {
    $brokerID = test_input($_POST["brokerID"]);
    if (!preg_match("/^[0-9 ]*$/",$brokerID)) {
      $brokerIDErr = "Only numbers and white space allowed"; 
    }
  }
  
  if (empty($_POST["employer"])) {
    $employerErr = "Employer is required";
  } else {
    $employer = test_input($_POST["employer"]);
    if (!preg_match("/^[a-zA-Z ]*$/",$employer)) {
      $employerErr = "Only letters and white space allowed"; 
    }
  }

  if (empty($_POST["insurer"])) {
    $insurerErr = "Insurer is required";
  } else {
    $insurer = test_input($_POST["insurer"]);
    if (!preg_match("/^[a-zA-Z ]*$/",$insurer)) {
      $insurerErr = "Only letters and white space allowed"; 
    }
  }
  if ($nameErr == "" && $addressErr == "" && $phoneNumErr == "" && $employerErr == "" && $insurerErr == "") {
	$canSend = True;
  }
}

function test_input($data) {
  $data = trim($data);
  $data = stripslashes($data);
  $data = htmlspecialchars($data);
  return $data;
}

?>

<p><span class="error">* required field.</span></p>
<form method="post" action=<?php if ($canSend){
										$sent = True;
										echo "/JSONconverter.php";
									}
									else 
										echo htmlspecialchars($_SERVER["PHP_SELF"]);
							?>>  
  Name: <input type="text" name="name" value="<?php echo $name;?>">
  <span class="error">* <?php echo $nameErr;?></span>
  <br><br>
  Email Address: <input type="text" name="address" value="<?php echo $address;?>">
  <span class="error">* <?php echo $addressErr;?></span>
  <br><br>
  Phone Number: <input type="text" name="phoneNum" value="<?php echo $phoneNum;?>">
  <span class="error">* <?php echo $phoneNumErr;?></span>
  <br><br>
  Broker ID: <input type="text" name="brokerID" value="<?php echo $brokerID;?>">
  <span class="error">* <?php echo $brokerIDErr;?></span>
  <br><br>
  Employer: <input type="text" name="employer" value="<?php echo $employer;?>">
  <span class="error">* <?php echo $employerErr;?></span>
  <br><br>
  Insurer: <input type="text" name="insurer" value="<?php echo $insurer;?>">
  <span class="error">* <?php echo $insurerErr;?></span>
  <br><br>
  <input type="submit" name="submit" value="Submit">  
</form>

<?php
$conn = mysqli_connect('csci4145assignment4.cj5svtw0lzw5.ca-central-1.rds.amazonaws.com', 'admin', 'adminpass', 'MBRDatabase', 3306);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

if ($sent){
	$sql = "UPDATE MBRclients SET mortgageProcess='Begun' WHERE clientID=$brokerID";

	if ($conn->query($sql) === TRUE) {
		//echo "Record updated successfully";
	} else {
		echo "Error updating record: " . $conn->error;
	}

}

$conn->close();

if ($canSend){
	echo "<p>Data entered correctly! Please press submit once more to complete request.</p>";
}
?>

</body>
</html>