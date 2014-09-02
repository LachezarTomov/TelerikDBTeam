namespace ItShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Manufacturer
    {
        private ICollection<Product> products;

        public Manufacturer()
        {
            this.Products = new HashSet<Product>();
        }

        public int ManufacturerID { get; set; }

        public string ManufacturerName { get; set; }

        public string Description { get; set; }

        public string CEO { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }
    }
}
