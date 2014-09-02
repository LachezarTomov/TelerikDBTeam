namespace ItShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Category
    {
        private ICollection<Product> products;  

        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

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
