using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Card
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getCardButton_Click(object sender, EventArgs e)
        {
            // Create a Random object.
            Random rand = new Random();

            // Get a random index.
            int index = rand.Next(cardImageList.Images.Count);

            // Display a card.
            cardPictureBox.Image = cardImageList.Images[index];
        }
    }
}
