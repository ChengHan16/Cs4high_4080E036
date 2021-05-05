# `LCD_RTC.ino`
```C
/*
  LiquidCrystal Library
  The circuit:
 * LCD RS pin to digital pin 8
 * LCD Enable pin to digital pin 9
 * LCD D4 pin to digital pin 4
 * LCD D5 pin to digital pin 5
 * LCD D6 pin to digital pin 6
 * LCD D7 pin to digital pin 7
 * LCD R/W pin to ground
 * LCD VSS pin to ground
 * LCD VCC pin to 5V
 * 10K resistor:
 * ends to +5V and ground
 * wiper to LCD VO pin (pin 3)
 */

// include the library code:
#include <LiquidCrystal.h>
#include <RTC.h>
 
// initialize the library with the numbers of the interface pins
LiquidCrystal lcd(8, 9, 4, 5, 6, 7);

/* Change these values to set the current initial time */
const byte seconds = 0;
const byte minutes = 5;
const byte hours = 14;
const byte day = 5;

void setup() {
     // set up the LCD's number of columns and rows
     lcd.begin(16, 2); //(行,列)

     // set the time and start counting
     RTC.settime(day, hours, minutes, seconds);
     RTC.startcounting();
}

void loop() {
     lcd.clear();
     lcd.print("2021/05/");
     lcd.print(RTC.getday());
     lcd.print(",");
     lcd.setCursor(0, 1);
     
     lcd.print(RTC.gethours());
     lcd.print(":");
     lcd.print(RTC.getminutes());
     lcd.print(":");
     lcd.print(RTC.getseconds());
     
     delay(1000);
}
```
# 移動 lcm '考'
# `LCD_RTCalarm.ino`
```C
/*
  LiquidCrystal Library
  The circuit:
 * LCD RS pin to digital pin 8
 * LCD Enable pin to digital pin 9
 * LCD D4 pin to digital pin 4
 * LCD D5 pin to digital pin 5
 * LCD D6 pin to digital pin 6
 * LCD D7 pin to digital pin 7
 * LCD R/W pin to ground
 * LCD VSS pin to ground
 * LCD VCC pin to 5V
 * 10K resistor:
 * ends to +5V and ground
 * wiper to LCD VO pin (pin 3)
 */

// include the library code:
#include <LiquidCrystal.h>
#include <RTC.h>
//#include "rtc_drv.h"

/* RTC driver */
//RTC_Driver RTC_DRV = {DEV_RTC, 0};
// initialize the library with the numbers of the interface pins
LiquidCrystal lcd(8, 9, 4, 5, 6, 7);

/* Change these values to set the current initial time */
const byte seconds = 0;
const byte minutes = 4;
const byte hours = 16;
const byte day = 15;
byte alarmminutes = 4;
byte alarmseconds = 10;
void setup() {
     // set up the LCD's number of columns and rows
     lcd.begin(16, 2);
     Serial.begin(115200);
     // set the time and start counting
     RTC.settime(day, hours, minutes, seconds);
     RTC.startcounting();
     RTC.setalarmcallbackfunc(alarm);
     RTC.setalarmtime(hours, minutes, alarmseconds);
     RTC.attachalarmint();
}

void loop() {
     lcd.clear();
     //lcd.print("Start Counting...");
     lcd.setCursor(0, 0);
     lcd.print("2021/5/");
     lcd.print(RTC.getday());
     lcd.print(",");
     lcd.print(RTC.gethours());
     lcd.print(":");
     lcd.print(RTC.getminutes());
     lcd.print(":");
     lcd.print(RTC.getseconds( ));
     delay(1000);
}

void alarm()
{
     lcd.setCursor(0, 1);
     lcd.print("                   ");
     lcd.setCursor(0, 1);
     lcd.print("alarm "); 
     lcd.print(RTC.getminutes());
     lcd.print(":");
     lcd.print(RTC.getseconds());
     delay(1000);
     alarmseconds += 5;
     if (alarmseconds >= 60)
        alarmminutes = RTC.getminutes()+1;
     else
        alarmminutes = RTC.getminutes(); 
     alarmseconds %= 60;
     RTC.setalarmtime(hours, alarmminutes, alarmseconds);        
     RTC.clearalarmst();  
}
```
# ノート
### C:\Users\I5302\AppData\Roaming\Arduino15\packages\Corvette\hardware\Corvette-F1-N25\1.6.5\cores\arduino\wiring_shift.c<br>43 行 void shiftOut
