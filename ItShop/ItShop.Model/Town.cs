namespace ItShop.Model
{
    using System;
    using System.Collections.Generic;

    public class Town
    {
        private ICollection<Address> addresses;

        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int TownId { get; set; }

        public string TownName { get; set; }

        public virtual ICollection<Address> Addresses
        {
            get
            {
                return this.addresses;
            }
            set
            {
                this.addresses = value;
            }
        }
    }
}
