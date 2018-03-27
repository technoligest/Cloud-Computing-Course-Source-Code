<html>
<header>
	<title>MBR</title>
	<h1>MBR Client Database</h1>
</header>
<body>
	<p><a href="form.php">New Mortgage</a></p>
</body>
</hmtl>
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

$sql = "SELECT * FROM MBRclients";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    echo "<table><tr><th>ID</th><th>Name</th><th>Broker ID</th><th>Mortgage Progress</th><th>Employer Info</th><th>Insurer Info</th></tr>";
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "<tr><td>" . $row["tableID"]. "</td><td>" . $row["firstName"]. " " . $row["lastName"]. "</td><td>" . $row["clientID"]. "</td><td>" . $row["mortgageProcess"]. "</td><td>" . $row["employerInfo"]. "</td><td>" . $row["insurerInfo"]. "</td></tr>";
    }
    echo "</table>";
} else {
    echo "0 results";
}

	$sql = "UPDATE MBRclients SET mortgageProcess='Complete' WHERE employerInfo!='' AND insurerInfo!=''";

	if ($conn->query($sql) === TRUE) {
		//echo "Record updated successfully";
	} else {
		echo "Error updating record: " . $conn->error;
	}


$conn->close();

?>