using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItShop.Model
{
    public class Sale
    {
        private SaleDetail saleDetails;
        public Sale()
        {
            this.SaleDetails = new HashSet<SaleDetail>();
        }
        [Key]
        public int SaleId { get; set; }
        
        public int StoreId { get; set; }

        public DateTime SaleDate { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
