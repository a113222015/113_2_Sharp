using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program5_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader inputFile; //宣告StreamReader物件
            int sum = 0; //宣告變數sum用來存放總和
            int count = 0; //宣告變數count用來存放資料筆數
            int temp; //宣告變數temp用來存放讀到的資料
            try 
            {
                inputFile = File.OpenText("NUMBERS.txt"); //開啟檔案
                while (!inputFile.EndOfStream) //當沒有讀到檔案結尾時(代表檔案中還有資料)
                {
                    count++; //資料筆數加1
                    temp = int.Parse(inputFile.ReadLine()); //將讀到的資料轉換為整數並加總
                    sum += temp; //將讀到的資料轉換為整數並加總
                    listBox1.Items.Add(temp); //將讀到的資料加入listBox1
                }
                listBox1.Items.Add("總共有"+count+"個數字"); //將總和加入listBox1
                listBox1.Items.Add("總和為" + sum); //將總和加入listBox1
                inputFile.Close(); //關閉檔案
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            
        }
    }
}
