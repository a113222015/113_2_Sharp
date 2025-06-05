using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 使用 List<string> 來存放球隊與冠軍資料
        List<string> teamList = new List<string>();
        List<string> winnerList = new List<string>();

        // 儲存檔案路徑
        string teamsFilePath = "";
        string winnersFilePath = "";

        /// <summary>
        /// 表單載入事件，初始化並讀取球隊與冠軍資料
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 提示使用者先選擇球隊資料檔案
            MessageBox.Show("請先選擇球隊資料檔案（Teams.txt）。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!SelectFile(ref teamsFilePath, "請選擇球隊資料檔案（Teams.txt）"))
                return;

            // 選擇完球隊檔案後再提示選擇冠軍資料檔案
            MessageBox.Show("請選擇冠軍球隊資料檔案（WorldSeries.txt）。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!SelectFile(ref winnersFilePath, "請選擇冠軍資料檔案（WorldSeries.txt）"))
                return;

            readTeams();
            readWinner();
        }

        /// <summary>
        /// 顯示檔案選擇對話方塊，讓使用者選擇檔案
        /// </summary>
        /// <param name="filePath">選擇的檔案路徑</param>
        /// <param name="title">對話方塊標題</param>
        /// <returns>是否成功選擇檔案</returns>
        private bool SelectFile(ref string filePath, string title)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = title;
                ofd.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    return true;
                }
                else
                {
                    MessageBox.Show("未選擇檔案，程式將結束。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 讀取 Teams.txt 檔案，將所有球隊名稱加入 listBox1，並存入 teamList
        /// </summary>
        private void readTeams()
        {
            try
            {
                teamList.Clear();
                listBox1.Items.Clear();
                using (StreamReader inputFile = File.OpenText(teamsFilePath))
                {
                    string line;
                    // 逐行讀取 Teams.txt，將每一行加入 teamList 與 listBox1
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        teamList.Add(line);
                        listBox1.Items.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                // 發生例外時，顯示錯誤訊息（以繁體中文顯示）
                MessageBox.Show("讀取球隊資料時發生錯誤：" + ex.Message);
            }
        }

        /// <summary>
        /// 讀取 WorldSeries.txt 檔案，將每一年的冠軍球隊名稱存入 winnerList
        /// </summary>
        private void readWinner()
        {
            try
            {
                winnerList.Clear();
                using (StreamReader inputFile = File.OpenText(winnersFilePath))
                {
                    string line;
                    // 逐行讀取 WorldSeries.txt，將每一行加入 winnerList
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        winnerList.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                // 發生例外時，顯示錯誤訊息（以繁體中文顯示）
                MessageBox.Show("讀取冠軍資料時發生錯誤：" + ex.Message);
            }
        }

        /// <summary>
        /// 當使用者在 listBox1 選擇球隊時，計算該球隊奪冠次數並顯示於 label1，並列出奪冠年份
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            int numWin = 0;
            List<int> winYears = new List<int>();
            int startYear = 1903;
            int year = startYear;

            // 1904, 1994 年未舉辦世界大賽，需跳過
            HashSet<int> skipYears = new HashSet<int> { 1904, 1994 };

            for (int i = 0; i < winnerList.Count; i++)
            {
                // 跳過未舉辦的年份
                while (skipYears.Contains(year))
                {
                    year++;
                }
                if (str == winnerList[i])
                {
                    numWin++;
                    winYears.Add(year);
                }
                year++;
            }

            // 組合顯示訊息
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(str + " 從 1903 年到 2009 年共獲得 " + numWin + " 次世界大賽冠軍。");
            if (winYears.Count > 0)
            {
                sb.AppendLine("奪冠年份：");
                sb.AppendLine(string.Join("、", winYears) + " 年");
            }
            else
            {
                sb.AppendLine("此隊伍在此期間未獲得世界大賽冠軍。");
            }
            label1.Text = sb.ToString();
        }
    }
}
