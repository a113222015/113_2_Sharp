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
    // 定義球隊資料結構，包含球隊名稱、奪冠次數與奪冠年份清單
    public struct TeamData
    {
        public string Name;         // 球隊名稱
        public int Wins;            // 奪冠次數
        public List<int> WinYears;  // 奪冠年份清單

        public TeamData(string name)
        {
            Name = name;
            Wins = 0;
            WinYears = new List<int>();
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 使用字典儲存所有球隊資料，Key 為球隊名稱，Value 為 TeamData 結構
        Dictionary<string, TeamData> teamDataDict = new Dictionary<string, TeamData>();
        // 使用清單儲存所有球隊資料（依照球隊名稱排序）
        List<TeamData> teamDataList = new List<TeamData>();
        // 儲存所有世界大賽冠軍隊伍名稱（依年份順序）
        List<string> winnerList = new List<string>();

        // 檔案路徑：球隊資料與冠軍資料
        string teamsFilePath = "";
        string winnersFilePath = "";
        // 是否已經新增2010年以後的資料
        bool isDataExtended = false;

        // 分別定義兩個 OpenFileDialog，分別用於選擇球隊與冠軍資料檔案
        OpenFileDialog openTeamsDialog = new OpenFileDialog();
        OpenFileDialog openWinnersDialog = new OpenFileDialog();

        /// <summary>
        /// 表單載入事件，初始化並讀取球隊與冠軍資料
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            openTeamsDialog.Title = "請選擇球隊資料檔案（Teams.txt）";
            openTeamsDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";

            openWinnersDialog.Title = "請選擇冠軍資料檔案（WorldSeries.txt）";
            openWinnersDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";

            MessageBox.Show("請先選擇球隊資料檔案（Teams.txt）。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!SelectTeamsFile()) return;

            MessageBox.Show("請選擇冠軍球隊資料檔案（WorldSeries.txt）。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!SelectWinnersFile()) return;

            readTeams();
            readWinner();
            updateTeamDataList();
        }

        /// <summary>
        /// 讓使用者選擇球隊資料檔案，若未選擇則結束程式
        /// </summary>
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
        /// 讓使用者選擇冠軍資料檔案，若未選擇則結束程式
        /// </summary>
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
        /// 讀取球隊資料檔案，將所有球隊名稱加入 teamDataDict 與 listBox1
        /// </summary>
        private void readTeams()
        {
            try
            {
                teamDataDict.Clear();
                listBox1.Items.Clear();
                foreach (string line in File.ReadAllLines(teamsFilePath, Encoding.UTF8))
                {
                    if (!teamDataDict.ContainsKey(line))
                    {
                        teamDataDict[line] = new TeamData(line);
                        listBox1.Items.Add(line);
                    }
                }
                // 讀取完畢後，將所有 TeamData 放入 teamDataList，並依球隊名稱排序
                teamDataList = teamDataDict.Values.OrderBy(t => t.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取球隊資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 讀取冠軍資料檔案，將每一年的冠軍球隊名稱存入 winnerList
        /// </summary>
        private void readWinner()
        {
            try
            {
                winnerList.Clear();
                foreach (string line in File.ReadAllLines(winnersFilePath, Encoding.UTF8))
                {
                    winnerList.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取冠軍資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 依據 teamDataDict 內容更新 teamDataList，並依球隊名稱排序
        /// </summary>
        private void updateTeamDataList()
        {
            teamDataList = teamDataDict.Values.OrderBy(t => t.Name).ToList();
        }

        /// <summary>
        /// 當使用者在 listBox1 選擇球隊時，計算該球隊奪冠次數與年份，並顯示於 label1
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string teamName = listBox1.SelectedItem.ToString();

            // 從 teamDataList 取得該隊伍的 TeamData
            TeamData? data = teamDataList.FirstOrDefault(t => t.Name == teamName);

            if (data == null || string.IsNullOrEmpty(data.Value.Name))
                return;

            // 重新計算該球隊的奪冠次數與年份
            TeamData team = new TeamData(teamName);
            int startYear = 1903;
            int year = startYear;
            HashSet<int> skipYears = new HashSet<int> { 1904, 1994 };
            int endYear = isDataExtended ? 2024 : 2009;

            for (int i = 0; i < winnerList.Count && year <= endYear; i++)
            {
                while (skipYears.Contains(year)) year++;
                if (year > endYear) break;

                if (winnerList[i] == teamName)
                {
                    team.Wins++;
                    team.WinYears.Add(year);
                }
                year++;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{team.Name} 從 1903 年到 {endYear} 年共獲得 {team.Wins} 次世界大賽冠軍。");

            if (team.WinYears.Count > 0)
            {
                sb.AppendLine("奪冠年份：");
                sb.AppendLine(string.Join("、", team.WinYears) + " 年");
            }
            else
            {
                sb.AppendLine("此隊伍在此期間未獲得世界大賽冠軍。");
            }

            label1.Text = sb.ToString();
        }

        /// <summary>
        /// 按下「新增資料」按鈕時，開啟對話方塊讀取2010年以後MLB冠軍隊伍資料，更新 winnerList 與 teamDataDict
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
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
                newWinners = new List<string>(File.ReadAllLines(newWinnersFilePath, Encoding.UTF8));
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取2010年以後冠軍資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            winnerList.AddRange(newWinners);

            foreach (string team in newWinners)
            {
                if (!teamDataDict.ContainsKey(team))
                {
                    teamDataDict[team] = new TeamData(team);
                }
            }

            // 更新 teamDataList
            updateTeamDataList();

            listBox1.Items.Clear();
            foreach (string team in teamDataDict.Keys.OrderBy(t => t))
            {
                listBox1.Items.Add(team);
            }

            isDataExtended = true;
            MessageBox.Show("2010年以後冠軍資料已成功加入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 按下「離開」按鈕時，將更新後的球隊資料存回 MLB_Teams_Translated.txt，
        /// 並將冠軍資料存回原始檔案，最後結束程式
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            try
            {
                string savePath = Path.Combine(Path.GetDirectoryName(teamsFilePath), "MLB_Teams_Translated.txt");
                File.WriteAllLines(savePath, teamDataDict.Keys.OrderBy(t => t), Encoding.UTF8);

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

