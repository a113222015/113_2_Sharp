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

        // 是否已經新增2010年以後資料
        bool isDataExtended = false;

        // 分別定義兩個 OpenFileDialog
        OpenFileDialog openTeamsDialog = new OpenFileDialog();
        OpenFileDialog openWinnersDialog = new OpenFileDialog();

        /// <summary>
        /// 表單載入事件，初始化並讀取球隊與冠軍資料
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 設定球隊檔案選擇對話方塊
            openTeamsDialog.Title = "請選擇球隊資料檔案（Teams.txt）";
            openTeamsDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";

            // 設定冠軍檔案選擇對話方塊
            openWinnersDialog.Title = "請選擇冠軍資料檔案（WorldSeries.txt）";
            openWinnersDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";

            // 提示使用者先選擇球隊資料檔案
            MessageBox.Show("請先選擇球隊資料檔案（Teams.txt）。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!SelectTeamsFile())
                return;

            // 選擇完球隊檔案後再提示選擇冠軍資料檔案
            MessageBox.Show("請選擇冠軍球隊資料檔案（WorldSeries.txt）。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!SelectWinnersFile())
                return;

            readTeams();
            readWinner();
        }

        /// <summary>
        /// 讓使用者選擇球隊資料檔案
        /// </summary>
        /// <returns>是否成功選擇檔案</returns>
        private bool SelectTeamsFile()
        {
            if (openTeamsDialog.ShowDialog() == DialogResult.OK)
            {
                teamsFilePath = openTeamsDialog.FileName;
                return true;
            }
            else
            {
                MessageBox.Show("未選擇檔案，程式將結束。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return false;
            }
        }

        /// <summary>
        /// 讓使用者選擇冠軍資料檔案
        /// </summary>
        /// <returns>是否成功選擇檔案</returns>
        private bool SelectWinnersFile()
        {
            if (openWinnersDialog.ShowDialog() == DialogResult.OK)
            {
                winnersFilePath = openWinnersDialog.FileName;
                return true;
            }
            else
            {
                MessageBox.Show("未選擇檔案，程式將結束。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return false;
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
                // 以簡化的 File.ReadAllLines 方式讀取檔案
                foreach (string line in File.ReadAllLines(teamsFilePath, Encoding.UTF8))
                {
                    teamList.Add(line);
                    listBox1.Items.Add(line);
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
                // 以簡化的 File.ReadAllLines 方式讀取檔案
                foreach (string line in File.ReadAllLines(winnersFilePath, Encoding.UTF8))
                {
                    winnerList.Add(line);
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

            // 計算顯示的最後一年
            int endYear = isDataExtended ? 2024 : 2009;

            for (int i = 0; i < winnerList.Count && year <= endYear; i++)
            {
                // 跳過未舉辦的年份
                while (skipYears.Contains(year))
                {
                    year++;
                }
                if (year > endYear)
                    break;
                if (str == winnerList[i])
                {
                    numWin++;
                    winYears.Add(year);
                }
                year++;
            }

            // 根據是否已新增資料，決定顯示年份範圍
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(str + $" 從 1903 年到 {endYear} 年共獲得 {numWin} 次世界大賽冠軍。");
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

        /// <summary>
        /// 按下「新增資料」按鈕時，開啟對話方塊讀取2010年以後MLB冠軍隊伍資料，更新list與介面
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // 使用新的 OpenFileDialog 以避免與前面重複
            OpenFileDialog openNewWinnersDialog = new OpenFileDialog();
            openNewWinnersDialog.Title = "請選擇2010年以後MLB冠軍隊伍資料檔案";
            openNewWinnersDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";

            MessageBox.Show("請選擇2010年以後MLB冠軍隊伍資料檔案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (openNewWinnersDialog.ShowDialog() != DialogResult.OK)
                return;

            string newWinnersFilePath = openNewWinnersDialog.FileName;

            List<string> newWinners;
            try
            {
                // 以簡化的 File.ReadAllLines 方式讀取檔案
                newWinners = new List<string>(File.ReadAllLines(newWinnersFilePath, Encoding.UTF8));
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取2010年以後冠軍資料時發生錯誤：" + ex.Message);
                return;
            }

            // 將新資料加入 winnerList
            winnerList.AddRange(newWinners);

            // 將新隊伍加入 teamList（避免重複）
            foreach (string team in newWinners)
            {
                if (!teamList.Contains(team))
                {
                    teamList.Add(team);
                }
            }

            // 重新整理 listBox1 顯示內容
            listBox1.Items.Clear();
            foreach (string team in teamList)
            {
                listBox1.Items.Add(team);
            }

            // 標記已經新增過資料
            isDataExtended = true;

            MessageBox.Show("2010年以後冠軍資料已成功加入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 按下「離開」按鈕時，將更新後的球隊與冠軍資料存回原始檔案，然後結束程式
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            try
            {
                // 將球隊資料儲存回 MLB_Teams_Translated.txt
                string savePath = Path.Combine(Path.GetDirectoryName(teamsFilePath), "MLB_Teams_Translated.txt");
                File.WriteAllLines(savePath, teamList, Encoding.UTF8);

                // 儲存冠軍資料回原始檔案
                File.WriteAllLines(winnersFilePath, winnerList, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
