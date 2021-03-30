> # 下載 Arduino 版本 1.6.5 
> `https://www.arduino.cc/en/main/OldSoftwareReleases `
> # ToolChain Installtion 安裝開發板(ADP-Corvette-F1)
> `https://andestech.github.io/Arduino/package_Corvette_knectme_index.json`
> # LibusbK USB Driver Installation
>> 切換到"arduino-1.6.5-r5\packages\Corvette\tools\burner\3.2.1-ast\libusb-AICE-driver"
>>> ### ● 點擊"Install_driver.exe"
>  `C:\Users\I5302\AppData\Roaming\Arduino15\packages\Corvette\tools\burner\3.2.1-ast\libusb-AICE-driver`
```

```
# Code
``` C
/*
  Blink
  Turns on an LED on for one second, then off for one second, repeatedly.

  Most Arduinos have an on-board LED you can control. On the Uno and
  Leonardo, it is attached to digital pin 13. If you're unsure what
  pin the on-board LED is connected to on your Arduino model, check
  the documentation at http://www.arduino.cc

  This example code is in the public domain.

  modified 8 May 2014
  by Scott Fitzgerald
 */


// the setup function runs once when you press reset or power the board
void setup() {
  // initialize digital pin 13 as an output.
  pinMode(13, OUTPUT);
}

// the loop function runs over and over again forever
void loop() {
  digitalWrite(13, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(100);              // wait for a second,更改速度位置
  digitalWrite(13, LOW);    // turn the LED off by making the voltage LOW
  delay(1000);              // wait for a second
}
```
# 2021-03-23
```C
void setup() {
  // put your main code here, to run once:
  pinMode(LED1, OUTPUT);
    for(int i=26; i<30; i++) // LED1 -> 26‧LED4 -> 29
    {
      pinMode(i, OUTPUT);
      digitalWrite(i, LOW);
    }
}

// the loop function runs over and over again forever
void loop() {
  // put your main code here, to run repeatedily:
  for(int i=26; i<30; i++)
    for(int j=0; j<3; j++)
    {
      digitalWrite(i,HIGH);
      delay(700);
      digitalWrite(i,LOW);
      delay(300);
    }
}
```
```C
void setup() {
  // put your main code here, to run once:
  pinMode(LED1, OUTPUT);
    for(int i=29; i>25; i--) // LED1 -> 26‧LED4 -> 29
    {
      pinMode(i, OUTPUT);
      digitalWrite(i, LOW);
    }
}

// the loop function runs over and over again forever
void loop() {
  // put your main code here, to run repeatedily:
  for(int i=29; i>25; i--)
    for(int j=0; j<1; j++)
    {
      digitalWrite(i,HIGH);
      delay(300);
      digitalWrite(i,LOW);
      delay(300);
    }
}
```
```C
void setup() {
  // put your main code here, to run once:
  pinMode(14,OUTPUT);//A0
  pinMode(15,OUTPUT);//A1
  pinMode(16,OUTPUT);//A2
  pinMode(17,OUTPUT);//A3
  digitalWrite(14,HIGH);
  digitalWrite(15,HIGH);
  digitalWrite(16,HIGH);
  digitalWrite(17,HIGH);
}

// the loop function runs over and over again forever
void loop() {
  // put your main code here, to run repeatedily:
  for(int i=14; i<18; i++)
    for(int j=0; j<3; j++)
    {
      digitalWrite(i,HIGH);
      delay(700);
      digitalWrite(i,LOW);
      delay(300);
    }
}
```
___
# 2021-03-30
## LEDD1_D4FLASH.ino
```C

void setup() {
  // put your setup code here, to run once:
  pinMode(LED1, OUTPUT);
    for(int i=26; i<30; i++) //LED1->26，LED4->29
    {
      pinMode(i,  OUTPUT);
      digitalWrite(i, LOW);
    }
}

void loop() {
  // put your main code here, to run repeatedly:
  for(int i=26; i<30; i++)
    for(int j=0; j<3; j++)
    {
      digitalWrite(i, HIGH);
      delay(700);
      digitalWrite(i, LOW);
      delay(300);
    }

}
```
## LEDAFLASH.ino
```C
void setup() {
  // put your setup code here, to run once:
  pinMode(14, OUTPUT);//A0
  pinMode(15, OUTPUT);//A1
  pinMode(16, OUTPUT);//A2
  pinMode(17, OUTPUT);//A3
  digitalWrite(14, HIGH);
  digitalWrite(15, HIGH);
  digitalWrite(16, HIGH);
  digitalWrite(17, HIGH);
}

void loop() {
  // put your main code here, to run repeatedly:
  for(int i=14; i<18; i++)
    for(int j=0; j<3; j++)
    {
      digitalWrite(i, LOW);
      delay(700);
      digitalWrite(i, HIGH);
      delay(300);
    }
}
```
## PILI.ino 霹靂燈
```C
  #define NUM 25 // 首先定義LED的數目
 
 int leds[NUM] = {
  0, 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, D14, D15, A0, A1, A2, A3, LED1, LED2, LED3,LED4
};

/*#define NUM 16
int leds[NUM] = {
  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 18, 19};
*/

// 將每個腳位模式設為OUTPUT
void setup() {               
  for(int i = 0; i < NUM; i++){
    pinMode(leds[i], OUTPUT);
    digitalWrite(leds[i], HIGH);
  }    
}
// 雖然A3、A2、A1、A0是類比腳位，
// 但也可以把它當做數位腳位使用。

// 然後是兩個迴圈，
// 第一個迴圈從IO0->IO15，
// 第二個迴圈跑IO14->IO0。
void loop() {
  for(int i = 0; i < 15; i++){
    digitalWrite(leds[i], LOW);
    delay(500);
    digitalWrite(leds[i], HIGH);
  }
  for(int i = 15-1; i > 0; i--){
    digitalWrite(leds[i], LOW);
    delay(500);
    digitalWrite(leds[i], HIGH);
  }
}
```
# 七段顯示器 
## 共陰 --> 要亮送 1
## 共陽 --> 要亮送 0
## 範例：
## 顯示 " 0 "
|b7|b6|b5|b4|b3|b2|b1|b0|
|-|-|-|-|-|-|-|-|
|0|0|1|1|1|1|1|1|
## 16 進位 = 0
___
> # 筆記
```
**要設定整體變數把它放在函式外面
只有看的到的變數才能用
整體 = 區域變數
```
