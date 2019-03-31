using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class CustomerService
    {
        public void AddNewCustomer(ref IList<Customer> customers, string customerName)
        {
            var seller = customers.SingleOrDefault(x => x.Name.Equals(customerName));

            if (seller == null)
                customers.Add(new Customer { Name = customerName });
        }       
    }
}
