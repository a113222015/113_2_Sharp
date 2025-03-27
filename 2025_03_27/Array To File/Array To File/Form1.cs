using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Array_To_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 建立一個包含一些值的陣列。
                int[] numbers = { 10, 20, 30, 40, 50 };

                // 宣告一個 StreamWriter 變數。
                StreamWriter outputFile;

                // 建立檔案並取得一個 StreamWriter 物件。
                outputFile = File.CreateText("Values.txt");

                // 將陣列的內容寫入檔案。
               // for (int index = 0; index < numbers.Length; index++)
                //{
                   // outputFile.WriteLine(numbers[index]);
                //}
                foreach (int number in numbers)
                {
                    outputFile.WriteLine(number);
                }

                // 關閉檔案。
                outputFile.Close();

                // 讓使用者知道已完成。
                MessageBox.Show("完成");
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息。
                MessageBox.Show(ex.Message);
            }
        }
    }
}

