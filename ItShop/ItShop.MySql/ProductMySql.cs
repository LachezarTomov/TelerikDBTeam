using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItShop.MySql
{
    public class ProductMySql
    {
        
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal BuyingPrice { get; set; }

        public decimal BasePrice { get; set; }

        public int ManufacturerId { get; set; }


        public int CategoryId { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
