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

namespace Test_Average
{
    public partial class Form1 : Form
    {
        private List<int> testScores = new List<int>(); // 用於存放分數的清單

        public Form1()
        {
            InitializeComponent();
            this.Text = "測試平均";
            getScoresButton.Text = "取得分數";
            exitButton.Text = "退出";
            deleteButton.Text = "刪除";
        }

        // Average 方法接受一個 List<int> 參數並返回該清單中值的平均值。
        // 使用 LINQ 的 Average 方法計算平均值。
        private double Average(List<int> scores)
        {
            return scores.Average();
        }

        // Highest 方法接受一個 List<int> 參數並返回該清單中的最高值。
        // 使用 LINQ 的 Max 方法找到最高值。
        private int Highest(List<int> scores)
        {
            return scores.Max();
        }

        // Lowest 方法接受一個 List<int> 參數並返回該清單中的最低值。
        // 使用 LINQ 的 Min 方法找到最低值。
        private int Lowest(List<int> scores)
        {
            return scores.Min();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            testScores.Clear(); // 清空清單以避免重複添加分數
            testScoresListBox.Items.Clear(); // 清空 ListBox 的顯示內容

            StreamReader inputFile; // 宣告 StreamReader 物件

            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 打開選擇的檔案。
                    inputFile = File.OpenText(openFile.FileName);

                    // 從檔案中讀取分數，直到檔案結束。
                    while (!inputFile.EndOfStream)
                    {
                        int score = Convert.ToInt32(inputFile.ReadLine());
                        testScores.Add(score);
                        testScoresListBox.Items.Add(score); // 將分數顯示在 ListBox 中
                    }

                    // 關閉檔案。
                    inputFile.Close();
                }
            }
            catch (Exception ex)
            {
                // 處理例外情況，顯示錯誤訊息。
                MessageBox.Show("發生錯誤: " + ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 確認使用者是否有選擇項目
            if (testScoresListBox.SelectedIndex != -1)
            {
                // 取得使用者選擇的分數
                int selectedScore = (int)testScoresListBox.SelectedItem;

                // 從 testScores 清單中移除該分數
                testScores.Remove(selectedScore);

                // 更新 testScoresListBox 的顯示內容
                testScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    testScoresListBox.Items.Add(score);
                }

                // 更新 sortedScoresListBox 的顯示內容
                testScoresListBox.Items.Clear();
                List<int> sortedScores = testScores.OrderBy(s => s).ToList();
                foreach (int score in sortedScores)
                {
                    testScoresListBox.Items.Add(score);
                }
            }
            else
            {
                // 如果沒有選擇項目，顯示提示訊息
                MessageBox.Show("請選擇要刪除的成績。");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
