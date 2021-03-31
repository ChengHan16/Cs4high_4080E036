### (1)請將學號末四碼同時顯示於七段顯示器上，英文字母若不在A~F範園內請以A代替，
### (2)學號由右逐一往左移進入七段顯示器，重複不斷顯示，例如4080E012，依以下順序顯示 4， 40, 408, 4080, 080E, 80E0, 0E01, E012, 0124, 1240........
### (3)類似前一小題，學號顯示由左方依序往右顯示，如以下順序2 , 12 ,012 ,E012, 0E01, 80E0, 080E, 4080, 2408, .....以上題目請說明附上程式碼及說明， 成果則以照片說明，

### 請注意(2)(3)必須附上足以說明顯示移動方向的照片，請以PDF檔繳交。
___
## 更改範本
```C
/* Define shift register pins used for seven segment display */
/*https://swf.com.tw/?p=715*/
#define LATCH_DIO D15   
#define CLK_DIO D14
#define DATA_DIO D2
#define BUTTON1 BT1
#define BUTTON2 BT2
#define BUTTON3 BT3
#define BUTTON4 BT4
#define BUTTON_A1 A1
#define BUTTON_A2 A2
#define BUTTON_A3 A3
/* Segment byte maps for numbers 0 to 9 , A, b , C*/
//const byte SEGMENT_MAP[] = {0x3F,0x06,0x3C,0x4F,0x66,0x6D,0x7D,0x07,0X7F,0X6F,0X77,0X7C,0X39};
/* Segment byte maps for numbers 0 to 9 , A, b , C, d, E, F*/
const byte SEGMENT_MAP[] = {0x3F,0x06,0x5b,0x4F,0x66,0x6D,0x7D,0x27,0X7F,0X67,0X77,0x7c,0x39,0X5e,0x79,0x71};
/* Byte maps to select digit 1 to 4 */
const byte SEGMENT_SELECT[] = {0xFE,0xFD,0xFB,0xF7};
byte displaybuf[4];
void bufshift(byte dir, byte databyte)//dir=0:shift left, dir=1:shift right
{
  if(dir == 0)
  {
    for (int j=0; j<3; j++)
    {
      displaybuf[3-j]=displaybuf[3-j-1];
    }
    displaybuf[0]=databyte;
  }
  else
  {
    for (int j=0; j<3; j++)
    {
      displaybuf[j]=displaybuf[j+1];
    }
    displaybuf[3]=databyte;
  }
}
void setup ()
{
/* Set DIO pins to outputs */
Serial.begin(115200);
pinMode(LATCH_DIO,OUTPUT);
pinMode(CLK_DIO,OUTPUT);
pinMode(DATA_DIO,OUTPUT);
//clear data display buffer
for(int i=0; i<4; i++)
  displaybuf[i]=0;
}
byte cnt=0; 
/* Main program */
void loop()
{
  bufshift(0, SEGMENT_MAP[cnt++]);
  for(int i=0; i<4; i++)
  {
      Serial.print(displaybuf[3-i], HEX); Serial.print("\t");
  }
  Serial.println();
  unsigned long starttime=millis();
  while((millis()-starttime)<500)
     show7seg();
  cnt %= 8;
}
//code from https://www.arduino.cc/reference/en/language/functions/advanced-io/shiftout/
void shiftOut(uint8_t dataPin, uint8_t clockPin, uint8_t bitOrder, uint8_t val)
{
  uint8_t i;
  for (i = 0; i < 8; i++)  
  {
    if (bitOrder == LSBFIRST)
      digitalWrite(dataPin, !!(val & (1 << i)));
    else
      digitalWrite(dataPin, !!(val & (1 << (7 - i))));
    digitalWrite(clockPin, HIGH);
    digitalWrite(clockPin, LOW);
  }
}

/* Write a decimal number between 0 and 9 to one of the 4 digits of the display */
/*
void WriteNumberToSegment(byte Segment, byte Value)
{
digitalWrite(LATCH_DIO,LOW);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_MAP[Value]);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_SELECT[Segment] );
digitalWrite(LATCH_DIO,HIGH);
}*/
void WriteNumberToSegment(byte Segment, byte Value)
{
digitalWrite(LATCH_DIO,LOW);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, Value);
shiftOut(DATA_DIO, CLK_DIO, MSBFIRST, SEGMENT_SELECT[Segment] );
digitalWrite(LATCH_DIO,HIGH);
}
void show7seg()
{
  int i;
  for(i=0; i<4; i++)
  {
    WriteNumberToSegment(3-i, displaybuf[i]);
    delay(2);
  }
}
```
