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
        private List<int> testScores = new List<int>(); // 儲存測試分數的清單

        public Form1()
        {
            InitializeComponent();
        }

        // Average 方法接受一個 List<int> 參數
        // 並返回該清單中所有值的平均值。
        private double Average(List<int> scores)
        {
            int total = 0;
            // 遍歷清單中的每個分數，並將其加到總和中
            foreach (int score in scores)
            {
                total += score;
            }
            // 返回總和除以分數數量的平均值
            return (double)total / scores.Count;
        }

        // Highest 方法接受一個 List<int> 參數
        // 並返回該清單中的最高值。
        private int Highest(List<int> scores)
        {
            int highest = scores[0];
            // 遍歷清單中的每個分數，並找出最高的分數
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            // 返回最高的分數
            return highest;
        }

        // Lowest 方法接受一個 List<int> 參數
        // 並返回該清單中的最低值。
        private int Lowest(List<int> scores)
        {
            int lowest = scores[0];
            // 遍歷清單中的每個分數，並找出最低的分數
            foreach (int score in scores)
            {
                if (score < lowest)
                {
                    lowest = score;
                }
            }
            // 返回最低的分數
            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            int highestScore = 0;
            int lowestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 打開文件。
                    inputFile = File.OpenText(openFile.FileName);
                    // 清空 ListBox 和清單。
                    testScoresListBox.Items.Clear();
                    testScores.Clear();
                    // 從文件中讀取測試分數。
                    while (!inputFile.EndOfStream)
                    {
                        int score = int.Parse(inputFile.ReadLine());
                        testScores.Add(score);
                        // 將分數添加到 ListBox 中。
                        testScoresListBox.Items.Add(score);
                    }
                    inputFile.Close();  // 關閉文件。
                                        // 計算平均分數、最高分數和最低分數。
                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);
                    // 顯示結果。
                    averageScoreLabel.Text = averageScore.ToString("n1");
                    highScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息。
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            sortedScoresListBox.Items.Clear(); // 清空排序後的 ListBox

            // 將分數排序
            List<int> sortedScores = new List<int>(testScores);
            sortedScores.Sort();

            // 將排序後的分數顯示在 ListBox 中
            foreach (int score in sortedScores)
            {
                sortedScoresListBox.Items.Add(score);
            }
        }

        //    private void deleteButton_Click(object sender, EventArgs e)
        //    {
        //        // 確認是否有選擇項目
        //        if (testScoresListBox.SelectedIndex != -1)
        //        {
        //            // 取得選中的分數
        //            int selectedScore = (int)testScoresListBox.SelectedItem;

        //            // 從清單中移除該分數
        //            testScores.Remove(selectedScore);

        //            // 更新 testScoresListBox
        //            testScoresListBox.Items.Clear();
        //            foreach (int score in testScores)
        //            {
        //                testScoresListBox.Items.Add(score);
        //            }

        //            // 更新 sortedScoresListBox
        //            sortedScoresListBox.Items.Clear();
        //            List<int> sortedScores = new List<int>(testScores);
        //            sortedScores.Sort();
        //            foreach (int score in sortedScores)
        //            {
        //                sortedScoresListBox.Items.Add(score);
        //            }

        //            // 更新平均分數、最高分數和最低分數
        //            if (testScores.Count > 0)
        //            {
        //                averageScoreLabel.Text = Average(testScores).ToString("n1");
        //                highScoreLabel.Text = Highest(testScores).ToString();
        //                lowScoreLabel.Text = Lowest(testScores).ToString();
        //            }
        //            else
        //            {
        //                averageScoreLabel.Text = string.Empty;
        //                highScoreLabel.Text = string.Empty;
        //                lowScoreLabel.Text = string.Empty;
        //            }
        //        }
        //        else
        //        {
        //            // 如果沒有選擇項目，顯示提示訊息
        //            MessageBox.Show("請選擇要刪除的分數。", "提示");
        //        }
        //    }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 確認是否有選擇項目
            if (testScoresListBox.SelectedIndex != -1)
            {
                // 取得選中的索引
                int selectedIndex = testScoresListBox.SelectedIndex;

                // 從清單中移除該索引位置的分數
                testScores.RemoveAt(selectedIndex);

                // 更新 testScoresListBox
                testScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    testScoresListBox.Items.Add(score);
                }

                // 更新 sortedScoresListBox
                sortedScoresListBox.Items.Clear();
                List<int> sortedScores = new List<int>(testScores);
                sortedScores.Sort();
                foreach (int score in sortedScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }

                // 更新平均分數、最高分數和最低分數
                if (testScores.Count > 0)
                {
                    averageScoreLabel.Text = Average(testScores).ToString("n1");
                    highScoreLabel.Text = Highest(testScores).ToString();
                    lowScoreLabel.Text = Lowest(testScores).ToString();
                }
                else
                {
                    averageScoreLabel.Text = string.Empty;
                    highScoreLabel.Text = string.Empty;
                    lowScoreLabel.Text = string.Empty;
                }
            }
            else
            {
                // 如果沒有選擇項目，顯示提示訊息
                MessageBox.Show("請選擇要刪除的分數。", "提示");
            }
        }

    }
}
