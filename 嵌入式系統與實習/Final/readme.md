### Arduino.ino
```C
#include <ESP8266WiFi.h>
#include <ArduinoJson.h>
#include <DHT.h>
#define LED_R D5
#define LED_G D6
#define LED_B D7
#define DHTPIN D3
#define DHTTYPE DHT22
DHT dht(DHTPIN, DHTTYPE);
#define DHTupdateinterval 60000
const unsigned long HTTP_TIMEOUT = 3000;

#define HOST "192.168.2.183"

const char* ssid = " ASUSLAB ";
const char* password = " ASUSASUS ";

WiFiClient client;
void setup() {
  Serial.begin(9600);
  Serial.println();
  dht.begin();
  Serial.print("Connecting to ");
  Serial.println(ssid);
  WiFi.begin(ssid, password); 
  pinMode(LED_R,OUTPUT);
  pinMode(LED_G,OUTPUT);
  pinMode(LED_B,OUTPUT);
  digitalWrite(LED_R,LOW);
  digitalWrite(LED_G,LOW);
  digitalWrite(LED_B,LOW);
  delay(500);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.println("WiFi connected");
  
}
void loop() {
  static uint32_t lasttime=millis();
  Serial.printf("\n[Connecting to %s ... ", HOST);
  if (client.connect(HOST, 80))
  {
    Serial.println("[Host connected]");
    if ((millis()-lasttime) > DHTupdateinterval){
      lasttime=millis();
      float t = dht.readTemperature();
      float h = dht.readHumidity();
      Serial.print("溫度:");  
      Serial.println(t,DEC);
      Serial.print("濕度:");  
      Serial.println(h,DEC);
    if (isnan(h) || isnan(t) ) {
      Serial.println("Failed to read from DHT sensor!");}
    else
        { 
        String dbserver = HOST;
        String getStr = "GET /AddData.php?";
        getStr +="Temp=";
        getStr += String(t);
        getStr +="&Humidity=";
        getStr += String(h);
        getStr += " HTTP/1.1\r\n";
        getStr += "Host: " + String(dbserver) \
        + "\r\n"+ "Connection: close\r\n\r\n";
       client.print(getStr);
        int timeoutcnt=0;
        while((!client.available()) && (timeoutcnt < 50)) 
        {
          delay(200);  //Use this with time out
          timeoutcnt++;
        }
        //If data is available before time out read it.
        if(timeoutcnt < 50)
        {
          while(client.available()){
            //Response from WEB server
            Serial.println(client.readString());     
          }
        }
        else
        {
          Serial.println("Request timeout..");
        }
      }
  }
  client.stop();
  }
  else
  {
    Serial.println("connection failed!]");
    client.stop();
  }
   if (client.connect(HOST, 80))
  {
    Serial.println("[Host connected]");
    //Get the LED color
    Serial.println("[Sending a request as:]");
    client.print(String("GET /")  + "4080E036-1.php" + " HTTP/1.1\r\n" +
                 "Host: " + HOST + "\r\n" +
                 "Connection: close\r\n" +
                 "\r\n"
                );
    int timeoutcnt=0;
    while((!client.available()) && (timeoutcnt < 50)) 
    {
       delay(200);  //Use this with time out
       timeoutcnt++;
    }
     if(timeoutcnt < 50)
    {
       if (!client.find("\r\n\r\n")){
          Serial.println("invalid response");
          client.stop();       
          return;
       }  
       String section="LENGTH";
       client.setTimeout(5000);
       while(client.available())
       {
          String line = client.readStringUntil('\n');
          if( section == "LENGTH" )
          {
                // 這裡可以取回 JSON　字串的長度
                //String content_length = line.substring(1);
                /* 有需要處理的寫程式在這裡 */
                section = "JSON";
          }
          else if( section == "JSON" )    // print the good stuff
          {
                Serial.println( line );
                section = "END";
                String jsonStr = line;
                Serial.println(jsonStr);
                // 開始解析 JSON
                Serial.println("");
                const size_t capacity = JSON_ARRAY_SIZE(1) + JSON_OBJECT_SIZE(4) + 80;
                 DynamicJsonDocument jsondoc(capacity);
                // Parse JSON object
                DeserializationError error = deserializeJson(jsondoc, jsonStr);
                client.stop();                  
                String LED_ST=jsondoc[0]["LED_COLOR"];
                float Temp=jsondoc[0]["Temp"];
                float Humidity=jsondoc[0]["Humidity"];
                Serial.print("LED=");Serial.println(LED_ST);
                Serial.print("Temperaure="); Serial.println(Temp);
                Serial.print("Humidity="); Serial.println(Humidity);
                if (LED_ST=="Red")
                {
                    digitalWrite(LED_R, HIGH);
                    digitalWrite(LED_G,LOW);
                    digitalWrite(LED_B,LOW);
                }
                else if(LED_ST=="Green")
                {
                    digitalWrite(LED_G, HIGH);  
                    digitalWrite(LED_R,LOW);
                    digitalWrite(LED_B,LOW);                
                }
                if (LED_ST=="Blue")
                {
                    digitalWrite(LED_B, HIGH);
                    digitalWrite(LED_R,LOW);
                    digitalWrite(LED_G,LOW);
                }                        
          }
        }
      client.stop();
      Serial.println("\n[Disconnected]");
    }
    else
    {
       Serial.println("Request timeout..");
       client.stop();           
       return;
    }                 
  }
  else
  {
    Serial.println("connection failed!]");
    client.stop();
  }
  delay(1000);
} 
```
### Sensors.html
```html
<html>
	<head>
		<meta charset="utf-8">
			
		<title> 嵌入式系統與實習_Final</title>
	</head>

	<body>
		<div class="center">
			<h1 style="font-family: Microsoft JhengHei;"> 4080E036 吳承翰 </h1>
					
			<form method="GET" action="AddData.php">
			
				<a> 溫度：<input type="text" name="Temp" valign="center"> </a>     <br><br>
				<a> 濕度：<input type="text" name="Humidity" valign="center"> </a> <br><br>
				
				<input type="submit" valign="center" value="送出資料">
			
				<input type="button" valign="center" value="查詢資料庫資料" onclick="location.href='http://192.168.50.40/show.php'">
			</form>
		</div>
	</body>
</html>
```
### show.php
```php
<html>
<head>
<meta http-equiv="refresh" content="3">
</head>
<body>
	<nobr style="font-size:20px;"><font face="Microsoft JhengHei"> 嵌入式系統與實習 - 期末專題</font></nobr> <br>
	<nobr style="font-size:20px;"><font face="Microsoft JhengHei">4080E036 吳承翰</font></nobr> <br>
	<nobr style="font-size:20px;color:blue;"><font face="Microsoft JhengHei"> 溫度低於15</font></nobr><br>
	<nobr style="font-size:20px;color:#007500;"><font face="Microsoft JhengHei"> 溫度位於 25 Green (綠色)</font></nobr><br>
	<nobr style="font-size:20px;color:red;"><font face="Microsoft JhengHei"> 溫度高於25</font></nobr> <br><br>
	
	<table border=3 bgcolor="White">
		<tr> 
			<th>ID</th>
			<th>溫度</th>
			<th>濕度</th>
			<th>顏色</th>
			<th>Time</th>
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
<input id="popUpYes" style="display: flex; margin: auto" type="button" value="返回" onclick="location.href='http://192.168.50.40/Sensors.html'">
</body>
</html>
```
### AddData.php
```php
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
<input type="button" value="返回上一頁" onclick="location.href='http://192.168.50.40/Sensors.html'">
</body>
</html>
```
### 4080E036-1.php
```php
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
```
