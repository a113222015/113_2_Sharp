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
using System.Xml.Linq;

namespace Phonebook
{
    // PhoneBookEntry 結構用來儲存每一筆電話簿資料，包括姓名與電話號碼
    struct PhoneBookEntry
    {
        public string name;   // 姓名
        public string phone;  // 電話號碼
    }

    public partial class Form1 : Form
    {
        // 用來儲存所有電話簿資料的 List
        private List<PhoneBookEntry> phoneList = new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 讀取 PhoneList.txt 檔案內容，並將每一筆資料存成 PhoneBookEntry 物件，加入 phoneList 清單中
        /// 檔案格式：每一行為一筆資料，姓名與電話號碼以逗號分隔
        /// 例如：王小明,0912345678
        /// </summary>
        private void ReadFile()
        {
            StreamReader inputFile;
            if (openFile.ShowDialog() == DialogResult.OK) // 選擇檔案
            {
                // 取得檔案名稱
                string fileName = openFile.FileName;
                // 檢查檔案是否存在
                if (!File.Exists(fileName))
                {
                    MessageBox.Show("檔案不存在！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("未選擇檔案！");
                return;
            }
            {
                try
                {
                    inputFile = File.OpenText(openFile.FileName);
                    string line;
                    while (!inputFile.EndOfStream)
                    {
                        // 讀取每一行資料
                        line = inputFile.ReadLine().Trim();

                        // 將每一行資料以逗號分隔，並存入 phoneList
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            PhoneBookEntry entry;
                            entry.name = parts[0].Trim();
                            entry.phone = parts[1].Trim();
                            phoneList.Add(entry);
                        }
                        else
                        {
                            MessageBox.Show("檔案格式錯誤，請檢查檔案內容！");
                            return;
                        }
                    }
                    inputFile.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取檔案失敗：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 將 phoneList 中所有姓名顯示在 nameListBox 控制項上
        /// 會先清空 nameListBox，再逐一加入每一筆資料的姓名
        /// </summary>
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name); // 將姓名加入 nameListBox
            }
        }

        /// <summary>
        /// 表單載入時執行，會呼叫 ReadFile 讀取電話簿資料，並呼叫 DisplayNames 顯示所有姓名
        /// 若檔案不存在或讀取失敗，會顯示錯誤訊息
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile(); // 讀取電話簿資料

            DisplayNames(); // 顯示所有姓名在 nameListBox 上
        }

        /// <summary>
        /// 當使用者在 nameListBox 選取不同姓名時，會顯示對應的電話號碼於 phoneLabel
        /// 若未選取任何項目，則清空 phoneLabel
        /// </summary>
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index != -1)
            {
                // 顯示對應的電話號碼
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                // 清空 phoneLabel
                phoneLabel.Text = "無資料";
            }
        }

        // 問題的原因是因為 'name' 和 'phone' 並未在該範圍內定義。  
        // 在 addButton_Click 方法中，應該使用 entry.name 和 entry.phone 來取代 'name' 和 'phone'。  
        // 以下是修正後的程式碼：  

        private void addButton_Click(object sender, EventArgs e)
        {
            // 取得使用者輸入的姓名與電話號碼  
            PhoneBookEntry entry;
            entry.name = textBoxName.Text.Trim();
            entry.phone = textBoxPhone.Text.Trim();

            // 檢查姓名與電話號碼是否為空  
            if (string.IsNullOrEmpty(entry.name) || string.IsNullOrEmpty(entry.phone))
            {
                MessageBox.Show("姓名或電話號碼不能為空！");
                return;
            }

            // 檢查電話號碼格式是否正確  
            if (!System.Text.RegularExpressions.Regex.IsMatch(entry.phone, @"^\d{7}$"))
            {
                MessageBox.Show("電話號碼格式錯誤，請輸入 7 位數字！");
                return;
            }

            // 新增資料到 phoneList  
            phoneList.Add(entry);
            nameListBox.Items.Add(entry.name);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單前，將 phoneList 中的資料寫回原本開啟的檔案
            try
            {
                if (!string.IsNullOrEmpty(openFile.FileName))
                {
                    StreamWriter writer = File.CreateText(openFile.FileName);
                    foreach (PhoneBookEntry entry in phoneList)
                    {
                        writer.WriteLine($"{entry.name},{entry.phone}");
                    }
                    writer.Close();
                }
                else
                {
                    MessageBox.Show("未指定檔案，無法儲存資料！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 關閉表單
            this.Close();
        }
        

    }
}
