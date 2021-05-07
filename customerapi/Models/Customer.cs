using System;

namespace customerapi
{
    public class Customer
    {
        public DateTime CreationDate { get; set; }

        public static ulong AvailableID { get; set; } = 0;
        public ulong Id { get; set; }

        public string Name { get; set;}

        public Customer(string name)
        {
            this.Id = Customer.AvailableID;
            Customer.AvailableID++;
            this.Name = name;
            this.CreationDate = DateTime.Now;
        }

    }
}
