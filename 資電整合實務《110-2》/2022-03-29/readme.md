
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
## chk_sum
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
            string data_out = "A" + "L" + "001";
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            label1.Text = data_out + ((char)chk_sum).ToString();
            serialport.Write(data_out + ((char)chk_sum).ToString());
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource1.A;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte chk_sum = 0x00;
            string data_out = "A" + "L" + "000";
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            label1.Text = data_out + ((char)chk_sum).ToString();
            serialport.Write(data_out + ((char)chk_sum).ToString());
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource1.A;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialport.Write("B");
            serialport.DiscardOutBuffer();
            textBox1.Clear();
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
![image](https://user-images.githubusercontent.com/55220866/160527065-50454aef-6369-4b22-9c4d-4f73fbdf22f4.png)
