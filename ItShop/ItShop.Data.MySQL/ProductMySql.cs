namespace ItShop.Data.MySQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class ProductMySql //: System.ComponentModel.INotifyPropertyChanged
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal BuyingPrice { get; set; }

        public decimal BasePrice { get; set; }

        public int ManufacturerId { get; set; }


        public int CategoryId { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
