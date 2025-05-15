using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidFormat 方法接受一個字串參數，
        // 用於判斷該字串是否正確地格式化為台灣電話號碼的格式：
        // (XX)XXXX-XXXX
        // 如果字串符合上述格式，則方法返回 true；
        // 否則返回 false。
        private bool IsValidFormat(string str)
        {
            if (str.Length == 13 &&
                str[0] == '(' &&
                str[3] == ')' &&
                str[8] == '-')
            { 
                string areaCode = str.Substring(1, 2);// 區碼
                string firstPart = str.Substring(4, 4);// 前四碼
                string secondPart = str.Substring(9, 4);// 後四碼

                if(IsAccessible(areaCode) &&
                   IsAccessible(firstPart) &&
                   IsAccessible(secondPart))
                {
                    return true;
                }
            }
            return false;
        }
        
        // IsAllDigits 方法接受一個字串參數，
        // 用於判斷該字串是否僅包含數字字符。
        // 如果字串僅包含數字字符，則方法返回 true；
        // 否則返回 false。
        private bool IsAccessible(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }


        // Unformat 方法接受一個字串參數（以引用方式傳遞），
        // 假設該字串包含格式化為 (XX)XXXX-XXXX 的電話號碼。
        // 此方法會將字串中的括號和連字符移除，從而去除格式。
        private void Unformat(ref string str)
        {
            // 移除括號和連字符
            str = str.Remove(0, 1);
            str = str.Remove(2, 1);
            str = str.Remove(6, 1);

            //str = str.Remove(0, 1).Remove(2, 1).Remove(6, 1);

            //str = str.Replace("(", "").Replace(")", "").Replace("-", "");
        }
        // 當使用者按下「去格式化」按鈕時觸發此事件。
        // 該事件處理程式會取得使用者輸入的電話號碼，
        // 並嘗試去除格式（如果格式正確）。
        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;// 取得使用者輸入的電話號碼
            input = input.Trim();
            if (IsValidFormat(input))
            {
                Unformat(ref input);// 去除格式
                MessageBox.Show("去格式化後的電話號碼為：" + input);// 顯示去格式化後的電話號碼
            }
            else
            {
                MessageBox.Show("請輸入正確格式的電話號碼！");// 提示使用者輸入正確格式的電話號碼
                // 清空輸入框
                numberTextBox.Text = string.Empty;
                // 清空輸入框的焦點
                numberTextBox.Focus();
            }


        }

        // 當使用者按下「離開」按鈕時觸發此事件。
        // 該事件處理程式會關閉表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
