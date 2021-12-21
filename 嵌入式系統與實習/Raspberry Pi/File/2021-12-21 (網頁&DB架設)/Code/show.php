<html>
<body>
	<table border=3>
		<tr>
			<th>ID</th>
			<th>溫度</th>
			<th>濕度</th>
		</tr>
		<?php
		date_default_timezone_set("asia/taipei");
		$dsn='mysql:host=127.0.0.1;dbname=Sensors4080E036';
		try {
			$db=new PDO($dsn,'pi','raspberrypi');
			$db->exec("set names utf8");
			$sql="select * from DHT;";
			foreach ($db->query($sql) as $row) {
				echo "<tr>";
				echo "<td>".$row["ID"]."</td>";
				echo "<td>".$row["Temp"]."</td>";
				echo "<td>".$row["Humidity"]."</td>";
				echo "</tr>";
			}
		} catch (PDOException $e) {
			printf("DATABASER_ERRMESG: %s",$e->getMessage());
		}
?>
</table>
<input type="button" value="返回上一頁" onclick="location.href='http://192.168.2.183/Sensor.html'">
</body>
</html>
