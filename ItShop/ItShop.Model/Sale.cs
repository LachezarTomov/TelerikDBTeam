namespace ItShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    public class Sale
    {
        private ICollection<SaleDetail> saleDetails;      


        public Sale()
        {
            this.SaleDetails = new HashSet<SaleDetail>();
        }
        [Key]
        public int SaleId { get; set; }

        public int StoreId { get; set; }

        public Store Store { get; set; }

        public DateTime SaleDate { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails       
        {
            get
            {
                return this.saleDetails;
            }
            set
            {
                this.saleDetails = value;
            }
        }
    }
}
