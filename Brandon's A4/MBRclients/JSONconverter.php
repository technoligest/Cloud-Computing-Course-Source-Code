<html>
<head>
<title>Data Submission</title>
</head>
<body>
<?php 
$myObj->name = $_POST['name'];
$myObj->address = $_POST['address'];
$myObj->phoneNum = $_POST['phoneNum'];
$myObj->brokerID = $_POST['brokerID'];
$myObj->employer = $_POST['employer'];
$myObj->insurer = $_POST['insurer'];

$myJSON = json_encode($myObj);

echo $myJSON;
?>
<p id="function"></p>
<script>
function postJSON() {
  var xhttp = new XMLHttpRequest();
  xhttp.open("POST", "https://prod-12.canadaeast.logic.azure.com:443/workflows/9dfcf5f475a24ef18cd810668ef8ee5b/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=R0IjxMMTmkU6sYO_e9jmEn8qikUkgoIfEfi7Wrts65U", true);
  xhttp.setRequestHeader("Content-type", "application/json");
  xhttp.send('<?php echo $myJSON ?>');
}
document.getElementById("function").innerHTML = postJSON();
</script>
<p>Data Sent!  </p><p><a href="index.php">Back</a></p>
</body>
</html>