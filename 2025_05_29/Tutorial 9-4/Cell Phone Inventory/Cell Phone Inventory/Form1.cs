using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GetPhoneData 方法會接收一個 CellPhone 物件作為參數，
        /// 並將使用者輸入的資料指派給該物件的屬性。
        /// </summary>
        /// <param name="phone">要填入資料的 CellPhone 物件</param>
        private void GetPhoneData(CellPhone phone)
        {
            // 暫存價格的變數
            decimal price;

            // 取得使用者輸入的品牌並指派給 CellPhone 物件
            phone.Brand = brandTextBox.Text;

            // 取得使用者輸入的型號並指派給 CellPhone 物件
            phone.Model = modelTextBox.Text;

            // 取得使用者輸入的價格，若格式正確則指派給 CellPhone 物件
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 顯示錯誤訊息，提醒使用者價格格式不正確
                MessageBox.Show("價格格式無效，請輸入正確的數字。");
            }
        }

        /// <summary>
        /// 當使用者按下「新增手機」按鈕時觸發的事件處理方法。
        /// 根據需求，此方法不會新增任何資料。
        /// </summary>
        private void addPhoneButton_Click(object sender, EventArgs e)
        {
           CellPhone myPhone = new CellPhone(); // 建立一個新的 CellPhone 物件

            GetPhoneData(myPhone); // 取得使用者輸入的手機資料並填入 myPhone 物件

            phoneList.Add(myPhone); // 將新手機物件加入清單

            //將新增手機的品牌、型號組合成字串，並加到ListBox中
            phoneListBox.Items.Add(myPhone.Brand+"" + myPhone.Model);

            // 清空輸入欄位
            brandTextBox.Text = "";
            modelTextBox.Text = "";
            priceTextBox.Text = "";
            // 將焦點設回品牌輸入欄位
            brandTextBox.Focus();
        }

        /// <summary>
        /// 當使用者在手機清單中選擇不同項目時觸發的事件處理方法。
        /// </summary>
        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex; // 取得選擇的項目索引

            MessageBox.Show(phoneList[index].Price.ToString("C")); // 顯示選擇手機的價格，格式化為貨幣形式

        }

        /// <summary>
        /// 當使用者按下「離開」按鈕時觸發的事件處理方法，會關閉表單。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的表單，結束程式
            this.Close();
        }
    }
}
