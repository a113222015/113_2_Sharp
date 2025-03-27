using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace American_Colonies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "美國殖民地"; // 修改表單標題為繁體中文
            okButton.Text = "確定"; // 修改確定按鈕的文字為繁體中文
            exitButton.Text = "退出"; // 修改退出按鈕的文字為繁體中文
        }

        // SequentialSearch 方法在字串陣列中搜尋指定的值。
        // 如果找到該值，則返回其位置。否則，返回 -1。
        private int SequentialSearch(string[] sArray, string value)
        {
            bool found = false;  // 標誌表示搜尋結果
            int index = 0;       // 用於遍歷陣列的索引
            int position = -1;   // 如果找到值，則記錄其位置

            // 搜尋陣列
            while (!found && index < sArray.Length)
            {
                // 如果找到匹配的值
                if (sArray[index] == value)
                {
                    found = true;  // 設置標誌為 true
                    position = index;  // 記錄值的位置
                }

                index++;  // 移動到下一個索引
            }

            // 返回找到的位置，或 -1 表示未找到
            return position;
        }

        // okButton 的 Click 事件處理方法
        private void okButton_Click(object sender, EventArgs e)
        {
            string selection;   // 用於保存使用者的選擇

            // 建立包含殖民地名稱的陣列
            string[] colonies = {  "德拉瓦", "賓夕法尼亞", "新澤西",
                                        "喬治亞", "康涅狄格", "麻薩諸塞",
                                        "馬里蘭", "南卡羅來納", "新罕布夏",
                                        "維吉尼亞", "紐約", "北卡羅來納",
                                        "羅德島" };

            // 確認使用者是否選擇了列表中的項目
            if (selectionListBox.SelectedIndex != -1)
            {
                // 獲取選定的項目
                selection = selectionListBox.SelectedItem.ToString();

                // 確定該項目是否在陣列中
                if (SequentialSearch(colonies, selection) != -1)
                {
                    // 如果找到，顯示訊息框通知使用者
                    MessageBox.Show("是的，那是其中一個殖民地。");
                }
                else
                {
                    // 如果未找到，顯示訊息框通知使用者
                    MessageBox.Show("不，那不是其中一個殖民地。");
                }
            }
        }

        // exitButton 的 Click 事件處理方法
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
