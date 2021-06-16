# ● ksu_ajax_db1.html + ksu_ajax_db1.php
### ksu_ajax_db1.html
```html
<html>
 <head>
 </head>
 <body>
	 <form>
		  <select name="users" onchange="showUser(this.value)">
			  <option value="">Select a student ID:</option>
			  <option value="1">IE01</option>
			  <option value="2">IE02</option>
			  <option value="3">IM01</option>
			  <option value="4">IM02</option>
		  </select>
	 </form>
 <br>
 <div id="txtHint"><b>Student infomation will be listed here...</b></div>
 
   <script>
	   function showUser(str) {
		  if (str == "") {
			document.getElementById("txtHint").innerHTML = "";
			return;
		  } else {
			var xmlhttp = new XMLHttpRequest();
			xmlhttp.onreadystatechange = function() {
			  if (this.readyState == 4 && this.status == 200) {
				document.getElementById("txtHint").innerHTML = this.responseText;
			  }
			};
			xmlhttp.open("GET","ksu_ajax_db1.php?q="+str,true);
			xmlhttp.send();
		  }
		}
   </script>
 </body>
</html>
```
### ksu_ajax_db1.php
```php
<!DOCTYPE html>
<html>
	<head>
		<style>
			table {
			  width: 100%;
			  border-collapse: collapse;
			}
			table, td, th {
			  border: 1px solid black;
			  padding: 5px;
			} 
			th {text-align: left;}
		</style>
	</head>
<body>
<?php
	$db_host = "localhost";
	$db_name = "ksu_database";
	$db_table = "ksu_std_table";
	$db_user = "root";
	$db_password = "";

	$q = intval($_GET['q']);
	$std_no="";
	$conn = mysqli_connect($db_host,$db_user,$db_password);
	
	if (!$conn) {
	  die('Could not connect: ' . mysqli_error($conn));
	  exit;
	} 
	mysqli_select_db($conn,$db_name);
    echo "Ajax 應用.結合JavaScript, php, html, css以及 MySQL"."<br><br>";
	// $q processing
	switch ($q) {
	  case 1:
		$std_no="IE01";
		break;
	  case 2:
		$std_no="IE02";
		break;
	  case 3:
		$std_no="IM01";
		break;
	  case 4:
		$std_no="IM02";
		break;
	  default:
		echo "Out of range on the select menu!";
	}
	$sql="SELECT ksu_std_id, ksu_std_name, ksu_std_age, ksu_std_grade FROM ksu_std_table WHERE ksu_std_id = '".$std_no."'";
	$result = mysqli_query($conn,$sql);

	echo "<table>
	<tr>
		<th>學號</th>
		<th>姓名</th>
		<th>年齡</th>
		<th>分數</th>
	</tr>";
	while($row = mysqli_fetch_array($result)) {
	  echo "<tr>";
	  echo "<td>" . $row['ksu_std_id'] . "</td>";
	  echo "<td>" . $row['ksu_std_name'] . "</td>";
	  echo "<td>" . $row['ksu_std_age'] . "</td>";
	  echo "<td>" . $row['ksu_std_grade'] . "</td>";
	  echo "</tr>";
	}
	echo "</table>";
	mysqli_close($conn);
?>
</body>
</html>
```
