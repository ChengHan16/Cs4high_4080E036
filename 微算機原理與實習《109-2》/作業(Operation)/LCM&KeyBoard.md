## 2021-05-04 00:00 ~ 2021-05-10 23:59

## 請於第一列顯示你的學號，請於第二列顯示矩陣式鍵盤按下的按鍵值<br>請說明程式碼否則不予計分，需附上執行成果照片
```C
#define LATCH_DIO D15 //使移位暫存器的內容輸出到輸出腳位
#define CLK_DIO D14 //移動位移站存器的內容
#define DATA_DIO 2 //移位暫存器的資料輸入內容

#include <LiquidCrystal.h>
LiquidCrystal lcd(8,9,4,5,6,7);
byte Row=0, Col=0;

void setup(){
  pinMode(LATCH_DIO,OUTPUT);
  pinMode(CLK_DIO,OUTPUT);
  pinMode(DATA_DIO,OUTPUT);
  pinMode(10, INPUT); //R1: S1,S2,S3,S4 (1,2,3,A)                                   
  pinMode(11, INPUT_PULLUP); //R2: S5,S6,S7,S8 (4,5,6,B)
  pinMode(12, INPUT_PULLUP); //R3: S9, S10, S11,S12 (7,8,9,C)
  pinMode(13, INPUT_PULLUP); //R4: (*,0,#,D) //*->E, #->F
  pinMode(A0, OUTPUT); //A1, C1: S1,S5,S9 (1,4,7,*)
  pinMode(A1, OUTPUT); //A2, C2: S2,S6,S10 (2,5,8,0)
  pinMode(A2, OUTPUT); //A3, C3: S3,S7,S11 (3,6,9,#)
  pinMode(A3, OUTPUT); //A4, C4, S4,S8,S12 (*,0, #,D)

  lcd.begin(16,2);
  lcd.print("hello,word!");
  lcd.setCursor(0,1);
  lcd.print("Wellcom to KSU!");
}

int buttonState1,buttonState2,buttonState3,buttonState4=0;
int delay_number = 100;

void loop(){
  buttonState1 =  digitalRead(10);
  buttonState2 =  digitalRead(11);
  buttonState3 =  digitalRead(12);
  buttonState4 =  digitalRead(13);
  if(buttonState1 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("BT1");
      delay(delay_number);
  } 
  else if (buttonState2 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("BT2");
      delay(delay_number);
  }
  else if (buttonState3 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("BT3");
      delay(delay_number);
  }
  else if (buttonState4 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("BT4");
      delay(delay_number);
  }
}

bool keyscan( )
{
  Row=0;Col=0;
  bool keypressed = false;
  //scan col1
  digitalWrite(A0, LOW);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, HIGH);
  digitalWrite(A3, HIGH);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A0, HIGH);
      Col=1;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A0, HIGH);
      Col=1;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A0, HIGH);
      Col=1;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
       digitalWrite(A0, HIGH);
      Col=1;Row=4;
      keypressed = true;
      return(keypressed);
  }
  //scan col2
  digitalWrite(A0, HIGH);
  digitalWrite(A1, LOW);
  digitalWrite(A2, HIGH);
  digitalWrite(A3, HIGH);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=4;
      keypressed = true;
      return(keypressed);
  }
  //scan col3
  digitalWrite(A0, HIGH);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, LOW);
  digitalWrite(A3, HIGH);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=4;
      keypressed = true;
      return(keypressed);
  }
  //scan col4
  digitalWrite(A0, HIGH);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, HIGH);
  digitalWrite(A3, LOW);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A3, HIGH);
      Col=4;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A3, HIGH);
      Col=4;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A3, HIGH);
      Col=4;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
       digitalWrite(A3, HIGH);
      Col=4;Row=4;
      keypressed = true;
      return(keypressed);
  }
  return(false);
}
```
# 參考資料
> `http://lihan.shinyo.bixone.com/Arduino/arduino-2015.11.05-2.html`
# ノート
# 2
```C
#define LATCH_DIO D15 //使移位暫存器的內容輸出到輸出腳位
#define CLK_DIO D14 //移動位移站存器的內容
#define DATA_DIO 2 //移位暫存器的資料輸入內容

#include <LiquidCrystal.h>
LiquidCrystal lcd(8,9,4,5,6,7);
byte Row=0, Col=0;

void setup(){
  pinMode(LATCH_DIO,OUTPUT);
  pinMode(CLK_DIO,OUTPUT);
  pinMode(DATA_DIO,OUTPUT);
  pinMode(10, INPUT); //R1: S1,S2,S3,S4 (1,2,3,A)                                   
  pinMode(11, INPUT_PULLUP); //R2: S5,S6,S7,S8 (4,5,6,B)
  pinMode(12, INPUT_PULLUP); //R3: S9, S10, S11,S12 (7,8,9,C)
  pinMode(13, INPUT_PULLUP); //R4: (*,0,#,D) //*->E, #->F
  pinMode(A0, OUTPUT); //A1, C1: S1,S5,S9 (1,4,7,*)
  pinMode(A1, OUTPUT); //A2, C2: S2,S6,S10 (2,5,8,0)
  pinMode(A2, OUTPUT); //A3, C3: S3,S7,S11 (3,6,9,#)
  pinMode(A3, OUTPUT); //A4, C4, S4,S8,S12 (*,0, #,D)

  lcd.begin(16,2);
  lcd.print("hello,word!");
  lcd.setCursor(0,1);
  lcd.print("Wellcom to KSU!");
}

int buttonState1,buttonState2,buttonState3,buttonState4=0;
int delay_number = 100;

void loop(){
  buttonState1 =  digitalRead(10);
  buttonState2 =  digitalRead(11);
  buttonState3 =  digitalRead(12);
  buttonState4 =  digitalRead(13);
  if(buttonState1 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("SW1");
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,4);
    lcd.print("SW2");
      delay(delay_number);
  } 
  else if (buttonState2 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("SW4");
      delay(delay_number);
  }
  else if (buttonState3 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("SW7");
      delay(delay_number);
  }
  else if (buttonState4 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("SW16");
      delay(delay_number);
  }

  
}

bool keyscan( )
{
  Row=0;Col=0;
  bool keypressed = false;
  //scan col1
  digitalWrite(A0, LOW);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, HIGH);
  digitalWrite(A3, HIGH);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      lcd.clear();
      lcd.print("4080E036");
      lcd.setCursor(0,1);
      lcd.print("SW1");
      digitalWrite(A0, HIGH);
      Col=1;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A0, HIGH);
      Col=1;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A0, HIGH);
      Col=1;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
       digitalWrite(A0, HIGH);
      Col=1;Row=4;
      keypressed = true;
      return(keypressed);
  }
  //scan col2
  digitalWrite(A0, HIGH);
  digitalWrite(A1, LOW);
  digitalWrite(A2, HIGH);
  digitalWrite(A3, HIGH);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=4;
      keypressed = true;
      return(keypressed);
  }
  //scan col3
  digitalWrite(A0, HIGH);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, LOW);
  digitalWrite(A3, HIGH);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=4;
      keypressed = true;
      return(keypressed);
  }
  //scan col4
  digitalWrite(A0, HIGH);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, HIGH);
  digitalWrite(A3, LOW);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A3, HIGH);
      Col=4;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A3, HIGH);
      Col=4;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A3, HIGH);
      Col=4;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
       digitalWrite(A3, HIGH);
      Col=4;Row=4;
      keypressed = true;
      return(keypressed);
  }
  return(false);
}
```
# 3
```C
#define LATCH_DIO D15 //使移位暫存器的內容輸出到輸出腳位
#define CLK_DIO D14 //移動位移站存器的內容
#define DATA_DIO 2 //移位暫存器的資料輸入內容

#include <LiquidCrystal.h>
LiquidCrystal lcd(8,9,4,5,6,7);
byte Row=0, Col=0;

void setup(){
  pinMode(LATCH_DIO,OUTPUT);
  pinMode(CLK_DIO,OUTPUT);
  pinMode(DATA_DIO,OUTPUT);
  pinMode(10, INPUT); //R1: S1,S2,S3,S4 (1,2,3,A)                                   
  pinMode(11, INPUT_PULLUP); //R2: S5,S6,S7,S8 (4,5,6,B)
  pinMode(12, INPUT_PULLUP); //R3: S9, S10, S11,S12 (7,8,9,C)
  pinMode(13, INPUT_PULLUP); //R4: (*,0,#,D) //*->E, #->F
  pinMode(A0, OUTPUT); //A1, C1: S1,S5,S9 (1,4,7,*)
  pinMode(A1, OUTPUT); //A2, C2: S2,S6,S10 (2,5,8,0)
  pinMode(A2, OUTPUT); //A3, C3: S3,S7,S11 (3,6,9,#)
  pinMode(A3, OUTPUT); //A4, C4, S4,S8,S12 (*,0, #,D)

  lcd.begin(16,2);
  lcd.print("hello,word!");
  lcd.setCursor(0,1);
  lcd.print("Wellcom to KSU!");
}

int buttonState1,buttonState2,buttonState3,buttonState4=0;
int delay_number = 100;

void loop(){
  buttonState1 =  digitalRead(10);
  buttonState2 =  digitalRead(11);
  buttonState3 =  digitalRead(12);
  buttonState4 =  digitalRead(13);
  if(buttonState1 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("SW1");
      delay(delay_number);
  } 
  else if (buttonState2 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("SW4");
      delay(delay_number);
  }
  else if (buttonState3 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("SW7");
      delay(delay_number);
  }
  else if (buttonState4 == LOW){
    lcd.clear();
    lcd.print("4080E036");
    lcd.setCursor(0,1);
    lcd.print("SW16");
      delay(delay_number);
  }

  
}

bool keyscan( )
{
  Row=0;Col=0;
  bool keypressed = false;
  //scan col1
  digitalWrite(A0, LOW);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, HIGH);
  digitalWrite(A3, HIGH);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      lcd.clear();
      lcd.print("4080E036");
      lcd.setCursor(0,1);
      lcd.print("SW1");
      digitalWrite(A0, HIGH);
      Col=1;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A0, HIGH);
      Col=1;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A0, HIGH);
      Col=1;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
       digitalWrite(A0, HIGH);
      Col=1;Row=4;
      keypressed = true;
      return(keypressed);
  }
  //scan col2
  digitalWrite(A0, HIGH);
  digitalWrite(A1, LOW);
  digitalWrite(A2, HIGH);
  digitalWrite(A3, HIGH);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
      digitalWrite(A1, HIGH);
      Col=2;Row=4;
      keypressed = true;
      return(keypressed);
  }
  //scan col3
  digitalWrite(A0, HIGH);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, LOW);
  digitalWrite(A3, HIGH);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
      digitalWrite(A2, HIGH);
      Col=3;Row=4;
      keypressed = true;
      return(keypressed);
  }
  //scan col4
  digitalWrite(A0, HIGH);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, HIGH);
  digitalWrite(A3, LOW);
  delayMicroseconds(100);
  //Read keys in row.1
  if(digitalRead(10)==LOW)
  {
      digitalWrite(A3, HIGH);
      Col=4;Row=1;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.2
  if(digitalRead(11)==LOW)
  {
      digitalWrite(A3, HIGH);
      Col=4;Row=2;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.3
  if(digitalRead(12)==LOW)
  {
      digitalWrite(A3, HIGH);
      Col=4;Row=3;
      keypressed = true;
      return(keypressed);
  }
  //Read keys in row.4
  if(digitalRead(13)==LOW)
  {
       digitalWrite(A3, HIGH);
      Col=4;Row=4;
      keypressed = true;
      return(keypressed);
  }
  return(false);
}
```
# 修改
```C
#include <LiquidCrystal.h>//使用LiquidCrystal函式庫
// select the pins used on the LCD panel
LiquidCrystal lcd(8,9,4,5,6,7);

// 依照行、列排列的按鍵字元（二維陣列）
char KeyMap[4][4]={
                     {'1','2','3','A'},
                     {'4','5','6','B'},
                     {'7','8','9','C'},
                     {'*','0','#','D'}};
const byte rowPins[4] = {10,11,12,13};//  設定「列」腳位
const byte colPins[4] = {A0,A1,A2,A3};//  設定「行」腳位
byte r,c,i;      // 暫存迴圈的索引數字
byte scanVal;   // 暫存掃描到的按鍵值
int n=0;        // LCM游標位置變數
void setup() {
  lcd.begin(16, 2);// 初始化 LCD，一行 16 的字元，共 2 行  
  lcd.setCursor(0,0);// 設定游標位置在第一行行首
  lcd.print("4080E036");//顯示學號在LCM
  lcd.setCursor(0,1);// 設定游標位置在第二行行首
  for (i = 0; i <= 3; i++) {
    pinMode(rowPins[i], INPUT);
    pinMode(colPins[i], OUTPUT);}}

void loop() {
  // put your main code here, to run repeatedly:
  byte Row=0, Col=0; //被按下的按鍵在迴圈值
  if(keyscan()==true){ //第一次掃描如果有按鍵被按下繼續檢查第二次
    Row=r;Col=c;//讀取迴圈值
    delay(5);
    //第二次掃描按鍵如果有按鍵被按下且位置一樣表示非雜訊產生而是真正按下按鍵
    if ((keyscan()==true) && (Row==r)&&(Col==c)){
      lcd.setCursor(n,1);// 設定游標位置在第二行行首
      lcd.print(KeyMap[r][c]);//讀取陣列值顯示在LCM  
      digitalWrite(A0,LOW);
      digitalWrite(A1,LOW);
      digitalWrite(A2,LOW);
      digitalWrite(A3,LOW);
      delayMicroseconds(100);
      n=n+1;//LCM位置變數+1
      if (n>15){//判斷LCM是否顯示到底
        n=0;}
      while( (digitalRead(10)==LOW) || (digitalRead(11)==LOW)||(digitalRead(12)==LOW) || (digitalRead(13)==LOW));
      }}}  
    
bool keyscan( )
{
  for (r = 0; r <= 3; r++) {
    for (c = 0; c <= 3; c++) {
      digitalWrite(colPins[c], LOW);
      delayMicroseconds(100);// 掃描按鍵的間隔時間
      scanVal = digitalRead(rowPins[r]);
      if (scanVal == LOW) {    // 如果按鍵是「低電位」
      digitalWrite(colPins[c], HIGH);
      return(true);//回傳trueru，結束keyscan( )
      break;}       // 跳出迴圈
    digitalWrite(colPins[c], HIGH);}}
  return(false);}//回傳false，結束keyscan( )
```
