<html>
<style>
table th:after{
  display: block;
  content: "";
  width: 0px;
  height: 0px;
  position: absolute;
  top:calc(50% - 10px);
  right:-10px;
  border-left: 10px solid #7d7d7d;
  border-top: 10px solid transparent;
  border-bottom: 10px solid transparent;
}

.main {
  margin: 20px auto;
  item-align: center;
  width: 30%;
     text-align:center;
     font-family: 微軟正黑體; 
     font-weight:500px;
}
</style>
<body>
	<table class="main" border=3  style="border:5px black groove;" cellpadding="10" border='0' >
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
			#echo "\n(\"LED\":\"{$LED}\",\"Temperature\":{Temp}),");
			#$db=null
		} catch (PDOException $e) {
			printf("DATABASER_ERRMESG: %s",$e->getMessage());
		}
?>
</table>
<input type="button" value="返回上一頁" onclick="location.href='http://192.168.2.183/Sensor.html'">
</body>
</html>
