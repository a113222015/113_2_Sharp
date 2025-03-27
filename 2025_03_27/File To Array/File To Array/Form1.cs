using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_To_Array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getValuesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 建立一個陣列來存放從檔案中讀取的項目。這裡假設檔案中有5個整數。
                const int SIZE = 5;
                int[] numbers = new int[SIZE];

                // 用於迴圈的計數變數，從0開始。
                int index = 0;

                // 宣告一個 StreamReader 變數，用來讀取檔案。
                StreamReader inputFile;

                // 開啟檔案並取得 StreamReader 物件，這裡假設檔案名稱為 "Values.txt"。
                inputFile = File.OpenText("Values.txt");

                // 將檔案的內容讀取到陣列中，直到讀取完檔案或陣列填滿為止。
                while (index < numbers.Length && !inputFile.EndOfStream)
                {
                    // 讀取檔案中的每一行，並將其轉換為整數後存入陣列中。
                    numbers[index] = int.Parse(inputFile.ReadLine());
                    index++;
                }

                // 讀取完畢後關閉檔案。
                inputFile.Close();

                // 在列表框中顯示陣列中的每個元素。
                foreach (int value in numbers)
                {
                    outputListBox.Items.Add(value);
                }
            }
            catch (Exception ex)
            {
                // 如果發生錯誤，顯示錯誤訊息。
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}

