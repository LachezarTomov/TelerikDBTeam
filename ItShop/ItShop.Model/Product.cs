using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItShop.Model
{
    public class Product
    {
        private SaleDetail saleDetails;
        public Product()
        {
            this.SaleDetails = new HashSet<SaleDetail>();
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal BasePrice { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
