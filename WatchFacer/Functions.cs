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

        PictureBox pb_wDay = new PictureBox();
        void InitUI()
        {
            MaximizeBox = false;
            Size = new Size(800, 600);
            Text = "WatchFacer - 1.0";
            CenterToScreen();
            Icon = new Icon(Resources + "icon.ico");
            pnl_mask.BackgroundImage = Image.FromFile(Resources + "pace.png");

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

            pb_markers.SizeMode =
            pb_hours.SizeMode =
            pb_minutes.SizeMode =
            pb_seconds.SizeMode = PictureBoxSizeMode.StretchImage;

            AddToCB(ResourcesAnalog_Markers, cb_markers, pb_markers);
            AddToCB(ResourcesAnalog_Hours, cb_hours, pb_hours);
            AddToCB(ResourcesAnalog_Minutes, cb_minutes, pb_minutes);
            AddToCB(ResourcesAnalog_Seconds, cb_seconds, pb_seconds);

            pb_markers.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pb_hours.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pb_minutes.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pb_seconds.Image.RotateFlip(RotateFlipType.Rotate90FlipY);

            pb_wDay.Location = new Point(0, 0);
            pnl_editor.Controls.Add(pb_wDay);
            pb_wDay.Size = new Size(32, 21);
            pb_wDay.Image = Image.FromFile(ResourcesWidgets + "day.png");
            pb_wDay.Visible = false;

            pnl_x.BackgroundImage = Image.FromFile(Resources + "\\axesx.png");
            pnl_y.BackgroundImage = Image.FromFile(Resources + "\\axesy.png");

        }
       
        void AddToCB(string file,ComboBox cb, PictureBox pb)
        {
            string[] dirs = Directory.GetFiles(file);
            int i = 0;
            foreach (string dir in dirs)
            {
                int idx = dir.LastIndexOf('\\');
                dirs[i] = dir.Substring(idx + 1);
                cb.Items.Add(dirs[i]);
                i++;
            }
            cb.Text = cb.Items[0].ToString();
            pb.Image = Image.FromFile( file + dirs[0]);
        }
    }
   
}
