using System;
using System.Collections;
using System.Collections.Generic;

namespace customerapi
{
    public class CustomerCollection
    {
        public List<Customer> CustomerList {get;set;}

        
        public CustomerCollection()
        {
            CustomerList = new List<Customer>();
            CustomerList.Add(new Customer("Greg"));
            CustomerList.Add(new Customer("Frank"));
            CustomerList.Add(new Customer("Jannette"));
            CustomerList.Add(new Customer("Dan"));
            CustomerList.Add(new Customer("Daniel"));
            CustomerList.Add(new Customer("Danielle"));
            CustomerList.Add(new Customer("Greg Jr"));
        }
    }
}
