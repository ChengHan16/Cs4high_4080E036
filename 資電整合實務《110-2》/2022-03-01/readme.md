
### Button + Lable + Timer
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

namespace KSU4080E036
{
    public partial class Form1 : Form
    {
        UInt16 times_value = 0;

        public Form1()
        {
            InitializeComponent();  //初始化，需要有介面才會出現
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            lab_Status.Text = "Hi";
            timer1.Enabled = true;
        }

        private void btn_Off_Click(object sender, EventArgs e)
        {
            lab_Status.Text = "Bye";
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            times_value++;
            textBox1.Text = Convert.ToString(times_value/10.0);  //也可以寫成 textBox1.Text = times_value.ToString();
        }
    }
}
```
![image](https://user-images.githubusercontent.com/55220866/156094602-dde35b2d-7a0c-40b0-acd6-b1481b2ced19.png)
### Visual Studio + Arduino
```C
void setup() {  
  pinMode(13,OUTPUT);
  Serial.begin(9600);
}

char c_rev;
unsigned int LED_times=0;
int LED_status=1;

void loop() {
  if (Serial.available()>0)  
  {
    c_rev=Serial.read();
    
    if (c_rev=='N')
    {
      digitalWrite(13,HIGH);
      LED_status=0;Serial.print("N");
    }
    else if(c_rev=='F')
    {
      digitalWrite(13,LOW);    
      LED_status=0;Serial.print("F");
    }
    else if(c_rev=='B')
    { 
      LED_times=0;Serial.print("B");     
      LED_status=1;
    }
  }

  if (LED_status==1)
    LED_Blink();
    
  delay(25);
}

void LED_Blink()
{
  if (LED_times<20)
  {
    digitalWrite(13,HIGH);
    LED_times++;
  }
  else if(LED_times<40)
  {
    digitalWrite(13,LOW);
    LED_times++;
  }
  else
    LED_times=0;  
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

namespace KSU4080E036Version2
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
            if (serialport.BytesToRead >= 1)
            {
                flag = serialport.BytesToRead;
                serialport.Read(inbyte, 0, serialport.BytesToRead);
            }
            serialport.DiscardInBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialport.Write("N");
            label3.Text = "Turn On";
            serialport.DiscardOutBuffer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialport.Write("F");
            label3.Text = "Turn Off";
            serialport.DiscardOutBuffer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialport.Write("B");
            label3.Text = "Blinking";
            serialport.DiscardOutBuffer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            serialport.DataReceived += new SerialDataReceivedEventHandler(serialport_datareceived);            
            /* one word */
            if (flag >= 1)
            {
                textBox1.Text = textBox1.Text + Convert.ToString(inbyte[0]);                
                flag = 0;

                if (inbyte[0]=='N')
                    label4.Text = "Turn On";
                else if (inbyte[0] == 'F')
                    label4.Text = "Turn Off";
                else if (inbyte[0] == 'B')
                    label4.Text = "Blinking";
            }
            /* more word */
            /*if (flag >= 1)
            {
                textBox1.Clear();                
                string news0 = new String(inbyte);
                textBox1.Text = news0;
                textBox3.Text = textBox3.Text + news0;
                if ((inbyte[0] > 0x30) && (inbyte[0] <= 0x39))
                {
                    textBox2.Clear();
                    textBox2.Text = news0;
                }

                if (inbyte[0] == 0x43)
                    textBox3.Clear();

                for (i = 0; i < 200;i++ )
                {
                    inbyte[i] = Convert.ToChar(0x00);
                }
                    flag = 0;
            }*/
        }
    }
}
```
![image](https://user-images.githubusercontent.com/55220866/156101664-12ac454f-a520-465f-854a-aecceb743bb9.png)
![image](https://user-images.githubusercontent.com/55220866/156101683-a480bb5c-69d1-4307-b605-a547fec5c21b.png)

