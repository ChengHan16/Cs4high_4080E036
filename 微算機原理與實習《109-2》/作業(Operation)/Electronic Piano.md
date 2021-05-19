```C
#include <LiquidCrystal.h>
#define Do ((unsigned int) 262)
#define Re ((unsigned int) 294)
#define Mi ((unsigned int) 330)
#define Fa ((unsigned int) 349)
#define Sol ((unsigned int) 392)
#define La_H ((unsigned int) 440)
#define Si_H ((unsigned int) 494)
#define Do_H ((unsigned int) 523)

LiquidCrystal lcd(8, 9, 4, 5, 6, 7);
const char BTN[] = {A0, A1, A2, A3, D10, D11, D12, D13};
char* keyNames[] = {"Do", "Re", "Mi", "Fa", "Sol", "La_H", "Si_H", "Do_H"};

void setup() {
  lcd.begin(16, 2);

  for (int i = 0; i < 4; i++) {
    pinMode(BTN[i], OUTPUT);
  }
  
  for (int i = 4; i < 8; i++) {
    pinMode(BTN[i], INPUT);
  }
}

void loop() {
  for (int i = 0; i < 2; i++) {
    digitalWrite(BTN[i], LOW);
    for (int j = 4; j < 8; j++) {
      int columState = !digitalRead(BTN[j]);
      if (columState) {
        while (!digitalRead(BTN[j])) {
          int charIndex = (j-4) + i * 2;
          printNoteName(keyNames[charIndex]);
        }
        lcd.clear();
      }
    }
    digitalWrite(BTN[i], HIGH);
  }
}

void printNoteName(char* noteName) {
  lcd.clear();
  lcd.print(noteName);
}

void playNote(int OutputPin, unsigned int Note, unsigned long duration) {
  tone(OutputPin, Note, duration);
  delay(duration*1.1);
  noTone(OutputPin);
}
```
# 自分の
```C
#define Fa ((unsigned int) 349)
#define Sol ((unsigned int) 392)
#define La_H ((unsigned int) 440)
#define Si_H ((unsigned int) 494)
#define Do_H ((unsigned int) 523)
unsigned int KeyValue[]={Do, Sol, Re, La_H, Mi, Si_H, Fa, Do_H};
byte Row=0, Col=0;
void playNote(int OutputPin, unsigned int Note, unsigned long duration) {
tone(OutputPin, Note, duration);
delay(duration*1.1);
noTone(OutputPin);
}
void setup() {
// put your setup code here, to run once:
pinMode(10, INPUT);
pinMode(11, INPUT_PULLUP);
pinMode(12, INPUT_PULLUP);
pinMode(13, INPUT_PULLUP);
pinMode(A0, OUTPUT);
pinMode(A1, OUTPUT);
pinMode(A2, OUTPUT);
pinMode(A3, OUTPUT);
digitalWrite(A0,HIGH);
digitalWrite(A1,HIGH);
digitalWrite(A2,HIGH);
digitalWrite(A3,HIGH);
}
Electronic Piano
void loop() {
static int keypressedcount=0;
byte keyindex=0;
if(keyscan()==true)
{
keyindex=(Row-1)*2+Col-1;
delay(5);
if ((keyscan()==true) && (keyindex==(Row-1)*2+Col-1))
{
playNote(D3, KeyValue[keyindex], 300);
}
}
buttonState1 = digitalRead(10);
buttonState2 = digitalRead(11);
buttonState3 = digitalRead(12);
buttonState4 = digitalRead(13);
if(buttonState1 == LOW){
lcd.clear();
lcd.print("Do");
delay(delay_number);
}
else if (buttonState1 == LOW){
lcd.clear();
lcd.print("Re");
delay(delay_number);
}
else if (buttonState1 == LOW){
lcd.clear();
lcd.print("Mi");
delay(delay_number);
}
else if (buttonState1 == LOW){
lcd.clear();
lcd.print("Fa");
delay(delay_number);
}
else if (buttonState2 == LOW){
lcd.clear();
Electronic Piano
lcd.print("Sol");
delay(delay_number);
}
else if (buttonState2 == LOW){
lcd.clear();
lcd.print("La_H");
delay(delay_number);
}
else if (buttonState2 == LOW){
lcd.clear();
lcd.print("Si_H");
delay(delay_number);
}
else if (buttonState2 == LOW){
lcd.clear();
lcd.print("Do_H");
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
Electronic Piano
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
Electronic Piano
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
return(false);
}
```
