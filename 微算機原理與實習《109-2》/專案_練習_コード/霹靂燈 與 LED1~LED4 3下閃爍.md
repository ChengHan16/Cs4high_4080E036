# 霹靂燈 與 LED1~LED4 3下閃爍
# `PILI.ino` + `LEDD1_D4FLASH.ino`
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

    pinMode(LED1, OUTPUT);
    for(int i=26; i<30; i++) //LED1->26，LED4->29
    {
      pinMode(i,  OUTPUT);
      digitalWrite(i, LOW);
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
