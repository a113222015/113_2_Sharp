using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5; // Number of lottery numbers to generate
            int []lotteryNumbers =  new int[SIZE]; // Maximum number for the lottery numbers
            Random random = new Random();
           
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                int number;
                do
                {
                    number = random.Next(1, 43); // Generate a random number between 1 and 100
                } while (lotteryNumbers.Contains(number)); // Ensure the number is unique
           lotteryNumbers[i] = number; // Store the unique number in the array
            }

            //將lotteryNumbers陣列中的數字由小到大排序
            Array.Sort(lotteryNumbers);
       
        Label[] showlabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };
            for (int i = 0; i < showlabels.Length; i++)
            {
                showlabels[i].Text = lotteryNumbers[i].ToString(); // Display the generated numbers in the labels
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
