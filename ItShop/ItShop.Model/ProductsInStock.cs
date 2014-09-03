using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItShop.Model
{
    public class ProductsInStock
    {
        public int ProductsInStockId { get; set; }

        public int ProductId { get; set; }
       // public virtual Product Product { get; set; }


        public int StoreId { get; set; }
       // public virtual Store Store { get; set; }

        public int QuantityInStock { get; set; }

    }
}
