using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Test
{
    /// <summary>
    /// CellPhone 類別用來表示一支手機，包含品牌、型號與價格等屬性。
    /// </summary>
    class CellPhone
    {
        // 儲存手機品牌的私有欄位
        private string _brand;

        // 儲存手機型號的私有欄位
        private string _model;

        // 儲存手機價格的私有欄位
        private decimal _price;

        public CellPhone() //
        {
            // 建構函式初始化手機的屬性
            _brand = "";
            _model = "";
            _price = 0m;
        }

        //屬性

        public string Brand 
        {
            get { return _brand; }
            set { _brand = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                // 確保價格不能為負數
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                _price = value;
            }
        }
    }
}
