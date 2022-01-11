Arduino.ino
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
#define DHTupdateinterval 1000
const unsigned long HTTP_TIMEOUT = 1000;
#define HOST "192.168.2.183"

const char* ssid = "ASUSLAB";
const char* password = "ASUSASUS";

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
    client.print(String("GET /")  + "4080I017-1.php" + " HTTP/1.1\r\n" +
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
