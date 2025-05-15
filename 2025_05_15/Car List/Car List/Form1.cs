using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_List
{
    struct Automobile
    {
        public string make;
        public int year;
        public double mileage;
    }

    public partial class Form1 : Form
    {
        // 建立一個汽車清單作為欄位，用來儲存所有輸入的汽車資料
        private List<Automobile> carList = new List<Automobile>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetData 方法會取得使用者在三個文字方塊中輸入的資料，
        // 並將這些資料指派給傳入參數 auto 的各個欄位
        // 若輸入格式錯誤，會顯示錯誤訊息
        private void GetData(ref Automobile auto)
        {
            try
            {
                // 從文字方塊取得廠牌、年份與里程數，並轉換成對應型別
                auto.make = makeTextBox.Text;
                auto.year = int.Parse(yearTextBox.Text);
                auto.mileage = double.Parse(mileageTextBox.Text);
            }
            catch (Exception ex)
            {
                // 若發生例外（如格式錯誤），顯示錯誤訊息（繁體中文）
                MessageBox.Show("輸入資料格式錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 當使用者按下「加入清單」按鈕時執行
        // 1. 建立一個新的汽車結構
        // 2. 取得使用者輸入的資料並存入該結構
        // 3. 將該汽車加入清單
        // 4. 清空所有輸入欄位並將游標移回廠牌欄位
        private void addButton_Click(object sender, EventArgs e)
        {
            // 建立一個新的汽車結構實例
            Automobile car = new Automobile();

            // 取得使用者輸入的資料
            GetData(ref car);

            // 將汽車資料加入清單
            carList.Add(car);

            // 清空所有輸入欄位
            makeTextBox.Clear();
            yearTextBox.Clear();
            mileageTextBox.Clear();

            // 將游標移回廠牌輸入欄位，方便繼續輸入
            makeTextBox.Focus();
        }

        // 當使用者按下「顯示清單」按鈕時執行
        // 1. 清空 ListBox 內容
        // 2. 將所有汽車資料以格式化字串顯示於 ListBox
        private void displayButton_Click(object sender, EventArgs e)
        {
            // 宣告一個字串用來儲存每一行要顯示的內容
            string output;

            // 清空 ListBox 目前的內容
            carListBox.Items.Clear();

            // 逐一將清單中的每一台汽車資料格式化後加入 ListBox
            foreach (Automobile aCar in carList)
            {
                // 將汽車資料組合成一行顯示字串（繁體中文）
                output = aCar.year + " 年 " + aCar.make +
                    "，里程數：" + aCar.mileage + " 英里";

                // 將該行資料加入 ListBox
                carListBox.Items.Add(output);
            }
        }
    }
}
