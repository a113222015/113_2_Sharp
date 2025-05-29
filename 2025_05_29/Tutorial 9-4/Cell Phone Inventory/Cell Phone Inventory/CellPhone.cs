using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Inventory
{
    /// <summary>
    /// CellPhone 類別用來表示一支手機的資訊，包括品牌、型號與售價。
    /// </summary>
    class CellPhone
    {
        // 欄位：儲存手機品牌
        private string _brand;

        // 欄位：儲存手機型號
        private string _model;

        // 欄位：儲存手機的零售價格
        private decimal _price;

        /// <summary>
        /// 無參數建構函式，將品牌、型號設為空字串，價格設為 0。
        /// </summary>
        public CellPhone()
        {
            _brand = "";
            _model = "";
            _price = 0m;
        }

        /// <summary>
        /// 品牌屬性，取得或設定手機品牌。
        /// </summary>
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        /// <summary>
        /// 型號屬性，取得或設定手機型號。
        /// </summary>
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        /// <summary>
        /// 價格屬性，取得或設定手機的零售價格。
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
