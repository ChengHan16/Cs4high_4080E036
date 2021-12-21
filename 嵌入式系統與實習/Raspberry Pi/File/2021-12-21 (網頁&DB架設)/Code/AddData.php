<?php
	date_default_timezone_set("asia/taipei");
	$dns="mysql:host=127.0.0.1;dbname=Sensors4080E036";
	$Temp=$_GET['Temp'];
	$Humidity=$_GET['Humidity'];

	try{
		$db=new PDO($dns,'pi','raspberrypi');
		$db->exec("set names utf8");
		$sql="insert into DHT(Temp,Humidity) values('$Temp','$Humidity');";
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
 
