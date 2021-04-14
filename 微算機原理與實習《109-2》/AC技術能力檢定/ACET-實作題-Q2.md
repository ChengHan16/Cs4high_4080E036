# 𝖂 [04-14]()
## Q2-2.ino 七段顯示器 數字往左/右移
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
  //WriteNumberToSegment(3-j,i); //改左移，右移直接放j
  delay(100);
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
## Q2-3.ino 七段顯示器照按鍵 1、2、3、4 往右顯示移動
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
char databuf[]={0x00, 0x00, 0x0, 0x0};
void shiftbuf(char *buf, byte data)
{
  for(int i=0 ; i<3 ; i++){
    *(buf+i) = *(buf+i+1);
  }
  *(buf+3) = data;
}
void loop()
{
/* Update the display with the current counter value */
    unsigned long starttime=millis();
    while((millis()-starttime<100))
    {
      WriteNumberToSegment(0, databuf[0]);
      delay(2);
      WriteNumberToSegment(1, databuf[1]);
      delay(2);
      WriteNumberToSegment(2, databuf[2]);
      delay(2);
      WriteNumberToSegment(3, databuf[3]);
      delay(2);  
    }
    if(!digitalRead(BUTTON1)){
      shiftbuf(databuf,SEGMENT_MAP[1]);
    }
    if(!digitalRead(BUTTON2)){
      shiftbuf(databuf,SEGMENT_MAP[2]);
    }
    if(!digitalRead(BUTTON3)){
      shiftbuf(databuf,SEGMENT_MAP[3]);
    }
    if(!digitalRead(BUTTON4)){
      shiftbuf(databuf,SEGMENT_MAP[4]);
    }
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
