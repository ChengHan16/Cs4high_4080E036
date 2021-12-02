## 1.超音波偵測
```C
#include <hcsr04.h>

#define TRIG_PIN 12
#define ECHO_PIN 13
HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.println(hcsr04.ToString());
  delay(250);
}
```
## 或是 1-2.超音波偵測
```C
#include <hcsr04.h>

#define TRIG_PIN 12
#define ECHO_PIN 13
HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.println(hcsr04.distanceInMillimeters());
  delay(250);
}
```
## 2.超音波 Link LED燈閃爍
```C
#include <hcsr04.h>

#define TRIG_PIN 12
#define ECHO_PIN 13
HCSR04 hcsr04(TRIG_PIN, ECHO_PIN, 20, 4000);
const int ledPin = 9;

void setup() {
  Serial.begin(9600);
  pinMode (ledPin,OUTPUT); 
}

void loop() {
  Serial.println(hcsr04.distanceInMillimeters());
  if(hcsr04.distanceInMillimeters() > 100){
    digitalWrite(ledPin,HIGH);
  }
  else{
    digitalWrite(ledPin,LOW);
  }
  delay(250);
}
```
