using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法會接收一個 CellPhone 物件作為參數。
        // 此方法會將使用者輸入的資料指派給該物件的屬性。
        private void GetPhoneData(CellPhone phone)
        {
            decimal price;

            phone.Brand = brandTextBox.Text; // 將使用者輸入的品牌存入 phone 物件的 Brand 屬性
            phone.Model = modelTextBox.Text; // 將使用者輸入的型號存入 phone 物件的 Model 屬性

            // 嘗試將使用者輸入的價格轉換為 decimal 型別。
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                // 如果轉換成功，將價格存入 phone 物件的 Price 屬性。
                phone.Price = price;
            }
            else
            {
                // 如果轉換失敗，顯示錯誤訊息並清空價格欄位。
                MessageBox.Show("請輸入有效的價格。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                priceTextBox.Clear();
            }
        }

        private void createObjectButton_Click(object sender, EventArgs e)
        {
            // 建立一個新的 CellPhone 物件，並準備將使用者輸入的資料存入該物件。
            CellPhone myPhone = new CellPhone();

            // 呼叫 GetPhoneData 方法，將 myPhone 物件傳入。
            GetPhoneData(myPhone);

            // 將 myPhone 物件的資料顯示在標籤中。
            brandLabel.Text = myPhone.Brand;
            modelLabel.Text = myPhone.Model;
            priceLabel.Text = myPhone.Price.ToString("C2"); // 格式化價格為貨幣格式

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束程式執行。
            this.Close();
        }
    }
}
