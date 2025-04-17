using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 設定表單的標題為「座位表」
            this.Text = "座位表";

            // 設定顯示價格按鈕的文字為「顯示價格」
            displayPriceButton.Text = "顯示價格";

            // 設定退出按鈕的文字為「退出」
            exitButton.Text = "退出";
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            // 定義座位的行數與列數
            const int ROWS = 6; // 總共有 6 列
            const int COLS = 4; // 總共有 4 行

            // 宣告變數來儲存使用者輸入的列與行
            int row;
            int col;

            // 定義座位價格的二維陣列
            decimal[,] seatPrices = {  {450m, 450m, 450m, 450m}, // 第一列的價格
                                           {425m, 425m, 425m, 425m}, // 第二列的價格
                                           {400m, 400m, 400m, 400m}, // 第三列的價格
                                           {375m, 375m, 375m, 375m}, // 第四列的價格
                                           {375m, 375m, 375m, 375m}, // 第五列的價格
                                           {350m, 350m, 350m, 350m}  // 第六列的價格
                                    };

            // 嘗試將使用者輸入的列號轉換為整數
            if (int.TryParse(rowTextBox.Text, out row))
            {
                // 嘗試將使用者輸入的行號轉換為整數
                if (int.TryParse(colTextBox.Text, out col))
                {
                    // 檢查列號是否在有效範圍內
                    if (row >= 0 && row < seatPrices.GetLength(0))
                    {
                        // 檢查行號是否在有效範圍內
                        if (col >= 0 && col < seatPrices.GetLength(1))
                        {
                            // 顯示對應座位的價格，格式化為貨幣格式
                            priceLabel.Text = seatPrices[row, col].ToString("C");
                        }
                        else
                        {
                            // 如果行號超出範圍，顯示錯誤訊息並將焦點設置到行號輸入框
                            MessageBox.Show("行編號必須在 0 到 3 之間!");
                            colTextBox.Focus();
                            return;
                        }
                    }
                    else
                    {
                        // 如果列號超出範圍，顯示錯誤訊息並將焦點設置到列號輸入框
                        MessageBox.Show("列編號必須在 0 到 5 之間!");
                        rowTextBox.Focus();
                        return;
                    }
                }
                else
                {
                    // 如果行號無效，顯示錯誤訊息並將焦點設置到行號輸入框
                    MessageBox.Show("請輸入有效的行號");
                    colTextBox.Focus();
                    return;
                }
            }
            else
            {
                // 如果列號無效，顯示錯誤訊息並將焦點設置到列號輸入框
                MessageBox.Show("請輸入有效的列號");
                rowTextBox.Focus();
                return;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單並結束應用程式
            this.Close();
        }
    }
}
