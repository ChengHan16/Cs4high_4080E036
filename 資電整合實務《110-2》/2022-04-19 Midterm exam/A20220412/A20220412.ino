#include <DHT.h>

// Data output of Senser is connected to pin 4 of Arduino
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

// Flag the start sensing and transmit data
int start_flag=0;

void setup() {
  // UART beign with 9600 bps (boud rate)
  Serial.begin(9600);
  // Pin 5  as OUTPUT
  pinMode(5,OUTPUT);
  // Inital dht22 and start sensing
  dht.begin();
}

// Ceclare a recieve data character
char data[7];
// Ceclare a variable for the voltage of photoresistor 
unsigned int photores_value;

void Data_receive()
{
  // Make sure UART register has more than 6 characters
  while (Serial.available()>=6)
  {
    // Read 1 byte from the UART register, and check it is start byte or not
    char c = Serial.read();
    if (c==0x02)
    {
      // Read the 5 byte, after start byte, from the UART register
      char data_in[5];

      int i;
      for (i=0;i<5;i++)
        data_in[i]=Serial.read();

      // Generate the check sum byte from the recieved data
      char chk_sum=0x02;
        for (i=0;i<4;i++)
          chk_sum=chk_sum ^ data_in[i];

      // Make sure the check sum byte is matched    
      if (chk_sum==(data_in[4]))
      {
        // When the function byte is 「L」
        if (data_in[0]=='L')
        {
          // Control pin 5 on/off
          if ((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='0'))
          {  digitalWrite(5,LOW); }
          else if ((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='1'))
          {  digitalWrite(5,HIGH); }
        } 
         // When the function byte is 「H」
        else if (data_in[0]=='H')
        {
           // Control pin 5 in PWM mode
          int Bright=(data_in[3]-0x30);
          if ((Bright<=9)&&(Bright>=0))
            analogWrite(5,Bright*28);         
        } 
         // When the function byte is 「S」
        else if (data_in[0]=='S')
        {
          // Make start command status
          if ((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='0'))
            start_flag=1;    
          else if ((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='1'))
            start_flag=0;
        }   
        // Clean of data in UART register        
        Serial.flush();        
        break;
      }
    }
  }
}

void T_H_Sensing()
{
  // Get values from DHT22
  float t=dht.readTemperature();
  float h=dht.readHumidity();
  //Serial.print("Temperature:");Serial.println(t);
  //Serial.print("Humidity:");Serial.println(h);

  // Make sure the values of DHT22 are not NAN
  if ((isnan(t)==1)||(isnan(h)==1))  
  { 
    // Call subroutine to transmit Error information 
    UART_trans('E', 0); delay(150); 
  }
  else
  {
    // Call subroutine to transmit data
    UART_trans('H', h*10);
    delay(150);
    UART_trans('T', t*10);
    delay(150);
  }
}

void PHR_Sensing()
{
  // Get A/D value from A0 pin
  photores_value=analogRead(A0);
  //Serial.println();Serial.println(photores_value);

  // Make sure the value of A/D will not exceed 999 (3 digits)
  if (photores_value>999)
    photores_value=999;

  // Call subroutine to transmit data
  UART_trans('L', photores_value);
  delay(150);
}

// Flag for marking the times of delay 150ms
int delay150ms=0;

void loop() { 
  // Start sensing after getting the start command
  if (start_flag==1)
  {
    // Get data from DHT22 about every 2s
    if (delay150ms>=15)  
    {  
      T_H_Sensing(); 
      delay150ms=0;
    }
    else
      delay150ms++;
      
    PHR_Sensing();
  }
  
  Data_receive();  
}

void UART_trans(char func, int data_out)
{  
  // Start byte
  data[0]=0x02;
  // Function byte
  data[1]=func;
  // 3 bytes of number in character format (ASCII)
  data[2]=(data_out/100)+0x30;
  data[3]=((data_out/10)%10)+0x30;
  data[4]=(data_out%10)+0x30;

  // Generate the check sum byte
  char chk_sum=0x00;
  for (int i=0;i<5;i++)
    chk_sum=chk_sum ^ data[i];  
  data[5]=chk_sum;

  // Data transmit
  Serial.print(data);
}
