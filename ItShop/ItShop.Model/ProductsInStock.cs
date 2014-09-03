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
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
       
        [Key, Column(Order = 1)]
        public int StoreId { get; set; }

        public int QuantityInStock { get; set; }

    }
}
