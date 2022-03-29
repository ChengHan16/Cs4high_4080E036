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
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            chart1.ChartAreas[0].AxisY.Interval = 10;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
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

                }                

                for (i = 0; i < 200;i++ )
                {
                    inbyte[i] = Convert.ToChar(0x00);
                }
                    flag = 0;
            }
        }
    }
}
