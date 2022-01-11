		<?php
			header("Content-Type:text/html; charset=utf-8");
			date_default_timezone_set("asia/taipei");
			$dns="mysql:host=127.0.0.1;dbname=Sensors4080E036";
			try{
				$db=new PDO($dns,'4080E036','0000');
				$db->exec("set names utf8");
				$sql = "select * from DHT ORDER BY id DESC ; ";
				$myArray = array();
				$result=$db->query($sql);
				if($row=$result->fetch(PDO::FETCH_ASSOC))//返回以欄位名稱作為索引鍵(key)的陣列(array)
				{
					$a1=array("Temp"=>$Temp,"Humidity"=>$Humidity,"LED_COLOR"=>$LED_COLOR,"Time"=>$Time);
					$row=array_merge($a1,$row);
					$myArray[] = $row;
				}
				echo  "\n";
				echo json_encode($myArray);
				echo "\n";
				$db=null;
			}catch(PDOException $e){
				printf("DATABASE_ERRMESG:%s",$e->getMessage());
			}
		?>	

