## 2021-05-04 00:00 ~ 2021-05-10 23:59

## 請於第一列顯示你的學號，請於第二列顯示矩陣式鍵盤按下的按鍵值<br>請說明程式碼否則不予計分，需附上執行成果照片
```C
#include <LiquidCrystal.h>
LiquidCrystal lcd(8,9,4,5,6,7);

void setup(){
  pinMode(BT1,INPUT);
  pinMode(BT2,INPUT);
  pinMode(BT3,INPUT);
  pinMode(BT4,INPUT);

  lcd.begin(16,2);
  lcd.print("hello,word!");
  lcd.setCursor(0,1);
  lcd.print("Wellcom to KSU!");
}

int buttonState1,buttonState2,buttonState3,buttonState4=0;
int delay_number = 100;

void loop(){
  buttonState1 =  digitalRead(BT1);
  buttonState2 =  digitalRead(BT2);
  buttonState3 =  digitalRead(BT3);
  buttonState4 =  digitalRead(BT4);
  if(buttonState1 == LOW){
    lcd.clear();
    lcd.print("BT1");
    lcd.setCursor(0,1);
    lcd.print("4080E036");
      delay(delay_number);
  } 
  else if (buttonState2 == LOW){
    lcd.clear();
    lcd.print("BT2");
    lcd.setCursor(0,1);
    lcd.print("4080E036");
      delay(delay_number);
  }
  else if (buttonState3 == LOW){
    lcd.clear();
    lcd.print("BT3");
    lcd.setCursor(0,1);
    lcd.print("4080E036");
      delay(delay_number);
  }
  else if (buttonState4 == LOW){
    lcd.clear();
    lcd.print("BT4");
    lcd.setCursor(0,1);
    lcd.print("4080E036");
      delay(delay_number);
  }
}
```
# 參考資料
> `http://lihan.shinyo.bixone.com/Arduino/arduino-2015.11.05-2.html`
