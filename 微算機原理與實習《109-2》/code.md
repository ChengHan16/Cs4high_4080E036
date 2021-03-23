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
> # 筆記
```
**要設定整體變數把它放在函式外面
只有看的到的變數才能用
整體 = 區域變數
```
