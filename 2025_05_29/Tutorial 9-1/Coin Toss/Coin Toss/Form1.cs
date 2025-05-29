using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Toss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tossButton_Click(object sender, EventArgs e)
        {
            Coin myCoin = new Coin(); // 創建 Coin 類別的實例
            outputListBox.Items.Clear(); // 清空列表框

            // 擲硬幣五次，並將結果添加到列表框中
            for (int i = 0; i < 5; i++)
            {
                myCoin.Toss(); // 擲硬幣
                outputListBox.Items.Add(myCoin.GetSideUp()); // 將結果添加到列表框
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
