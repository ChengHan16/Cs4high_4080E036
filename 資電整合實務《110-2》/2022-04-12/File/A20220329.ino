void setup() {
  Serial.begin(9600);
  pinMode(13,OUTPUT);
}

int LED_on_off = 0;

void loop() {
  UART_check();
  delay(100);
}

void UART_check()
{
  while (Serial.available()>=6)
  {
    char c=Serial.read();
    if (c==0x02)
    {
      char data_in[5];
      int i;
      for (i=0;i<5;i++)
        data_in[i]=Serial.read();

      char chk_sum=0x02;
      for (i=0;i<4;i++)
        chk_sum=chk_sum^data_in[i];
    
      
      if (data_in[4]==chk_sum)
      {
        if (data_in[0]=='L')
        {
          if ((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='0'))
          {  LED_on_off=0; digitalWrite(13,LOW);Serial.print("AL000B");}
          else if((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='1'))
          {  LED_on_off=1; digitalWrite(13,HIGH);Serial.print("AL001B");}
        }
      }
    }        
  }
}
