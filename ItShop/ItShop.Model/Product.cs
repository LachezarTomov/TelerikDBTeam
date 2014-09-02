namespace ItShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Product
    {
        private ICollection<SaleDetail> saleDetails;

        public Product()
        {
            this.SaleDetails = new HashSet<SaleDetail>();
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal BuyingPrice { get; set; }

        public decimal BasePrice { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

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
