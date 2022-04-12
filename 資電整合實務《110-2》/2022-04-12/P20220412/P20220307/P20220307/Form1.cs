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
            hScrollBar1.Enabled = false;

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
            string data_out = ((char)0x02).ToString() + "L" + "001";
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            label7.Text = "Turn On";
            serialport.Write(data_out + ((char)chk_sum).ToString());            
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource1.A;
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
            pictureBox1.Image = Resource1.B;
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
            
            /* more word */
            if (flag >= 6)
            {
                string news0 = new String(inbyte);
                textBox1.Text = textBox1.Text + news0;

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
                        //label2.Text = "Error"; label3.Text = "Error";  
                        //label2.BackColor = Color.Red; label3.BackColor = Color.Red;
                        label2.ForeColor = Color.Red; label3.ForeColor = Color.Red;
                    }
                    else if (inbyte[1] == 'H')
                    {
                        label2.Text = (Convert.ToInt16(news1) / 10.0).ToString();
                        label2.ForeColor = Color.Black; label3.ForeColor = Color.Black;
                        chart1.Series[0].Points.Add(Convert.ToInt16(news1) / 10.0);
                    }
                    else if (inbyte[1] == 'T')
                    {
                        label3.Text = (Convert.ToInt16(news1) / 10.0).ToString();
                        label2.ForeColor = Color.Black; label3.ForeColor = Color.Black;
                        chart1.Series[1].Points.Add(Convert.ToInt16(news1) / 10.0);
                    }
                    else if (inbyte[1] == 'L')
                    {
                        label5.Text = (Convert.ToInt16(news1)).ToString();
                        chart1.Series[0].Points.Add(Convert.ToInt16(news1));
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
            timer1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            hScrollBar1.Enabled = false;
            serialport.Close();
            comboBox1.Text = "";            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            serialport = new SerialPort(comboBox1.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One); //Initialize the setting of UART
            serialport.ReadBufferSize = 1000;
            serialport.Open();
            serialport.DiscardInBuffer();
            timer1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            hScrollBar1.Enabled = true;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //label2.Text = hScrollBar1.Value.ToString();
            byte chk_sum = 0x00;
            string data_out = ((char)0x02).ToString() + "H" + "00" + hScrollBar1.Value.ToString();
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            label7.Text = "Level : " + hScrollBar1.Value.ToString();
            serialport.Write(data_out + ((char)chk_sum).ToString());
            serialport.DiscardOutBuffer();
        }
    }
}
