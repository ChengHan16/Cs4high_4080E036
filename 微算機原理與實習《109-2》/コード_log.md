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

const byte SEGMENT_MAP[] = {0x3F,0x06,0x5b,0x4F,0x66,0x6D,0x7D,0x27,0X7F,0X67,0X77,0x7c,0x39,0X5e,0x79,0x71};

const byte SEGMENT_SELECT[] = {0xFE,0xFD,0xFB,0xF7};

void setup() {               
  for(int i = 0; i < NUM; i++){
    pinMode(leds[i], OUTPUT);
    digitalWrite(leds[i], HIGH);
  }    

    pinMode(LED1, OUTPUT);
    for(int i=26; i<30; i++) //LED1->26，LED4->29
    {
      pinMode(i,  OUTPUT);
      digitalWrite(i, LOW);
    }
// 雖然A3、A2、A1、A0是類比腳位，
// 但也可以把它當做數位腳位使用。

// 然後是兩個迴圈，
// 第一個迴圈從IO0->IO15，
// 第二個迴圈跑IO14->IO0。

pinMode(LATCH_DIO,OUTPUT);
pinMode(CLK_DIO,OUTPUT);
pinMode(DATA_DIO,OUTPUT);

}
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

  for(int i=26; i<30; i++)
    for(int j=0; j<3; j++)
    {
      digitalWrite(i, HIGH);
      delay(700);
      digitalWrite(i, LOW);
      delay(300);
    }

    　　
　int = i;
  while(i<16)
  {
    WriteNumberToSegment(i%4 , i);
    i++;
    delay(1000);
  }
}
```
