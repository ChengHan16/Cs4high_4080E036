# LCD_RTC
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
