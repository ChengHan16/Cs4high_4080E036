## Arduino
```C
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
int delaytime = 500;
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

int LED_status=0;

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
          LED_status=0;
          // Control pin 5 on/off
          if ((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='0'))
          {  digitalWrite(5,LOW); }
          else if ((data_in[1]=='0')&&(data_in[2]=='0')&&(data_in[3]=='1'))
          {  digitalWrite(5,HIGH); }
        } 
        else if(data_in[0] == 'B'){
            LED_status=1;
        }
        
         // When the function byte is 「H」
        else if (data_in[0]=='H')
        {
          LED_status=0;
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
    else{
      delay150ms++;
      if (LED_status == 1){
        digitalWrite(5,HIGH);
        if (delay150ms>=8){
         digitalWrite(5,LOW);
        }
      }
    }
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
```
## Visual Studio
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
        Int64 x_index0 = 0;
        Int64 x_index = 0;
        int pointMax0 = 10;
        int pointMax = 100;

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
            hScrollBar1.Enabled = false;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY2.Maximum = 50;
            chart1.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = pointMax0;

            chart2.ChartAreas[0].AxisY.Maximum = 5;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = pointMax;

            label2.Text = "None";
            label3.Text = "None";
            label6.Text = "None";
            label7.Text = "Turn Off";
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
            byte chk_sum = 0x00;
            string data_out = ((char)0x02).ToString() + "L" + "001";
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            label7.Text = "Turn On";
            serialport.Write(data_out + ((char)chk_sum).ToString());            
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource1.A;
            hScrollBar1.Value = 9;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte chk_sum = 0x00;
            string data_out = ((char)0x02).ToString() + "L" + "000";
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            label7.Text = "Turn Off";
            serialport.Write(data_out + ((char)chk_sum).ToString());            
            serialport.DiscardOutBuffer();

            hScrollBar1.Value = 0;
            pictureBox1.Image = Resource1.B;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte chk_sum = 0x00;
            string data_out = ((char)0x02).ToString() + "B" + "002";
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            label7.Text = "Blinking";
            serialport.Write(data_out + ((char)chk_sum).ToString());
            serialport.DiscardOutBuffer();

            hScrollBar1.Value = 0;
            pictureBox1.Image = Resource1.B;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            serialport.DataReceived += new SerialDataReceivedEventHandler(serialport_datareceived);
            
            /* more word */
            if (flag >= 6)
            {
                string news0 = new String(inbyte);
                //textBox1.Text = textBox1.Text + news0;

                byte chk_sum = 0x00;
                for (i = 0; i < 5; i++)
                    chk_sum ^= Convert.ToByte(inbyte[i]);

                if ((inbyte[0] == 0x02) && (inbyte[5] == chk_sum))
                {
                    char[] inbyte0 = new char[3];
                    for (i = 0; i < 3; i++)
                        inbyte0[i] = inbyte[i + 2];

                    string news1 = new String(inbyte0);
                    
                    if (inbyte[1] == 'E')
                    {
                        //label2.BackColor = Color.Red; label3.BackColor = Color.Red;
                        label2.ForeColor = Color.Red; label3.ForeColor = Color.Red;
                    }
                    else if (inbyte[1] == 'H')
                    {                        
                        label2.ForeColor = Color.Black;
                        double value0 = Convert.ToInt32(news1) / 10.0;
                        label2.Text = value0.ToString("0.0");
                        chart1.Series[0].Points.AddXY(x_index0,value0);                        
                    }
                    else if (inbyte[1] == 'T')
                    {                      
                        label3.ForeColor = Color.Black;
                        double value1 = Convert.ToInt32(news1) / 10.0;
                        label3.Text = value1.ToString("0.0");
                        //chart1.Series[1].Points.AddY(value1);

                        int ix0 = chart1.Series[1].Points.AddXY(x_index0, value1);
                        x_index0++;
                        if (ix0 > pointMax0)
                        {
                            // Auto-Shift without scroll bar
                            chart1.ChartAreas[0].AxisX.Maximum = chart1.Series[1].Points[ix0].XValue;
                            chart1.ChartAreas[0].AxisX.Minimum += chart1.Series[1].Points[ix0].XValue - chart1.Series[1].Points[ix0 - 1].XValue;
                            chart1.ChartAreas[0].RecalculateAxesScale();

                            /*// Auto-Shift with scroll bar
                            chart2.ChartAreas[0].AxisX.Minimum = double.NaN;
                            chart2.ChartAreas[0].AxisX.Maximum = double.NaN;
                            chart2.ChartAreas[0].RecalculateAxesScale();
                            chart2.ChartAreas[0].AxisX.ScaleView.Zoom(chart2.Series[0].Points[ix - pointMax].XValue, chart2.Series[0].Points[ix].XValue);
                            */
                        }
                    }
                    else if (inbyte[1] == 'L')
                    {
                        Int16 Light_vaule = Convert.ToInt16(news1);
                        double value2 = Convert.ToInt32(news1);
                        double value3 = Math.Round((value2 * 5 / 1024), 2);

                        label8.Text = value3.ToString() + "V";
                        label5.Text = value2.ToString();

                        int ix = chart2.Series[0].Points.AddXY(x_index, value3);
                        x_index++;
                        if (ix > pointMax)
                        {
                            // Auto-Shift without scroll bar
                            chart2.ChartAreas[0].AxisX.Maximum = chart2.Series[0].Points[ix].XValue;
                            chart2.ChartAreas[0].AxisX.Minimum += chart2.Series[0].Points[ix].XValue - chart2.Series[0].Points[ix - 1].XValue;
                            chart2.ChartAreas[0].RecalculateAxesScale();

                            /*// Auto-Shift with scroll bar
                            chart2.ChartAreas[0].AxisX.Minimum = double.NaN;
                            chart2.ChartAreas[0].AxisX.Maximum = double.NaN;
                            chart2.ChartAreas[0].RecalculateAxesScale();
                            chart2.ChartAreas[0].AxisX.ScaleView.Zoom(chart2.Series[0].Points[ix - pointMax].XValue, chart2.Series[0].Points[ix].XValue);
                            */
                        }
                        if (Convert.ToInt16(news1) > 830)
                        {
                            pictureBox1.Image = Resource1.L0;
                        }
                        else if (Convert.ToInt16(news1) < 830 && Convert.ToInt16(news1) > 760)
                        {
                            pictureBox1.Image = Resource1.L1;
                        }
                        else if (Convert.ToInt16(news1) < 760)
                        {
                            pictureBox1.Image = Resource1.L2;
                        }
                    }

                }

                for (i = 0; i < 200; i++)
                {
                    inbyte[i] = Convert.ToChar(0x00);
                }
                flag = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte chk_sum = 0x00;
            string data_out = ((char)0x02).ToString() + "S" + "001";
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            serialport.Write(data_out + ((char)chk_sum).ToString());
            serialport.DiscardOutBuffer();            

            timer1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            hScrollBar1.Enabled = false;
            comboBox1.Enabled = true;
            comboBox1.Text = "";

            serialport.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            serialport = new SerialPort(comboBox1.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One); //Initialize the setting of UART
            serialport.ReadBufferSize = 1000;
            serialport.Open();
            serialport.DiscardInBuffer();

            byte chk_sum = 0x00;
            string data_out = ((char)0x02).ToString() + "S" + "000";
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            serialport.Write(data_out + ((char)chk_sum).ToString());
            serialport.DiscardOutBuffer();

            timer1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            hScrollBar1.Enabled = true;
            comboBox1.Enabled = false;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {            
            byte chk_sum = 0x00;
            string data_out = ((char)0x02).ToString() + "H" + "00" + hScrollBar1.Value.ToString();
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            label7.Text = "Level:" + hScrollBar1.Value.ToString();
            serialport.Write(data_out + ((char)chk_sum).ToString());
            serialport.DiscardOutBuffer();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
```
![image](https://user-images.githubusercontent.com/55220866/163911533-4b677a7b-7958-4574-8759-5de41dc5fbb3.png)
![image](https://user-images.githubusercontent.com/55220866/163911566-82b771e7-1c7f-4c35-80ea-7d98c90d1a89.png)
![image](https://user-images.githubusercontent.com/55220866/163911588-44210170-3654-4678-9353-5cf4160e3541.png)
![image](https://user-images.githubusercontent.com/55220866/163913381-168c6e3c-9ec7-4ea8-9e11-444b03f4b680.png)
![image](https://user-images.githubusercontent.com/55220866/163913470-a4f6c5f4-0d40-4ab3-a409-7ff587892e9d.png)
![image](https://user-images.githubusercontent.com/55220866/163913489-9833ab74-3bc1-4d20-9d0b-39be72e02345.png)
![image](https://user-images.githubusercontent.com/55220866/163913571-df6dd718-01ec-44c9-b9a1-a319a10ef496.png)

![image](https://user-images.githubusercontent.com/55220866/163913639-c5acc683-ac4f-4c03-9cf6-fd45cc6614a6.png)
![image](https://user-images.githubusercontent.com/55220866/163913679-1ddb3a87-7efa-4359-b02e-15055add2ac3.png)
![image](https://user-images.githubusercontent.com/55220866/163913700-abb67701-abaf-45d2-8572-b3988e7b71a0.png)

