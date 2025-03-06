using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program5_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            StreamWriter outputFile;//宣告StreamWriter物件
            int count;//宣告整數變數
            try
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    outputFile = File.CreateText(saveFile.FileName);//開啟檔案，寫入數字
                    if (int.TryParse(textBox1.Text, out count))//判斷是否為數字
                    {
                        for (int i = 0; i < count; i++)
                        {
                            outputFile.WriteLine(rand.Next(100) + 1);//產生亂數
                        }
                        outputFile.Close();//關閉檔案
                        MessageBox.Show("檔案已建立");//顯示訊息
                    }
                    else
                    {
                        MessageBox.Show("請輸入數字");//顯示訊息
                    }
                }
                else 
                {
                    MessageBox.Show("你按下取消");//顯示訊息
                }

               

            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message);//顯示錯誤訊息
            }
           
          

        }
    }
}
