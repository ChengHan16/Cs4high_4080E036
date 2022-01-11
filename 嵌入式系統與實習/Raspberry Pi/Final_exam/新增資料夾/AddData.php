<html>
<body>
<?php
	date_default_timezone_set("asia/taipei");
	$dns="mysql:host=127.0.0.1;dbname=Sensors4080E036";
	$Temp=$_GET['Temp'];
	$Humidity=$_GET['Humidity'];
	if ($Temp <9){
	   $LED_COLOR="Blue";
	}elseif($Temp>=10 && $Temp<25){
		$LED_COLOR="Green";
	}else{
		$LED_COLOR="Red";
	}
	try{
		$db=new PDO($dns,'4080E036','0000');
		$db->exec("set names utf8");
		$sql="insert into DHT(Temp,Humidity,LED_COLOR) values('$Temp','$Humidity','$LED_COLOR');";
		$result=$db->exec($sql);
		if($result==1){
			echo "OK";
		}else{
			echo "Error";
		}
	}catch(PDOException $e){
		printf("DATABASE_ERRMESG:%s",$e->getMessage());
	}
?>
<br><br><br>
<input type="button" value="返回上一頁" onclick="location.href='http://192.168.2.183/Sensors.html'">
</body>
</html>