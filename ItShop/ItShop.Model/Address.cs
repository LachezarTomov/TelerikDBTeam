namespace ItShop.Model
{
    using System;
    using System.Collections.Generic;

    public class Address
    {
        private ICollection<Store> stores;

        public Address()
        {
            this.Stores = new HashSet<Store>();
        }

        public int AddressId { get; set; }

        public string AddressName { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Store> Stores
        {
            get
            {
                return this.stores;
            }
            set
            {
                this.stores = value;
            }
        }
    }
}
