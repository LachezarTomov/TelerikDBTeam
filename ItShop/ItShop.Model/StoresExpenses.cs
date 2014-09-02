namespace ItShop.Model
{
    using System;
    public class StoresExpenses
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public DateTime ForDate { get; set; }

   //   public virtual Store Store { get; set; } // do we need this one?

        public decimal Amount { get; set; }

    }
}
