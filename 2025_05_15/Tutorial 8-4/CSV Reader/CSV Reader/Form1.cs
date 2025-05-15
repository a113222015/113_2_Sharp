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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 當使用者點擊「取得分數」按鈕時執行此方法。
        /// 此方法會顯示檔案選擇對話方塊，讓使用者選擇CSV檔案，
        /// 並嘗試開啟該檔案進行後續處理。
        /// </summary>
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile;
                string line;
                int count = 0;// 計算分數的數量
                int total = 0;// 計算分數的總和
                double average;// 計算平均分數

                char[]delim = { ',',' ' };// 定義分隔符號為逗號

                // 顯示檔案開啟對話方塊，讓使用者選擇CSV檔案
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 以唯讀方式開啟使用者所選擇的檔案
                    inputFile = File.OpenText(openFile.FileName);

                    while (!inputFile.EndOfStream)
                    {
                        // 讀取每一行資料
                        line = inputFile.ReadLine();
                        line = line.Trim();// 去除行首行尾的空白字元
                        string[] tokens = line.Split(delim);// 以逗號分隔資料
                        total = 0;// 重置總和為0
                        // 將分數轉換為整數並累加
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            total += int.Parse(tokens[i]);// 將字串轉換為整數
                        }
                         
                        average = (double)total / tokens.Length;// 計算平均分數
                        // 將平均分數加入列表框中顯示
                        averagesListBox.Items.Add("第" + (++count) + "位同學的平均分數為:" + average.ToString("F2"));
                    }
                }
                else
                {
                    // 若使用者未選擇檔案，顯示提示訊息
                    MessageBox.Show("未選擇任何檔案。");
                }
            }
            catch (Exception ex)
            {
                // 若開啟檔案時發生錯誤，顯示錯誤訊息
                MessageBox.Show("開啟檔案時發生錯誤：" + ex.Message);
            }
        }

        /// <summary>
        /// 當使用者點擊「離開」按鈕時執行此方法。
        /// 此方法會關閉目前的表單，結束程式執行。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的表單，結束程式
            this.Close();
        }
    }
}
