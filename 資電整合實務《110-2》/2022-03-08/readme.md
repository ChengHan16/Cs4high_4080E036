### DHT22 操作
```C
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
  dht.begin();
}

char data[6]={0x02,0x00,0x00,0x00,0x00,0x00};

void loop() {
  delay(2000);

  float h = dht.readHumidity();
  // Read temperature as Celsius (the default)
  float t = dht.readTemperature();
  // Read temperature as Fahrenheit (isFahrenheit = true)
  //float f = dht.readTemperature(true);

  // Check if any reads failed and exit early (to try again).
  if (isnan(h) || isnan(t)){
    Serial.println(F("Failed to read from DHT sensor!"));
    return;
  }

  // Compute heat index in Fahrenheit (the default)
  //float hif = dht.computeHeatIndex(f, h);
  // Compute heat index in Celsius (isFahreheit = false)
  //float hic = dht.computeHeatIndex(t, h, false);

  Serial.print(F("Humidity: "));
  Serial.print(h);
  Serial.print(F("%  Temperature: "));
  Serial.print(t);
  Serial.print(F("°C "));
  Serial.print("\n");

  /*int h0=h*10;
  data[1]='H';
  data[2]=(h0/100)+0x30;
  data[3]=((h0/10)%10)+0x30;
  data[4]=(h0%10)+0x30;

  char chk_sum=0x00;

  for (int i=0;i<5;i++)
    chk_sum=chk_sum^data[i];
    
  data[5]=chk_sum;
  
  Serial.print(data);*/
}
```
![image](https://user-images.githubusercontent.com/55220866/157151745-ab70114e-f86e-4e41-9c00-4c9fc2e7e864.png)
---
### DHT Humidity 值只顯示整數
```C
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
  dht.begin();
}

char data[6]={0x02,0x00,0x00,0x00,0x00,0x00};

void loop() {
  delay(2000);

  float h = dht.readHumidity();
  // Read temperature as Celsius (the default)
  float t = dht.readTemperature();
  // Read temperature as Fahrenheit (isFahrenheit = true)
  //float f = dht.readTemperature(true);

  // Check if any reads failed and exit early (to try again).
  if (isnan(h) || isnan(t)){
    Serial.println(F("Failed to read from DHT sensor!"));
    return;
  }

  // Compute heat index in Fahrenheit (the default)
  //float hif = dht.computeHeatIndex(f, h);
  // Compute heat index in Celsius (isFahreheit = false)
  //float hic = dht.computeHeatIndex(t, h, false);

  /*Serial.print(F("Humidity: "));
  Serial.print(h);
  Serial.print(F("%  Temperature: "));
  Serial.print(t);
  Serial.print(F("°C "));
  Serial.print("\n");*/
  int h0 = h*10;
  Serial.print(h0);

  /*int h0=h*10;
  data[1]='H';
  data[2]=(h0/100)+0x30;
  data[3]=((h0/10)%10)+0x30;
  data[4]=(h0%10)+0x30;

  char chk_sum=0x00;

  for (int i=0;i<5;i++)
    chk_sum=chk_sum^data[i];
    
  data[5]=chk_sum;
  
  Serial.print(data);*/
}
```
![image](https://user-images.githubusercontent.com/55220866/157153773-6ad17e44-3c26-48d8-82c7-f7d1128e63e6.png)
---
```C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.IO.Ports;


namespace P20220307
{
    public partial class Form1 : Form
    {
        private SerialPort serialport = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One); //Initialize the setting of UART
        char[] inbyte = new char[200];// Make an array for storaging the characters from UART
        int flag = 0;
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            serialport.ReadBufferSize = 1000;
            serialport.Open();
            timer1.Enabled = true;
        }

        void serialport_datareceived(object sender, SerialDataReceivedEventArgs e)
        {

            if (serialport.BytesToRead >= 3)
            {
                flag = serialport.BytesToRead;
                serialport.Read(inbyte, 0, serialport.BytesToRead);
                serialport.DiscardInBuffer();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialport.Write("N");
            label2.Text = "Turn On";
            serialport.DiscardOutBuffer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialport.Write("F");
            label2.Text = "Turn Off";
            serialport.DiscardOutBuffer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialport.Write("B");
            label2.Text = "Blicking";
            serialport.DiscardOutBuffer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            serialport.DataReceived += new SerialDataReceivedEventHandler(serialport_datareceived);
            /* one word */
            /*if (flag >= 1)
            {
                //textBox1.Text = textBox1.Text + Convert.ToString(inbyte[0]);
                flag = 0;

                if (inbyte[0] == 'N')
                    label3.Text = "Turn On";
                else if (inbyte[0] == 'F')
                    label3.Text = "Turn Off";
                else if (inbyte[0] == 'B')
                    label3.Text = "Blinking";
            }*/

            /* more word */
            if (flag >= 3)
            {              
                string news0 = new String(inbyte);
                label5.Text = news0;
                textBox1.Text = textBox1.Text + news0;

                /*textBox3.Text = textBox3.Text + news0;
                if ((inbyte[0] > 0x30) && (inbyte[0] <= 0x39))
                {
                    textBox2.Clear();
                    textBox2.Text = news0;
                }

                if (inbyte[0] == 0x43)
                    textBox3.Clear();*/

                for (i = 0; i < 200;i++ )
                {
                    inbyte[i] = Convert.ToChar(0x00);
                }
                    flag = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
```
