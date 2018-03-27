<html>
<header>
	<title>BOBCO</title>
	<h1>BOBCO Employee Database</h1>
</header>
<body>
	<p><a href="form.php">Mortgage Request Form</a></p>
</body>
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

$sql = "SELECT * FROM BOBCOemployees";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    echo "<table><tr><th>ID</th><th>Name</th><th>Employee Number</th><th>Position</th><th>Annual Salary</th><th>Years Employed</th></tr>";
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "<tr><td>" . $row["tableID"]. "</td><td>" . $row["firstName"]. " " . $row["lastName"]. "</td><td>" . $row["employeeID"]. "</td><td>" . $row["position"]. "</td><td>" . $row["annualSalary"]. "</td><td>" . $row["yearsEmployed"]. "</td></tr>";
    }
    echo "</table>";
} else {
    echo "0 results";
}

$conn->close();

?>