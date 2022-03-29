
```C
//void UART_check();

void setup() {
  Serial.begin(9600);
  pinMode(13, OUTPUT);
}

  int LED_on_off = 0;
  
void loop() {
  UART_check();
  delay(100);
}

void UART_check(){
  if(Serial.available() >= 6){
    char c=Serial.read();
    if(c=='A'){
      char data_in[5];
      for (int i=0; i<5; i++)
        data_in[i]=Serial.read();

      if (data_in[4]=='B'){
        if (data_in[0]=='L'){
          if ((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='0')){
              LED_on_off = 0; digitalWrite(13, LOW);
          }
          else if((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='1')){
              LED_on_off = 1; digitalWrite(13, HIGH);
          }
        }
      }
    }
  }
}
```
