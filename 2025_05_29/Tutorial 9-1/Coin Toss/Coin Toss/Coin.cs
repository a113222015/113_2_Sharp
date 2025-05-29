using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    /// <summary>
    /// Coin 類別用於模擬一枚硬幣，可以擲出正面或反面。
    /// </summary>
    internal class Coin
    {
        private string sideUp; // 硬幣的正面或反面
        Random rand = new Random(); // 用於生成隨機數的實例
        public Coin()
        { 
         sideUp = "正面"; // 預設硬幣的正面為 "正面"
        }

        public void Toss()
        {
            
            // 生成一個隨機數，如果是 0，則設置為 "正面"，否則設置為 "反面"
            if (rand.Next(2) == 0)
            {
                sideUp = "正面";
            }
            else
            {
                sideUp = "反面";
            }
        }
        public string GetSideUp() //
        {
            // 返回硬幣的正面或反面
            return sideUp;
        }
    }
}
