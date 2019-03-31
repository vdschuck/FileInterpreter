using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class SellerService
    {
        /// <summary>
        /// Method to add new seller if not exists
        /// </summary>
        /// <param name="sellers"></param>
        /// <param name="sellerName"></param>
        public void AddNewSeller(ref IList<Seller> sellers, string[] seller)
        {
            var item = sellers.SingleOrDefault(x => x.Name.Equals(seller[2]));
            
            if (item == null)
                sellers.Add(new Seller { Name = seller[2], SalesAmout = 0 , Cpf = seller[1], Salary = Double.Parse(seller[3]) });            
        }

        /// <summary>
        /// Method to find the worst seller
        /// </summary>
        /// <param name="sellers"></param>
        /// <returns></returns>
        public string WorstSeller(IList<Seller> sellers)
        {
            var seller = sellers.OrderBy(x => x.SalesAmout).FirstOrDefault();

            if (seller != null)
                return seller.ToString();

            return String.Empty;
        }
    }
}
