> http://172.20.247.236/
### 蜂鳴器
```C
/*
 蜂鳴器接線:
 S1 ==> D9
 V  ==> 5V
 G  ==> GND  
 程式說明:蜂鳴器會每隔1秒發出四短音。
 */
#define Buzzer 9

void setup() {
 pinMode(Buzzer, OUTPUT);
}

void loop() {
  tone(Buzzer, 1000, 100);
  delay(200);
  tone(Buzzer, 1000, 100);
  delay(200);
  tone(Buzzer, 1000, 100);
  delay(200);
  tone(Buzzer, 1000, 100);
  delay(1000);
}
```

### 溫溼度感測
```C
#include "DHT.h"
#define DHTPIN 9 
#define DHTTYPE DHT11
//#define DHTTYPE DHT22   // DHT 22 如果用的是DHT22，就用這行
//#define DHTTYPE DHT21   // DHT 21
DHT dht(DHTPIN, DHTTYPE);

void setup()
{
  Serial.begin(9600);
  Serial.println("DHTxx test!");
  dht.begin();  //初始化DHT
  
} // setup()

void loop()
{
  delay(1000);
  float h = dht.readHumidity();   //取得濕度
  float t = dht.readTemperature();  //取得溫度C

  //顯示在監控視窗裡
  Serial.print("Humidity: ");
  Serial.print(h);
  Serial.print(" %\t");
  Serial.print("Temperature: ");
  Serial.print(t);
  Serial.println(" *C ");
 
} // loop()
```
### 感測溫度低於21度時蜂鳴器會持續響 (溫溼度感測 + 蜂鳴器)
```C
#include "DHT.h"
#define DHTPIN 9
#define Buzzer 11
#define DHTTYPE DHT11
//#define DHTTYPE DHT22   // DHT 22 如果用的是DHT22，就用這行
//#define DHTTYPE DHT21   // DHT 21
DHT dht(DHTPIN, DHTTYPE);

void setup()
{
  pinMode(Buzzer, OUTPUT);
  Serial.begin(9600);
  Serial.println("DHTxx test!");
  dht.begin();  //初始化DHT
  
} // setup()

void loop()
{ 
  delay(1000);
  float h = dht.readHumidity();   //取得濕度
  float t = dht.readTemperature();  //取得溫度C

  if(dht.readTemperature() < 21){
    tone(Buzzer, 1000, 100);
    delay(200);
    tone(Buzzer, 1000, 100);
    delay(200);
    tone(Buzzer, 1000, 100);
    delay(200);
    tone(Buzzer, 1000, 100);
    delay(1000);

    Serial.print("Humidity: ");
    Serial.print(h);
    Serial.print(" %\t");
    Serial.print("Temperature: ");
    Serial.print(t);
    Serial.println(" *C ");
    Serial.println(" !!! 溫度低於20度 !!! ");
  }
  else {
    Serial.print("Humidity: ");
    Serial.print(h);
    Serial.print(" %\t");
    Serial.print("Temperature: ");
    Serial.print(t);
    Serial.println(" *C ");
  }
```
