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
            string data_out = ((char)0x02).ToString() + "L" + "100";
            char[] charArr = data_out.ToCharArray();
            for (i = 0; i < 5; i++)
                chk_sum ^= Convert.ToByte(charArr[i]);
            label7.Text = "Blinking";
            serialport.Write(data_out + ((char)chk_sum).ToString());
            serialport.DiscardOutBuffer();
            textBox1.Clear();
            hScrollBar1.Value = 0;
            pictureBox1.Image = Resource1.C;                        
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
                        
                        double value2 = Convert.ToInt32(news1);
                        value2 = value2 / 1024.0 * 5.0;
                        label5.Text = value2.ToString("0.000");

                        int ix = chart2.Series[0].Points.AddXY(x_index, value2);
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
    }
}
