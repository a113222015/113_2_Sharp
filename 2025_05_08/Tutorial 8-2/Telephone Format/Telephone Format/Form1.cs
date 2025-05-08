using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法接受一個字串作為參數，
        // 並檢查該字串是否包含 10 個數字。
        // 如果包含 10 個數字，則回傳 true；否則回傳 false。
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10;

            if (str.Length == VALID_LENGTH)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false; // 修正：確保所有程式碼路徑都有傳回值
        }

        // TelephoneFormat 方法接受一個字串參數（以參考方式傳遞），
        // 並將該字串格式化為電話號碼的形式 例如 "(12) 3456-7890"。
        //1234567890
        private void TelephoneFormat(ref string str)
        {
            //if (str.Length == 10)
            //{
              //  str = $"({str.Substring(0, 2)}) {str.Substring(2, 4)}-{str.Substring(6, 4)}";
            //}
            str = str.Insert(0, "(");
            str = str.Insert(3, ")");
            str = str.Insert(9, "-");
        }

        // 當使用者按下 formatButton 時觸發此事件。
        // 該方法會檢查輸入是否為有效的電話號碼，
        // 如果有效，則格式化為電話號碼的形式並顯示。
        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;

            if (IsValidNumber(input))
            {
                TelephoneFormat(ref input);

                MessageBox.Show("格式化後的電話號碼為：" + input);
            }
            else
            {
                MessageBox.Show("請輸入有效的電話號碼。");
            }
        }

        // 當使用者按下 exitButton 時觸發此事件。
        // 該方法會關閉目前的表單。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
