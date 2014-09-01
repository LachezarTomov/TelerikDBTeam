using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItShop.Model
{
    public class Store
    {
        private Sale sales;
        private StoresExpenses expenses;


        public Store()
        {
            this.Sales = new HashSet<Sale>();
            this.Expenses = new HashSet<StoresExpenses>();
        }
        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public virtual ICollection<StoresExpenses> Expenses { get; set; }
    }
}
