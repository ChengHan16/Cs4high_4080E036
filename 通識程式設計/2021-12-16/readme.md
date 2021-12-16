### 蜂鳴器 (小蜜蜂)
```c
#define Do  523
#define Re  587
#define Mi  659
#define Fa  698
#define So  784
#define La  880
#define Si  988
//int melody[7] = {Do, Re, Mi, Fa, So, La, Si};
int melody[] = {So, Mi, Mi, Fa, Re, Re, Do, Re, Mi, Fa, So, So, Do};
int beat[] = {1,1,2,1,1,2,1,1,1,1,1,1,4};
const int buzzer = 9;
void setup(){
  pinMode(buzzer, OUTPUT);
}
void loop() {  
  for (int i = 0;i < 13; i++) {
    tone(buzzer, melody[i]);
    delay(beat[i]*250); 
    //delay(1000);  
  }
  noTone(buzzer);//不發出聲音
  delay(2000);
}
```
> http://172.20.247.236/
