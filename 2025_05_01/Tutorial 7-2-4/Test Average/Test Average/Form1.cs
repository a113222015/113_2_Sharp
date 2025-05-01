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
        // 用於儲存測試分數的清單
        private List<int> testScores = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        // 計算平均分數的方法
        // 接受一個 List<int> 作為參數，並返回該清單的平均值
        private double Average(List<int> scores)
        {
            int total = 0; // 紀錄總分數
            foreach (int score in scores)
            {
                total += score; // 將每個分數加到總分數中
            }
            return (double)total / scores.Count; // 返回平均值
        }

        // 找出最高分數的方法
        // 接受一個 List<int> 作為參數，並返回該清單中的最高值
        private int Highest(List<int> scores)
        {
            int highest = scores[0]; // 假設第一個分數為最高分數
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i]; // 更新最高分數
                }
            }
            return highest; // 返回最高分數
        }

        // 找出最低分數的方法
        // 接受一個 List<int> 作為參數，並返回該清單中的最低值
        private int Lowest(List<int> scores)
        {
            int lowest = scores[0]; // 假設第一個分數為最低分數
            foreach (int score in scores)
            {
                if (score < lowest)
                {
                    lowest = score; // 更新最低分數
                }
            }
            return lowest; // 返回最低分數
        }

        // 取得分數按鈕的事件處理方法
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 顯示檔案選擇對話框
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 開啟選擇的檔案
                    StreamReader inputFile = File.OpenText(openFile.FileName);

                    // 清空 ListBox 和分數清單
                    testScoresListBox.Items.Clear();
                    testScores.Clear();

                    // 讀取檔案中的每一行，並將分數加入清單和 ListBox
                    while (!inputFile.EndOfStream)
                    {
                        int score = int.Parse(inputFile.ReadLine());
                        testScores.Add(score);
                        testScoresListBox.Items.Add(score);
                    }
                    inputFile.Close(); // 關閉檔案

                    // 計算並顯示平均分數、最高分數和最低分數
                    averageScoreLabel.Text = Average(testScores).ToString("n1");
                    highScoreLabel.Text = Highest(testScores).ToString();
                    lowScoreLabel.Text = Lowest(testScores).ToString();
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        // 退出按鈕的事件處理方法
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // 關閉表單
        }

        // 排序按鈕的事件處理方法
        private void sortButton_Click(object sender, EventArgs e)
        {
            // 清空排序後的 ListBox
            sortedScoresListBox.Items.Clear();

            // 將分數清單複製並排序
            List<int> sortedScores = new List<int>(testScores);
            sortedScores.Sort();

            // 將排序後的分數顯示在 ListBox 中
            foreach (int score in sortedScores)
            {
                sortedScoresListBox.Items.Add(score);
            }
        }

        // 刪除按鈕的事件處理方法
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 確認是否有選擇項目
            if (testScoresListBox.SelectedIndex != -1)
            {
                // 取得選中的索引
                int selectedIndex = testScoresListBox.SelectedIndex;

                // 從分數清單中移除該索引位置的分數
                testScores.RemoveAt(selectedIndex);

                // 更新 ListBox
                testScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    testScoresListBox.Items.Add(score);
                }

                // 更新排序後的 ListBox
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
                    // 如果清單為空，清空顯示的分數
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

        // 插入按鈕的事件處理方法
        private void insertButton_Click(object sender, EventArgs e)
        {
            // 驗證輸入的值和位置是否為有效數字
            if (int.TryParse(insertValueTextBox.Text, out int value) && int.TryParse(insertPositionTextBox.Text, out int position))
            {
                // 確保插入位置在有效範圍內
                if (position >= 0 && position <= testScores.Count)
                {
                    // 在指定位置插入分數
                    testScores.Insert(position, value);

                    // 更新 ListBox
                    testScoresListBox.Items.Clear();
                    foreach (int score in testScores)
                    {
                        testScoresListBox.Items.Add(score);
                    }

                    // 更新平均分數、最高分數和最低分數
                    averageScoreLabel.Text = Average(testScores).ToString("n1");
                    highScoreLabel.Text = Highest(testScores).ToString();
                    lowScoreLabel.Text = Lowest(testScores).ToString();
                }
                else
                {
                    // 如果位置無效，顯示錯誤訊息
                    MessageBox.Show("插入位置無效，請輸入有效的索引範圍。");
                }
            }
            else
            {
                // 如果輸入的值或位置無效，顯示錯誤訊息
                MessageBox.Show("請輸入有效的數字。");
            }
        }
    }
}
