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
    public partial class MainForm : Form
    {
        string Resources = Directory.GetCurrentDirectory() + "\\_Resources\\";
		string ResourcesWidgets = Directory.GetCurrentDirectory() + "\\_Resources\\widgets\\";
        string ResourcesAnalog_Hours = Directory.GetCurrentDirectory() + "\\_Resources\\analog\\hours\\";
        string ResourcesAnalog_Minutes = Directory.GetCurrentDirectory() + "\\_Resources\\analog\\minutes\\";
        string ResourcesAnalog_Seconds = Directory.GetCurrentDirectory() + "\\_Resources\\analog\\seconds\\";
        string ResourcesAnalog_Markers = Directory.GetCurrentDirectory() + "\\_Resources\\analog\\markers\\";

        Color color;
        void InitUI()
        {
            MaximizeBox = false;
            Size = new Size(800, 600);
            Text = "WatchFacer - 1.0";
            CenterToScreen();
            Icon = new Icon(Resources + "icon.ico");
            pnl_mask.BackgroundImage = Image.FromFile(Resources + "pace.png");
            btn_color.BackColor = Color.Black;

            rb_analog.Checked = true;
            //Remove all tabs and rearrange them
            tab_type.TabPages.Remove(tab_analog);
            tab_type.TabPages.Remove(tab_digital);
            tab_type.TabPages.Add(tab_analog);

            cb_reduction.Text = "- Color reduction mode -";
            cb_reduction.Items.Add("RGB Channels + 50% threshold");
            cb_reduction.Items.Add("Dithering + RGB space quantization");
            cb_reduction.Items.Add("Dithering + sRGB space quantization");
            cb_reduction.Items.Add("Dithering + LAB space quantization");

        }
    }
   
}
