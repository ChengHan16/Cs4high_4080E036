### Image 圖片大小

|名字|介紹|  |
|--|--|--|
|0|	Normal|	影象被置於 System.Windows.Forms.PictureBox 的左上角。如果影象比包含它的 System.Windows.Forms.PictureBox 大，則該影象將被剪裁掉。|
|1|	StretchImage|	System.Windows.Forms.PictureBox 中的影象被拉伸或收縮，以適合 System.Windows.Forms.PictureBox的大小。|
|2|	AutoSize|	調整 System.Windows.Forms.PictureBox 大小，使其等於所包含的影象大小。|
|3|	CenterImage|	如果 System.Windows.Forms.PictureBox 比影象大，則影象將居中顯示。 <br> 如果影象比 System.Windows.Forms.PictureBox大，則圖片將居於 System.Windows.Forms.PictureBox 中心，而外邊緣將被剪裁掉。|
|4|	Zoom|	影象大小按其原有的大小比例被增加或減小。|

![image](https://user-images.githubusercontent.com/55220866/158300495-3864e258-f093-4a08-bab2-e06d43813f31.png)

```C#
public Form1()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resource2.Temp;   
        }
```
-----
### Chart
![image](https://user-images.githubusercontent.com/55220866/158300826-ff648b4d-6c09-4e76-9678-1a488d7c3090.png)
![image](https://user-images.githubusercontent.com/55220866/158301081-ca97b849-6055-4026-9bf2-04718ecdfa92.png)
-----
## Code
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
            pictureBox1.Image = Resource2.Temp;   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialport.Write("F");
            label2.Text = "Turn Off";
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource2.Hot;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialport.Write("B");
            label2.Text = "Blicking";
            serialport.DiscardOutBuffer();
            pictureBox1.Image = Resource2.Co;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            serialport.DataReceived += new SerialDataReceivedEventHandler(serialport_datareceived);

            /* more word */
            if (flag >= 6)
            {
                byte chk_sum = 0x00;
                for (i = 0; i < 5; i++)
                {
                    chk_sum ^= Convert.ToByte(inbyte[i]);
                }

                if ((inbyte[0] == 'A') && (chk_sum == inbyte[5]))
                {
                    char[] inbyte_new = new char[3];
                    for (i = 0; i < 3; i++)
                        inbyte_new[i] = inbyte[i + 2];
                    //string news0 = string.Convert<char>(inbyte_new);

                    string news0 = new String(inbyte_new);
                    //label2.BackColor = Color.Gray; label3.BackColor = Color.Gray;
                    label2.ForeColor = Color.Black; label3.ForeColor = Color.Black;

                    if (inbyte[1] == 'E')
                    {
                        label2.Text = "Error"; label3.Text = "Error";
                        //label2.BackColor = Color.Red; label3.BackColor = Color.Red;
                        label2.ForeColor = Color.Red; label3.ForeColor = Color.Red;
                    }

                    else if (inbyte[1] == 'H')
                    {
                        label2.Text = (Convert.ToInt16(news0) / 10.0).ToString();
                        textBox1.Text = textBox1.Text + news0;
                        chart1.Series[0].Points.Add(Convert.ToInt16(news0) / 10.0);
                    }
                    else if (inbyte[1] == 'T')
                    {
                        label3.Text = (Convert.ToInt16(news0) / 10.0).ToString();
                        textBox1.Text = textBox1.Text + news0;
                    }
                }

                /*textBox3.Text = textBox3.Text + news0;
                if ((inbyte[0] > 0x30) && (inbyte[0] <= 0x39))
                {
                    textBox2.Clear();
                    textBox2.Text = news0;
                }

                if (inbyte[0] == 0x43)
                    textBox3.Clear();*/

                for (i = 0; i < 200; i++)
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
## 參考資料
> https://www.itread01.com/content/1545288303.html
