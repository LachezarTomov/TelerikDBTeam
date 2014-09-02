namespace ItShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Store
    {
        private ICollection<Sale> sales;
        private ICollection<StoresExpenses> expenses;

        public Store()
        {
            this.Sales = new HashSet<Sale>();
            this.Expenses = new HashSet<StoresExpenses>();
        }
        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get
            {
                return this.sales;
            }
            set
            {
                this.sales = value;
            }
        }

        public virtual ICollection<StoresExpenses> Expenses
        {
            get
            {
                return this.expenses;
            }
            set
            {
                this.expenses = value;
            }
        }
    }
}
