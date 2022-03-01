
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
