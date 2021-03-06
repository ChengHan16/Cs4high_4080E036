## 在七段顯示器上顯示 8 而由右移至左(重複)
```C
/* Define shift register pins used for seven segment display */

/*https://swf.com.tw/?p=715*/
#define LATCH_DIO D15
#define CLK_DIO D14
#define DATA_DIO 2
#define BUTTON1 BT1
#define BUTTON2 BT2
#define BUTTON3 BT3
#define BUTTON4 BT4
#define BUTTON_A1 A1
#define BUTTON_A2 A2
#define BUTTON_A3 A3
/* Segment byte maps for numbers 0 to 9 , A, b , C,d,E,F*/
const byte SEGMENT_MAP[] = {0x3F,0x06,0x5b,0x4F,0x66,0x6D,0x7D,0x27,0X7F,0X67,0X77,0x7c,0x39};
/* Byte maps to select digit 1 to 4 */
const byte SEGMENT_SELECT[] = {0xFE,0xFD,0xFB,0xF7, 0xF0};

void setup ()
{
  /* Set DIO pins to outputs */
  pinMode(LATCH_DIO,OUTPUT); //腳位設置OUTPUT 要將7段顯示器繳未送出 
  pinMode(CLK_DIO,OUTPUT);  //移位用的
  pinMode(DATA_DIO,OUTPUT); //送真的位元資料使用的
}
/* Main program */

void loop()
{
  WriteNumberToSegment(3 , 8);
  delay(500);
  WriteNumberToSegment(2 , 8);
  delay(500);
  WriteNumberToSegment(1 , 8);
  delay(500);
  WriteNumberToSegment(0 , 8);
}

/* Write a decimal number between 0 and 9 to one of the 4 digits of the display */
void WriteNumberToSegment(byte Segment, byte Value) //byte Segment 顯示得自行, byte Value顯示的位置)
{
digitalWrite(LATCH_DIO,LOW);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_MAP[Value]); //根據後面參數資料
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_SELECT[Segment] );
digitalWrite(LATCH_DIO,HIGH);
}
```
## 在七段顯示器上從左而右顯示 0~9
```C
/* Define shift register pins used for seven segment display */
#define LATCH_DIO D15   
#define CLK_DIO D14
#define DATA_DIO 2
#define BUTTON1 BT1
#define BUTTON2 BT2
#define BUTTON3 BT3
#define BUTTON4 BT4
#define BUTTON_A1 A1
#define BUTTON_A2 A2
#define BUTTON_A3 A3
/* Segment byte maps for numbers 0 to 9 , A, b , C*/
const byte SEGMENT_MAP[] = {0x3F,0x06,0x5b,0x4F,0x66,0x6D,0x7D,0x27,0X7F,0X67,0X77,0x7c,0x39,0X5e,0x79,0x71};

/* Byte maps to select digit 1 to 4 */
const byte SEGMENT_SELECT[] = {0xFE,0xFD,0xFB,0xF7};
void setup ()
{
/* Set DIO pins to outputs */
pinMode(LATCH_DIO,OUTPUT);
pinMode(CLK_DIO,OUTPUT);
pinMode(DATA_DIO,OUTPUT);
}
/* Main program */
void loop()
{
/* Update the display with the current counter value */
for(int i=0  ; i<16; i++){
  for(int j=0; j<4; j++){
  WriteNumberToSegment(j,i);
  delay(500);
  }
}
}

/* Write a decimal number between 0 and 9 to one of the 4 digits of the display */
void WriteNumberToSegment(byte Segment, byte Value)
{
digitalWrite(LATCH_DIO,LOW);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_MAP[Value]);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_SELECT[Segment] );
digitalWrite(LATCH_DIO,HIGH);
}
```
# Q2-1.ino
## 在7段顯示器上 分別用 BUTTON 按下後顯示 2 | 0 | 2 | 1 <> BTN1 最右方(3) 顯示1 <br> BTN2 最右方(2) 顯示2 <br> BTN3 最右方(1) 顯示0 <br> BTN4 最右方(0) 顯示2
```C
/* Define shift register pins used for seven segment display */
#define LATCH_DIO D15   
#define CLK_DIO D14
#define DATA_DIO 2
#define BUTTON1 BT1
#define BUTTON2 BT2
#define BUTTON3 BT3
#define BUTTON4 BT4
#define BUTTON_A1 A1
#define BUTTON_A2 A2
#define BUTTON_A3 A3
/* Segment byte maps for numbers 0 to 9 , A, b , C*/
const byte SEGMENT_MAP[] = {0x3F,0x06,0x5b,0x4F,0x66,0x6D,0x7D,0x27,0X7F,0X67,0X77,0x7c,0x39,0X5e,0x79,0x71};

/* Byte maps to select digit 1 to 4 */
const byte SEGMENT_SELECT[] = {0xFE,0xFD,0xFB,0xF7};
void setup ()
{
/* Set DIO pins to outputs */
pinMode(LATCH_DIO,OUTPUT);
pinMode(CLK_DIO,OUTPUT);
pinMode(DATA_DIO,OUTPUT);
}
/* Main program */
void loop()
{
/* Update the display with the current counter value */
if(!digitalRead(BUTTON1))
{
WriteNumberToSegment(3 , 1);
}  
if(!digitalRead(BUTTON2))
{
WriteNumberToSegment(2 ,2);
} 
if(!digitalRead(BUTTON3))
{
WriteNumberToSegment(1 , 0);
}  
if(!digitalRead(BUTTON4))
{
WriteNumberToSegment(0 , 2);
}  
}
/* Write a decimal number between 0 and 9 to one of the 4 digits of the display */
void WriteNumberToSegment(byte Segment, byte Value)
{
digitalWrite(LATCH_DIO,LOW);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_MAP[Value]);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_SELECT[Segment] );
digitalWrite(LATCH_DIO,HIGH);
}
```
# Q2-2.ino
## 按按鈕後共同顯示 2021
```C
/* Define shift register pins used for seven segment display */
#define LATCH_DIO D15   
#define CLK_DIO D14
#define DATA_DIO 2
#define BUTTON1 BT1
#define BUTTON2 BT2
#define BUTTON3 BT3
#define BUTTON4 BT4
#define BUTTON_A1 A1
#define BUTTON_A2 A2
#define BUTTON_A3 A3
/* Segment byte maps for numbers 0 to 9 , A, b , C*/
const byte SEGMENT_MAP[] = {0x3F,0x06,0x5b,0x4F,0x66,0x6D,0x7D,0x27,0X7F,0X67,0X77,0x7c,0x39,0X5e,0x79,0x71};

/* Byte maps to select digit 1 to 4 */
const byte SEGMENT_SELECT[] = {0xFE,0xFD,0xFB,0xF7};
void setup ()
{
/* Set DIO pins to outputs */
pinMode(LATCH_DIO,OUTPUT);
pinMode(CLK_DIO,OUTPUT);
pinMode(DATA_DIO,OUTPUT);
}
/* Main program */
void loop()
{
/* Update the display with the current counter value */
if(!digitalRead(BUTTON1) || !digitalRead(BUTTON2) || !digitalRead(BUTTON3) || !digitalRead(BUTTON4))
{
  while(1)
  {
    WriteNumberToSegment(3 , 1);
    delay(2);
    WriteNumberToSegment(2 ,2);
    delay(2);
    WriteNumberToSegment(1 , 0);
    delay(2);
    WriteNumberToSegment(0 , 2);
    delay(2);
  }  
}
}

/* Write a decimal number between 0 and 9 to one of the 4 digits of the display */
void WriteNumberToSegment(byte Segment, byte Value)
{
digitalWrite(LATCH_DIO,LOW);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_MAP[Value]);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_SELECT[Segment] );
digitalWrite(LATCH_DIO,HIGH);
}
```
# Q2-3.ino
```C
/* Define shift register pins used for seven segment display */
#define LATCH_DIO D15   
#define CLK_DIO D14
#define DATA_DIO 2
#define BUTTON1 BT1
#define BUTTON2 BT2
#define BUTTON3 BT3
#define BUTTON4 BT4
#define BUTTON_A1 A1
#define BUTTON_A2 A2
#define BUTTON_A3 A3
/* Segment byte maps for numbers 0 to 9 , A, b , C*/
const byte SEGMENT_MAP[] = {0x3F,0x06,0x5b,0x4F,0x66,0x6D,0x7D,0x27,0X7F,0X67,0X77,0x7c,0x39,0X5e,0x79,0x71};

/* Byte maps to select digit 1 to 4 */
const byte SEGMENT_SELECT[] = {0xFE,0xFD,0xFB,0xF7};
void setup ()
{
/* Set DIO pins to outputs */
pinMode(LATCH_DIO,OUTPUT);
pinMode(CLK_DIO,OUTPUT);
pinMode(DATA_DIO,OUTPUT);
}
/* Main program */
int cnt=0;
char databuf[]={SEGMENT_MAP[8], 0x00, 0x0, 0x0};
void shiftbuf(char *buf, int len)
{
  char temp=*(buf+len-1);
  for(int i=0; i<len-1; i++)
    *(buf+len-1-i) = *(buf+len-2-i);
  buf[0]=temp;   
}
void loop()
{
/* Update the display with the current counter value */
    unsigned long starttime=millis();
    while((millis()-starttime<500))
    {
      WriteNumberToSegment(0, databuf[3]);
      delay(2);
      WriteNumberToSegment(1, databuf[2]);
      delay(2);
      WriteNumberToSegment(2, databuf[1]);
      delay(2);
      WriteNumberToSegment(3, databuf[0]);
      delay(2);  
    }
    shiftbuf(databuf, 4);
}
/* Write a decimal number between 0 and 9 to one of the 4 digits of the display */
void WriteNumberToSegment(byte Segment, byte Value)
{
digitalWrite(LATCH_DIO,LOW);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, Value);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_SELECT[Segment] );
digitalWrite(LATCH_DIO,HIGH);
}
```
