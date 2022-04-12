#include "DHT.h"

#define DHTPIN 4     // Digital pin connected to the DHT sensor
// Feather HUZZAH ESP8266 note: use pins 3, 4, 5, 12, 13 or 14 --
// Pin 15 can work but DHT must be disconnected during program upload.

// Uncomment whatever type you're using!
//#define DHTTYPE DHT11   // DHT 11
#define DHTTYPE DHT22   // DHT 22  (AM2302), AM2321
//#define DHTTYPE DHT21   // DHT 21 (AM2301)

// Connect pin 1 (on the left) of the sensor to +5V
// NOTE: If using a board with 3.3V logic like an Arduino Due connect pin 1
// to 3.3V instead of 5V!
// Connect pin 2 of the sensor to whatever your DHTPIN is
// Connect pin 3 (on the right) of the sensor to GROUND (if your sensor has 3 pins)
// Connect pin 4 (on the right) of the sensor to GROUND and leave the pin 3 EMPTY (if your sensor has 4 pins)
// Connect a 10K resistor from pin 2 (data) to pin 1 (power) of the sensor

DHT dht(DHTPIN, DHTTYPE);

void setup() {
  Serial.begin(9600);
  pinMode(5,OUTPUT);
  dht.begin();
}

char data[6]={0x02,0x00,0x00,0x00,0x00,0x00};

void T_H_sensing()
{
  float h = dht.readHumidity();
  // Read temperature as Celsius (the default)
  float t = dht.readTemperature();
  // Read temperature as Fahrenheit (isFahrenheit = true)
  //float f = dht.readTemperature(true);

  // Check if any reads failed and exit early (to try again).
  if (isnan(h) || isnan(t)){
    data_trans(0,'E');delay(150);
    //return;
  } 
  else
  {
    int data_t=h*10;
    data_trans(data_t,'H');
    delay(150);
    data_t=t*10;
    data_trans(data_t,'T');
    delay(150);
  }
}

void PHR_sensing()
{
  unsigned int light_in=analogRead(A0);
  //Serial.println(light_in);
  if (light_in>999)
    light_in=999;
  data_trans(light_in,'L');
  delay(150);
}

void loop() {
  delay(2000);
  T_H_sensing();
  PHR_sensing();

  UART_check();
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
          {  digitalWrite(5,LOW);}
          else if((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='1'))
          {  digitalWrite(5,HIGH);}
        }
      }
    }        
  }
}

void data_trans(int data_o,char func)
{ data[0]=0x02;  data[1]=func;
  data[2]=(data_o/100)+0x30;
  data[3]=((data_o/10)%10)+0x30;
  data[4]=(data_o%10)+0x30;
  char chk_sum=0x00;
  for (int i=0;i<5;i++)
    chk_sum=chk_sum^data[i];
    
  data[5]=chk_sum;
  
  Serial.print(data);
}
