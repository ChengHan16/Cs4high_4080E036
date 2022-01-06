> https://docs.google.com/presentation/d/1VZaXIuDwXzkaAS1NrXdMKq2u5tZEOasU/edit?usp=sharing&ouid=110309797215525276113&rtpof=true&sd=true

## ● 期末報告設計稿
> ### - 專題名稱：智慧防盜 <br> - 功能及特色 <br>&ensp;&ensp;&ensp;當所設角度低於範圍內時會響起警報，LED 會閃爍，伺服馬    達可做防護或旋轉動作，蜂鳴器會響起。
> ### - 零件清單
>> ### 超音波
>> ### LED 燈
>> ### 伺服馬達
>> ### 蜂鳴器
> ### - 概念圖
![概念圖](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/%E9%80%9A%E8%AD%98%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88/File/%E6%B5%81%E7%A8%8B.PNG)
![註解 2021-12-23 171630](https://user-images.githubusercontent.com/55220866/147730634-eaf77795-f56d-4277-986c-bc1d3e364908.png)
![註解 2021-12-23 171555](https://user-images.githubusercontent.com/55220866/147730636-31406e05-fa89-4952-bb41-58e4293115ce.png)
##  ●  Code
```C
#include <hcsr04.h>
#include <Servo.h> 
#define TRIG_PIN 12
#define ECHO_PIN 13
#define Si  988

int melody[] = {Si, Si, Si, Si, Si, Si, Si, Si, Si, Si, Si, Si, Si};
int noteDurations[] = {1,1,2,1,1,2,1,1,1,1,1,1,4};

HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);
const int ledPin = 9;
Servo myservo;

void setup() {
  Serial.begin(9600);
  Serial.begin(115200);
  pinMode (ledPin,OUTPUT); 
  pinMode(10,OUTPUT);
  myservo.attach(8);
}

void loop() {
  Serial.println(hcsr04.distanceInMillimeters());
  if(hcsr04.distanceInMillimeters() > 300){
    Serial.println("目前狀態正常");
    digitalWrite(ledPin,HIGH);
    //myservo.write(0); //旋轉到90度
    digitalWrite(10,LOW);
    //delay(1000);
  }
  else{
    Serial.println(" --- 危險!!! ---");
    digitalWrite(ledPin,LOW);
    myservo.write(180); //旋轉到180度
    digitalWrite(10,HIGH);
    
    for (int thisNote = 0; thisNote < 8; thisNote++) {
    //計算每個音的長度，4分音符： 1000 / 4，8分音符：1000/8
    int noteDuration = 1000 / noteDurations[thisNote];
    tone(9, melody[thisNote], noteDuration);   //tone(PIN腳,音調,拍子)
    }

    for(int i = 0; i <= 180; i=i+1){
    myservo.write(i);
    delay(10);
    }
    for(int i = 0; i <= -180; i=i+1){
    myservo.write(i);
    delay(10);
    }
    //delay(1000);
  }
  //delay(250);
}
```
## 整理後 Code 
```C
#include <hcsr04.h>
#include <Servo.h> 
#define TRIG_PIN 12
#define ECHO_PIN 13
#define Si  988

int melody[] = {Si, Si, Si, Si, Si, Si, Si, Si, Si, Si, Si, Si, Si};
int noteDurations[] = {1,1,2,1,1,2,1,1,1,1,1,1,4};

HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);
const int ledPin = 9;
Servo myservo;

void setup() {
  Serial.begin(9600);
  Serial.begin(115200);
  pinMode (ledPin,OUTPUT); 
  pinMode(10,OUTPUT);
  myservo.attach(8);
}

void loop() {
  Serial.println(hcsr04.distanceInMillimeters());
  if(hcsr04.distanceInMillimeters() > 150){
    Serial.println("目前狀態正常");
    digitalWrite(ledPin,HIGH);
    digitalWrite(10,LOW);
    delay(1000);
  }
  else{
    Serial.println(" --- 危險!!! ---");
    digitalWrite(ledPin,LOW);
    myservo.write(180); //旋轉到180度
    digitalWrite(10,HIGH);
    
    for (int thisNote = 0; thisNote < 8; thisNote++) {
    //計算每個音的長度，4分音符： 1000 / 4，8分音符：1000/8
    int noteDuration = 1000 / noteDurations[thisNote];
    tone(9, melody[thisNote], noteDuration);   //tone(PIN腳,音調,拍子)
    }

    for(int i = 0; i <= 180; i=i+1){
    myservo.write(i);
    delay(10);
    }
    for(int i = 0; i <= -180; i=i+1){
    myservo.write(i);
    delay(10);
    }
  }
}
```
![image](https://user-images.githubusercontent.com/55220866/147737307-ac4b5cc2-db5d-4651-ac01-66fd6bf3101a.png)

## 參考資料
> https://blog.jmaker.com.tw/arduino-servo-sg90/
> http://yehnan.blogspot.com/2013/09/arduinotower-pro-sg90.html
