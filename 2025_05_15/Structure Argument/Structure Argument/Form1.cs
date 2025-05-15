using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Structure_Argument
{
    // 定義一個Automobile結構，包含汽車的品牌、年份與里程數
    struct Automobile
    {
        public string make;    // 汽車品牌
        public int year;       // 汽車年份
        public double mileage; // 汽車行駛里程數
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // DisplayAuto方法接受一個Automobile結構物件作為參數，
        // 並顯示該物件的所有欄位資訊於訊息方塊中
        private void DisplayAuto(Automobile auto)
        {
            MessageBox.Show(
                auto.year + " 年 " + auto.make +
                "，行駛里程：" + auto.mileage + " 英里。"
            );
        }

        // 當使用者點擊「顯示汽車 #1」按鈕時執行此事件處理函式
        // 1. 建立一個Automobile結構的實例，代表一台跑車
        // 2. 指定該汽車的品牌、年份與里程數
        // 3. 呼叫DisplayAuto方法顯示該汽車資訊
        private void auto1Button_Click(object sender, EventArgs e)
        {
            Automobile sportsCar = new Automobile();

            sportsCar.make = "Chevy Corvette"; // 設定品牌
            sportsCar.year = 1970;             // 設定年份
            sportsCar.mileage = 50000.0;       // 設定里程數

            DisplayAuto(sportsCar);            // 顯示汽車資訊
        }

        // 當使用者點擊「顯示汽車 #2」按鈕時執行此事件處理函式
        // 1. 建立一個Automobile結構的實例，代表一台皮卡車
        // 2. 指定該汽車的品牌、年份與里程數
        // 3. 呼叫DisplayAuto方法顯示該汽車資訊
        private void auto2Button_Click(object sender, EventArgs e)
        {
            Automobile pickupTruck = new Automobile();

            pickupTruck.make = "Ford Ranger";  // 設定品牌
            pickupTruck.year = 1985;           // 設定年份
            pickupTruck.mileage = 75000.0;     // 設定里程數

            DisplayAuto(pickupTruck);          // 顯示汽車資訊
        }

        // 當使用者點擊「顯示汽車 #3」按鈕時執行此事件處理函式
        // 1. 建立一個Automobile結構的實例，代表一台轎車
        // 2. 指定該汽車的品牌、年份與里程數
        // 3. 呼叫DisplayAuto方法顯示該汽車資訊
        private void auto3Button_Click(object sender, EventArgs e)
        {
            Automobile sedan = new Automobile();

            sedan.make = "Honda Accord";       // 設定品牌
            sedan.year = 2000;                 // 設定年份
            sedan.mileage = 80000.0;           // 設定里程數

            DisplayAuto(sedan);                // 顯示汽車資訊
        }
    }
}
