<html>
<head>
<meta http-equiv="refresh" content="3">
<style>

body{
background: rgb(122,188,255); 
background: -moz-linear-gradient(top,  rgba(122,188,255,1) 0%, rgba(96,171,248,1) 44%, rgba(64,150,238,1) 100%);
background: -webkit-linear-gradient(top,  rgba(122,188,255,1) 0%,rgba(96,171,248,1) 44%,rgba(64,150,238,1) 100%); 
background: linear-gradient(to bottom,  rgba(122,188,255,1) 0%,rgba(96,171,248,1) 44%,rgba(64,150,238,1) 100%); 
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#7abcff', endColorstr='#4096ee',GradientType=0 ); 
}

font{
font-weight:bold;
}

input{
font-size:25px;
border:0;
background-color:#003C9D;
color:#fff;border-radius:10px;
}

#text{
    -webkit-text-stroke: 5px white;
}

table {
  border-collapse: collapse;
  width: 100%;
}

th, td {
  padding: 8px;
  text-align: left;
  border-bottom: 1px solid #DDD;
}

tr:hover {background-color: 	#0080FF;}
tr:nth-child(odd) {background-color: #E0E0E0;
}


#popUpYes
    {
      width: 140px;
      height: 50px;
      background-color: #003C9D

      color: white; /* SET COLOR IN WHITE */

            display: inline-flex;
    justify-content: center; /* center the content horizontally */
    align-items: center; /* center the content vertically */
    --padding-x: 1.2em;
    border-color: transparent;    }

    #popUpYes:hover
    {
      background-color: #C4E1FF;
      color: black; /* SET COLOR IN BLACK */
    }    
</style>
</head>
<body>
	<nobr style="font-size:20px;"><font face="Microsoft JhengHei"> 嵌入式系統與實習 - 期末專題</font></nobr> <br>
	<nobr style="font-size:20px;"><font face="Microsoft JhengHei">4080E036 吳承翰</font></nobr> <br>
	<nobr style="font-size:20px;color:blue;"><font face="Microsoft JhengHei"> &emsp;• 溫度低於 9 度時顯示 Blue (藍色)</font></nobr><br>
	<nobr style="font-size:20px;color:#007500;"><font face="Microsoft JhengHei"> &emsp;• 溫度位於 10-25 度時顯示 Green (綠色)</font></nobr><br>
	<nobr style="font-size:20px;color:red;"><font face="Microsoft JhengHei"> &emsp;• 溫度高於25度時顯示 Red (紅色)</font></nobr> <br><br>
	
	<table border=3 bgcolor="White">
		<tr> 
			<th>ID</th>
			<th>溫度</th>
			<th>濕度</th>
			<th>LED_COLOR</th>
			<th>時間</th>
		</tr>
		<?php
		date_default_timezone_set("asia/taipei");
		$dsn='mysql:host=127.0.0.1;dbname=Sensors4080E036';
		try {
			$db=new PDO($dsn,'4080E036','0000');
			$db->exec("set names utf8");
			$sql="select * from DHT ORDER BY id DESC LIMIT 1;";
			foreach ($db->query($sql) as $row) {
				echo "<tr>";
				echo "<td>".$row["ID"]."</td>";
				echo "<td>".$row["Temp"]."</td>";
				echo "<td>".$row["Humidity"]."</td>";
				echo "<td>".$row["LED_COLOR"]."</td>";
				echo "<td>".$row["Time"]."</td>";
				echo "</tr>";
			}
		} catch (PDOException $e) {
			printf("DATABASER_ERRMESG: %s",$e->getMessage());
		}
?>
</table>
<br>
<input id="popUpYes" style="display: flex; margin: auto" type="button" value="返回" onclick="location.href='http://192.168.2.183/Sensors.html'">
</body>
</html>
