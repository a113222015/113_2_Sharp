using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program6_10
{
    public partial class Form1 : Form
    {

        Random rand = new Random();
        string compChoice, myChoice, winner;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)//程式載入時執行
        {
            getCompChoice();
        }

        private void getCompChoice()
        {
            int n = rand.Next(1, 4);
            switch (n)
            {
               
                case 1:
                    compChoice = "石頭";
                    break;
                case 2:
                    compChoice = "布";
                    break;
                case 3:
                    compChoice = "剪刀";
                    break;
                    
            }
        }

        private void showWinner()
        {
            if(myChoice == compChoice)
                winner = "平手!";
            else if (myChoice == "石頭" && compChoice == "剪刀")
                winner = "玩家贏!";
            else if (myChoice == "布" && compChoice == "石頭")
                winner = "玩家贏!";
            else if (myChoice == "剪刀" && compChoice == "布")
                winner = "玩家贏!";
            else
            {
                winner = "電腦贏!";

                label1.Text = "電腦出: " + compChoice + "玩家出: " + myChoice + "\n" + winner;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myChoice = "石頭";
            showWinner();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myChoice = "布";
            showWinner();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myChoice = "剪刀";
            showWinner();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getCompChoice();
            label1.Text = ""; 
        }


    }
}
