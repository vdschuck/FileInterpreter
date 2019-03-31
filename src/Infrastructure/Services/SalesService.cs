using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class SalesService
    {
        /// <summary>
        /// Method to calculate sales
        /// </summary>
        /// <param name="line"></param>
        /// <param name="sellers"></param>
        /// <returns></returns>
        public (double salesValue, string salesId) SalesAmout(ref IList<Seller> sellers, string line, string separator)
        {
            var record = line.Split(separator);
            var sales = line.Substring(line.IndexOf("[") + 1);
            sales = sales.Substring(0, sales.IndexOf("]"));
            var items = sales.Split(",");
            double salesAmout = 0;

            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i].Split('-');
                salesAmout += Double.Parse(item[1]) * Double.Parse(item[2]);
            }

            var salesman = sellers.SingleOrDefault(x => x.Name.Equals(record[3]));

            if (salesman != null)
                salesman.SalesAmout += salesAmout;
            else
                sellers.Add(new Seller { Name = record[3], SalesAmout = salesAmout });

            return (salesAmout, record[1]);
        }
    }
}