```C
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ComponentModel.Composition;
using Itri.Vmx.Host;
using Itri.Vmx.Cnc;

namespace SampleApp
{
    [Export(typeof(IVmxApp))]

    public partial class Form1 : Form,IVmxApp
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string AppName
        {
            get { return "SampleAPP"; }
        }

        public Image Image
        {
            get { return null; }
        }

        CncAdaptor cnc;
        public bool Initialize(IVmxHost host)
        {
            cnc = host.CncAdaptors[0];
            return true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrUpdate.Start();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            DataItem progItem = new DataItem();
            progItem.Path = "/Controller/Program";
            cnc.ReadDataItem(ref progItem);
            string prog = progItem.Value.ToString();
            txbProg.Text = prog.ToString();

            DataItem cyctime = new DataItem();
            cyctime.Path = "/Controller/CycleTime";
            cnc.ReadDataItem(ref cyctime);
            TimeSpan cycleTime;
            TimeSpan.TryParse(cyctime.Value.ToString(), out cycleTime);
            txbCyc.Text = cycleTime.ToString();

            DataItem feedItem = new DataItem();
            feedItem.Path = "/Controller/FeedRate";
            cnc.ReadDataItem(ref feedItem);
            string feed = feedItem.Value.ToString();
            txbFeed.Text = feed;

            DataItem speedItem = new DataItem();
            speedItem.Path = "/Spindle/ActualSpeedList";
            cnc.ReadDataItem(ref speedItem);
            Array speed = speedItem.Value as Array;
            string SpdSpeed = speed.GetValue(0).ToString();
            txbSpeed.Text = SpdSpeed;

            DataItem mposItem = new DataItem();
            mposItem.Path = "/Axes/MachineryPositions";
            cnc.ReadDataItem(ref mposItem);
            double[] mpos = mposItem.Value as double[];
            txbXPos.Text = mpos[0].ToString();
            txbYPos.Text = mpos[1].ToString();
            txbZPos.Text = mpos[2].ToString();

            //設定儲存路徑
            string fileName = "C:\\cnc.csv";
            //把所有 string 資料都串起來，中間用逗號分隔，最後補上換行符號
            string content = txbCyc.Text.ToString() + "," + txbXPos.Text.ToString() + "," + txbYPos.Text.ToString() + "," + txbFeed.Text.ToString() + "," + txbSpeed.Text.ToString() + "\r\n";
            //把資料寫入檔案
            System.IO.File.AppendAllText(fileName, content);
        }
    }
}
```
