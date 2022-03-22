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
    data_trans(0,'E');
    //return;
  } 
  else
  {
    int data_t=h*10;
    data_trans(data_t,'H');
    delay(150);
    data_t=t*10;
    data_trans(data_t,'T');
  }
  delay(150);
  unsigned int light_in = analogRead(A0);
  //Serial.println(light_in);
  if (light_in > 999)
    light_in = 999;
  data_trans(light_in,'L');
}

void data_trans(int data_o,char func)
{ data[0]='A';  data[1]=func;
  data[2]=(data_o/100)+0x30;
  data[3]=((data_o/10)%10)+0x30;
  data[4]=(data_o%10)+0x30;
  char chk_sum=0x00;
  for (int i=0;i<5;i++)
    chk_sum=chk_sum^data[i];
    
  data[5]=chk_sum;
  
  Serial.print(data);
}
```
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
        private SerialPort serialport;
        char[] inbyte = new char[200];// Make an array for storaging the characters from UART
        int flag = 0;
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            List<string> listports = new List<string>(ports);
            comboBox1.Items.AddRange(listports.ToArray());

            timer1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            chart1.ChartAreas[0].AxisY.Interval = 10;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart2.ChartAreas[0].AxisY.Interval = 100;
            chart2.ChartAreas[0].AxisY.Maximum = 1000;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
        }

        void serialport_datareceived(object sender, SerialDataReceivedEventArgs e)
        {

            if (serialport.BytesToRead >= 6)
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
            pictureBox1.Image = Resource1.A;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialport.Write("F");
            label2.Text = "Turn Off";
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource1.B;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialport.Write("B");
            label2.Text = "Blicking";
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource1.C;                        
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
            }
            /* more word */
            if (flag >= 6)
            {                          
                string news0 = new String(inbyte);                        
                textBox1.Text = textBox1.Text + news0;

                byte chk_sum = 0x00;
                for (i = 0; i < 5; i++)
                    chk_sum ^= Convert.ToByte(inbyte[i]);

                if ((inbyte[0] == 'A') && (inbyte[5] == chk_sum))
                {
                    char[] inbyte0 = new char[3];
                    for (i = 0; i < 3; i++)
                        inbyte0[i] = inbyte[i + 2];

                    string news1 = new String(inbyte0);
                    label2.ForeColor = Color.Black; label3.ForeColor = Color.Black;
                    if (inbyte[1] == 'E')
                    {
                        //label2.Text = "Error"; label3.Text = "Error";  
                        //label2.BackColor = Color.Red; label3.BackColor = Color.Red;
                        label2.ForeColor = Color.Red; label3.ForeColor = Color.Red;
                    }
                    else if (inbyte[1]=='H')
                    {
                        label2.Text = (Convert.ToInt16(news1) / 10.0).ToString();
                        chart1.Series[0].Points.Add(Convert.ToInt16(news1) / 10.0);
                    }
                    else if (inbyte[1] == 'T')
                    {
                        label3.Text = (Convert.ToInt16(news1) / 10.0).ToString();
                        chart1.Series[1].Points.Add(Convert.ToInt16(news1) / 10.0);
                    }
                    else if (inbyte[1] == 'L')
                    {
                        label7.Text = Convert.ToInt16(news1).ToString();
                        chart2.Series[0].Points.Add(Convert.ToInt16(news1));
                        if (Convert.ToInt16(news1) > 900)
                        {
                            pictureBox1.Image = Resource1.Black;
                        }
                        else if (Convert.ToInt16(news1) <900 && Convert.ToInt16(news1) > 850)
                        {
                            pictureBox1.Image = Resource1.Low;
                        }
                        else if (Convert.ToInt16(news1) <850)
                        {
                            pictureBox1.Image = Resource1.high;
                        }
                    }
                }                

                for (i = 0; i < 200;i++ )
                {
                    inbyte[i] = Convert.ToChar(0x00);
                }
                    flag = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            serialport.Close();
            comboBox1.Text = "";
            label5.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = comboBox1.SelectedItem.ToString();

            serialport = new SerialPort(comboBox1.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One); //Initialize the setting of UART
            serialport.ReadBufferSize = 1000;
            serialport.Open();
            timer1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
```
## C# Code 優化
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
        private SerialPort serialport;
        char[] inbyte = new char[200];// Make an array for storaging the characters from UART
        int flag = 0;
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            List<string> listports = new List<string>(ports);
            comboBox1.Items.AddRange(listports.ToArray());

            timer1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            chart1.ChartAreas[0].AxisY.Interval = 10;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart2.ChartAreas[0].AxisY.Interval = 100;
            chart2.ChartAreas[0].AxisY.Maximum = 1000;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
        }

        void serialport_datareceived(object sender, SerialDataReceivedEventArgs e)
        {

            if (serialport.BytesToRead >= 6)
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
            pictureBox1.Image = Resource1.A;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialport.Write("F");
            label2.Text = "Turn Off";
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource1.B;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialport.Write("B");
            label2.Text = "Blicking";
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource1.C;                        
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
            }
            /* more word */
            if (flag >= 6)
            {                          
                string news0 = new String(inbyte);                        
                textBox1.Text = textBox1.Text + news0;

                byte chk_sum = 0x00;
                for (i = 0; i < 5; i++)
                    chk_sum ^= Convert.ToByte(inbyte[i]);

                if ((inbyte[0] == 'A') && (inbyte[5] == chk_sum))
                {
                    char[] inbyte0 = new char[3];
                    for (i = 0; i < 3; i++)
                        inbyte0[i] = inbyte[i + 2];

                    string news1 = new String(inbyte0);
                    label2.ForeColor = Color.Black; label3.ForeColor = Color.Black;
                    if (inbyte[1] == 'E')
                    {
                        //label2.Text = "Error"; label3.Text = "Error";  
                        //label2.BackColor = Color.Red; label3.BackColor = Color.Red;
                        label2.ForeColor = Color.Red; label3.ForeColor = Color.Red;
                    }
                    else if (inbyte[1]=='H')
                    {
                        label2.Text = (Convert.ToInt16(news1) / 10.0).ToString();
                        chart1.Series[0].Points.Add(Convert.ToInt16(news1) / 10.0);
                    }
                    else if (inbyte[1] == 'T')
                    {
                        label3.Text = (Convert.ToInt16(news1) / 10.0).ToString();
                        chart1.Series[1].Points.Add(Convert.ToInt16(news1) / 10.0);
                    }
                    else if (inbyte[1] == 'L')
                    {
                        Int16 Light_vaule = Convert.ToInt16(news1);
                        label7.Text = Convert.ToInt16(news1).ToString();

                        chart2.Series[0].Points.Add(Light_vaule);
                        if (Light_vaule > 900)
                        {
                            pictureBox1.Image = Resource1.Black;
                        }
                        else if (Light_vaule < 850)
                        {
                            pictureBox1.Image = Resource1.high;
                        }
                        else
                        {
                            pictureBox1.Image = Resource1.Low;
                        }
                    }
                }                

                for (i = 0; i < 200;i++ )
                {
                    inbyte[i] = Convert.ToChar(0x00);
                }
                    flag = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            serialport.Close();
            comboBox1.Text = "";
            label5.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = comboBox1.SelectedItem.ToString();

            serialport = new SerialPort(comboBox1.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One); //Initialize the setting of UART
            serialport.ReadBufferSize = 1000;
            serialport.Open();
            timer1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
```
### Result
![image](https://user-images.githubusercontent.com/55220866/159404794-c3f9af93-3028-4aae-a63e-c44a013bf3d6.png)
