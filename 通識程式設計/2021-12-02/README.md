## 一. 超音波接法
![超音波接法](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E9%80%9A%E8%AD%98%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88/2021-12-02/Img/%E8%B6%85%E9%9F%B3%E6%B3%A2%E6%8E%A5%E6%B3%95.PNG)
## 二. LED接法
![二. LED接法](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E9%80%9A%E8%AD%98%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88/2021-12-02/Img/LED.PNG)
## Result
![Result](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E9%80%9A%E8%AD%98%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88/2021-12-02/Img/%E8%B6%85%E9%9F%B3%E6%B3%A2%E7%B5%90%E6%9E%9C.PNG)
## 1.超音波偵測
```C
#include <hcsr04.h>

#define TRIG_PIN 12
#define ECHO_PIN 13
HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.println(hcsr04.ToString());
  delay(250);
}
```
## 1-2.或是超音波偵測寫法 2 (輸出結果會只有數值
```C
#include <hcsr04.h>

#define TRIG_PIN 12
#define ECHO_PIN 13
HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.println(hcsr04.distanceInMillimeters());
  delay(250);
}
```
## 2.超音波 Link LED燈閃爍
```C
#include <hcsr04.h>

#define TRIG_PIN 12
#define ECHO_PIN 13
HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);
const int ledPin = 9;

void setup() {
  Serial.begin(9600);
  pinMode (ledPin,OUTPUT); 
}

void loop() {
  Serial.println(hcsr04.distanceInMillimeters());
  if(hcsr04.distanceInMillimeters() > 100){
    digitalWrite(ledPin,HIGH);
  }
  else{
    digitalWrite(ledPin,LOW);
  }
  delay(250);
}
```
## 3.超音波 Link LED燈閃爍 + 伺服馬達做偵測旋轉
```c
#include <hcsr04.h>
#include <Servo.h> 
#define TRIG_PIN 12
#define ECHO_PIN 13
HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);
const int ledPin = 9;
Servo myservo;

void setup() {
  Serial.begin(9600);
  pinMode (ledPin,OUTPUT); 
  myservo.attach(8);
}

void loop() {
  Serial.println(hcsr04.distanceInMillimeters());
  if(hcsr04.distanceInMillimeters() > 100){
    digitalWrite(ledPin,HIGH);
    myservo.write(0); //旋轉到90度
    delay(1000);
  }
  else{
    digitalWrite(ledPin,LOW);
    myservo.write(180); //旋轉到180度
    delay(1000);
  }
  delay(250);
}
```
## 4.超音波 Link LED 燈閃爍 + 伺服馬達做偵測旋轉 + 蜂鳴器控制,小於100時就會叫
```C
#include <hcsr04.h>
#include <Servo.h> 
#define TRIG_PIN 12
#define ECHO_PIN 13
HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);
const int ledPin = 9;
Servo myservo;

void setup() {
  Serial.begin(9600);
  pinMode (ledPin,OUTPUT); 
  pinMode(10,OUTPUT);
  myservo.attach(8);
}

void loop() {
  Serial.println(hcsr04.distanceInMillimeters());
  if(hcsr04.distanceInMillimeters() > 100){
    digitalWrite(ledPin,HIGH);
    myservo.write(0); //旋轉到90度
    digitalWrite(10,LOW);
    delay(1000);
  }
  else{
    digitalWrite(ledPin,LOW);
    myservo.write(180); //旋轉到180度
    digitalWrite(10,HIGH);
    delay(1000);
  }
  delay(250);
}
```
● 參考資料

### Servo伺服馬達
> https://blog.jmaker.com.tw/arduino-servo-sg90/
### 蜂鳴器
> https://blog.jmaker.com.tw/arduino-buzzer/
