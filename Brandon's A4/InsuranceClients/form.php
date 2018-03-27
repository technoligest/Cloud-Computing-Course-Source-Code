<!DOCTYPE HTML>  

<html>
<head>
<style>
.error {color: #FF0000;}
</style>
</head>
<header>
	<title>Insurance Co.</title>
	<h1>Insurance Mortgage Form</h1>
</header>
<body>
	<p><a href="index.php">Back</a></p>

<?php
// define variables and set to empty values
$clientIDErr = $brokerIDErr = "";
$clientID = $brokerID = "";
$canSend = False;

if ($_SERVER["REQUEST_METHOD"] == "POST") {
  if (empty($_POST["clientID"])) {
    $clientIDErr = "Client ID is required";
  } else {
    $clientID = test_input($_POST["clientID"]);
    if (!preg_match("/^[0-9 ]*$/",$clientID)) {
      $clientIDErr = "Only numbers and white space allowed"; 
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
  if ($brokerIDErr == "" && $clientIDErr == "") {
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
										echo "/JSONconverter.php";
									}
									else
										echo htmlspecialchars($_SERVER["PHP_SELF"]);
							?>>  
  Client ID: <input type="text" name="clientID" value="<?php echo $clientID;?>">
  <span class="error">* <?php echo $clientIDErr;?></span>
  <br><br>
  Broker ID: <input type="text" name="brokerID" value="<?php echo $brokerID;?>">
  <span class="error">* <?php echo $brokerIDErr;?></span>
  <br><br>
  <input type="submit" name="submit" value="Accept">  
</form>
<p>By pressing accept, you agree to send your info to your broker.</p>
<?php
if ($canSend){
	echo "<p>Data entered correctly! Please press submit once more to complete request.</p>";
}
?>

</body>
</html>