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
        public Form1()
        {
            InitializeComponent();
            this.Text = "測試平均";
            getScoresButton.Text = "取得分數";
            exitButton.Text = "退出";
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
            List<int> testScores = new List<int>(); // 初始化一個 List<int> 來存放分數
            int highestScore = 0; // 初始化最高分數變數
            int lowestScore = 0; // 初始化最低分數變數
            double averageScore = 0.0; // 初始化平均分數變數
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
                        testScores.Add(Convert.ToInt32(inputFile.ReadLine()));
                    }

                    // 關閉檔案。
                    inputFile.Close();

                    // 計算平均分數、最高分數和最低分數。
                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);

                    // 在訊息框中顯示結果。
                    MessageBox.Show("平均: " + averageScore.ToString("n2") +
                        "\n最高: " + highestScore +
                        "\n最低: " + lowestScore);
                }
            }
            catch (Exception ex)
            {
                // 處理例外情況，顯示錯誤訊息。
                MessageBox.Show("發生錯誤: " + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
