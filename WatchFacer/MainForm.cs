﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchFacer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitUI();
            pnl_editor.AllowDrop = true;
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            string helpText =
                "RGB+50% Reduction:\r\n\r\nAdjust the minimum, maximum and in-between intensity of the \r\n" +
                "red, green and blue channels according to individual threshold parameters." +
                "A value of 0.5 means that the channel is split at its mid-intensity level." +
                "\r\n\r\n" +
                "Dithering + RGB space quantization:\r\n\r\nIt keep trying to fix the noise while trying to\r\n" +
                "optimize the colors of the image on RGB space." +
                "\r\n\r\n" +
                "Dithering + sRGB space quantization:\r\n\r\nIt keep trying to fix the noise while trying to\r\n" +
                "optimize the colors of the image on sRGB space." +
                "\r\n\r\n" +
                "Dithering + LAB space quantization:\r\n\r\nIt keep trying to fix the noise while trying to\r\n" +
                "optimize the colors of the image on LAB space." +
                "\r\n\r\n" +
                "\r\n\r\n" +
                "\r\n\r\n" +
                "Generally, \r\n"+
                "RGB is used on generic screens.Colors looks like oversaturated.\r\n"+
                "sRGB is used on stock PACE watchfaces while colors seems more natural\r\n" +
                "LAB is rarely used.It seems to be useful on images with landspaces."+
                "Pace's colors are using a color gamut.More infos here\r\nhttps://en.wikipedia.org/wiki/Gamut";
            MessageBox.Show(helpText, "Explanation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void rb_analog_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_analog.Checked)
            {
                tab_type.TabPages.Remove(tab_digital);
                tab_type.TabPages.Insert(1,tab_analog);
            } else
            {
                tab_type.TabPages.Remove(tab_analog);
                tab_type.TabPages.Insert(1,tab_digital);
            }
          
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e) {
            switch (((ComboBox)sender).Name.ToString()) {
                case "cb_hours":
                    pb_hours.Image = Image.FromFile(ResourcesAnalog_Hours + ((ComboBox)sender).Items[((ComboBox)sender).SelectedIndex]);
                    pb_hours.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    break;
                case "cb_minutes":
                    pb_minutes.Image = Image.FromFile(ResourcesAnalog_Minutes + ((ComboBox)sender).Items[((ComboBox)sender).SelectedIndex]);
                    pb_minutes.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    break;
                case "cb_seconds":
                    pb_seconds.Image = Image.FromFile(ResourcesAnalog_Seconds + ((ComboBox)sender).Items[((ComboBox)sender).SelectedIndex]);
                    pb_seconds.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    break;
                case "cb_markers":
                    pb_markers.Image = Image.FromFile(ResourcesAnalog_Markers + ((ComboBox)sender).Items[((ComboBox)sender).SelectedIndex]);
                    break;
            }
        }

        private void tb_transparency_Scroll(object sender, EventArgs e)
        {
            pb_markers.BackColor = Color.FromArgb(tbr_transparency.Value * 10, Color.Gray);
        }

        private void nud_dayofweekX_ValueChanged(object sender, EventArgs e)
        {
            if (cb_dayofweek.Checked)
            {
                pb_wDay.Location = new Point((int)nud_dayofweekX.Value, (int)nud_dayofweekY.Value);
            }
        }

        private void cb_dayofweek_CheckedChanged(object sender, EventArgs e)
        {
            pb_wDay.Visible = cb_dayofweek.Checked;

        }

        private void pb_markers_MouseDown(object sender, MouseEventArgs e)
        {
            Image tmp = pb_markers.Image;
            if (tmp == null) return;
            if (DoDragDrop(tmp, DragDropEffects.Move) == DragDropEffects.Move)
            {
               // Success. needed in order to register to img to our stacks
            }
        }

        private void pnl_editor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        
        private void pnl_editor_DragDrop(object sender, DragEventArgs e)
        {
            if (pnl_editor.Controls.Contains(p_marker))
            { 
                pnl_editor.Controls.Remove(p_marker);
                p_marker = new PictureBox(); // reinit avoiding memory leak
            }
            
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);

            p_marker.Size = new Size(320, 320);
            pnl_editor.Controls.Add(p_marker);
            p_marker.Location = new Point(0, 0);
            p_marker.BackColor = Color.Transparent;
            p_marker.Image = bmp;
        }
    }
}
