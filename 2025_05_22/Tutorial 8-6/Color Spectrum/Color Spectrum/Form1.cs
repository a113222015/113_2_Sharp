using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Spectrum
{
    enum Spectrum 
    { 
        Red, Orange, Yellow, Green,
        Blue, Indigo, Violet 
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The DisplayColor method displays the
        // name of a color.
        private void DisplayColor(Spectrum color)
        {
            string colorName = "";
            switch (color)
            {
                case Spectrum.Red:
                    colorName = "紅色";
                    break;
                case Spectrum.Orange:
                    colorName = "橙色";
                    break;
                case Spectrum.Yellow:
                    colorName = "黃色";
                    break;
                case Spectrum.Green:
                    colorName = "綠色";
                    break;
                case Spectrum.Blue:
                    colorName = "藍色";
                    break;
                case Spectrum.Indigo:
                    colorName = "靛色";
                    break;
                case Spectrum.Violet:
                    colorName = "紫色";
                    break;
            }
            colorLabel.Text = colorName;
        }

        private void redLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Red);
        }

        private void orangeLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Orange);
        }

        private void yellowLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Yellow);
        }

        private void greenLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Green);
        }

        private void blueLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Blue);
        }

        private void indigoLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Indigo);
        }

        private void violetLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Violet);
        }
    }
}
