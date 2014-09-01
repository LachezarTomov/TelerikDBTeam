using System;
using System.Collections.Generic;
using System.Linq;

namespace ItShop.Model
{
    public class StoresExpenses
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public DateTime ForDate { get; set; }

        public decimal Amount { get; set; }

    }
}
