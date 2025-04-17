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

        // Average 方法接受一個 int 陣列參數並返回該陣列中值的平均值。
        // 使用 LINQ 的 Average 方法計算平均值。
        private double Average(int[] scores)
        {
            return scores.Average();
        }

        // Highest 方法接受一個 int 陣列參數並返回該陣列中的最高值。
        // 使用 LINQ 的 Max 方法找到最高值。
        private int Highest(int[] scores)
        {
            return scores.Max();
        }

        // Lowest 方法接受一個 int 陣列參數並返回該陣列中的最低值。
        // 使用 LINQ 的 Min 方法找到最低值。
        private int Lowest(int[] scores)
        {
            return scores.Min();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48; // 定義陣列大小為 48
            int[] testScores = new int[SIZE]; // 初始化一個大小為 48 的 int 陣列
            int index = 0; // 初始化索引變數
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

                    // 從檔案中讀取分數，直到達到陣列大小或檔案結束。
                    while (index < SIZE && !inputFile.EndOfStream)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        index++;
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
