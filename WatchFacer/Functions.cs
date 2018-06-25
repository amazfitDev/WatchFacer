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

namespace WatchFacer
{
    public partial class Form1 : Form
    {
        string Resources = Directory.GetCurrentDirectory() + "\\_Resources\\";
        void InitUI()
        {
            MaximizeBox = false;
            Size = new Size(800, 600);
            Text = "WatchFacer - 1.0";
            CenterToScreen();
            Icon = new Icon(Resources + "icon.ico");
            pnl_mask.BackgroundImage = Image.FromFile(Resources + "pace.png");
           
        }
    }
   
}
