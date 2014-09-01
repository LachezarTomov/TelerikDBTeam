using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItShop.Model
{
    public class SaleDetail
    {
        [Key]
        public int SaleDetailId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int SaleId { get; set; }

        public virtual Sale Sale { get; set; }


        public int Quantity { get; set; }

        public decimal SalePrice { get; set; }
    }
}
