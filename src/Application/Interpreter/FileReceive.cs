using Data.Models;
using Infrastructure.Helpers;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Interpreter
{
    public class FileReceive
    {
        #region ctor
        private readonly SalesService salesService;
        private readonly SellerService sellerService;
        private readonly CustomerService customerService;
        private const string separator = "ç";
        private IList<Customer> customers;
        private IList<Seller> sellers;        

        public FileReceive()
        {
            salesService = new SalesService();
            sellerService = new SellerService();
            customerService = new CustomerService();            
        }
        #endregion

        #region ProcessFile
        /// <summary>
        /// Method that receives notification of new file
        /// </summary>
        /// <param name="sender"></param> 
        /// <param name="e"></param>
        public void ProcessFile(object sender, FileSystemEventArgs e)
        {
            try
            {
                var expensiveSale = ReadFile(e.FullPath);

                var fileName = e.Name.Substring(0, e.Name.IndexOf("."));
                CreateOutputFile(customers.Count, sellers.Count, expensiveSale, String.Concat(fileName, ".done.dat"));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR ({e.Name}): {ex.ToString()}");
            } 
        }
        #endregion

        #region ReadFile
        /// <summary>
        /// Method to open file and read all lines
        /// </summary>
        /// <param name="fileName"></param>        
        private string ReadFile(string path)
        {
            sellers = new List<Seller>();
            customers = new List<Customer>();
            int counter = 0;        
            double amountSales = 0;
            string expensiveSaleId = "";

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8, true))
            {
                String line = "";
               
                while ((line = sr.ReadLine()) != null)
                {                    
                    counter++;

                    if (!String.IsNullOrEmpty(line))
                    {
                        switch (line.Substring(0, 3))
                        {
                            case "001": // Seller data

                                var sellerData = line.Split(separator);
                                sellerService.AddNewSeller(ref sellers, sellerData);                        
                                break;

                            case "002": // Customer data

                                var customerData = line.Split(separator);
                                customerService.AddNewCustomer(ref customers, customerData[2]);                               
                                break;

                            case "003": // Sales data   

                                (double value, string id) = salesService.SalesAmout(ref sellers, line, separator);

                                if (value > amountSales)
                                {
                                    amountSales = value;
                                    expensiveSaleId = id;
                                }                                
                                break;

                            default:
                                Console.WriteLine($"ERROR: Line ({counter}) is incorrect!");
                                break;
                        }
                    }
                }
            }

            return expensiveSaleId;
        }
        #endregion

        #region CreateOutputFile
        private void CreateOutputFile(int amountCustomers, int amountSellers, string expensiveSale, string fileName)
        {    
            var worstSeller = sellerService.WorstSeller(sellers);
            
            using (StreamWriter file = File.CreateText(FolderHelper.GetFolderPathOut(fileName)))
            {
                file.WriteLine(amountCustomers);
                file.WriteLine(amountSellers);
                file.WriteLine(expensiveSale);
                file.WriteLine(worstSeller);
            }
        }
        #endregion
    }
}
