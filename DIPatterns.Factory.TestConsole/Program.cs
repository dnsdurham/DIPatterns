using System;
using System.Configuration;
using System.IO;
using DIPatterns.Factory.Contracts.DataContracts;
using DIPatterns.Factory.Managers;

namespace DIPatterns.Factory.TestConsole
{
    static class Program
    {
        static string _connString = ConfigurationManager.ConnectionStrings["DIDB"].ConnectionString;
        static void Main()
        {
            bool exitApp = false;
            // get the first menu selection
            int menuSelection = InitConsoleMenu();

            while (menuSelection != 99)
            {
                switch (menuSelection)
                {
                    case 1: // Run product price crawl test
                        ProductPriceCrawl("Bachmann", "00691", "BAC00691");
                        ProductPriceCrawl("E-Flite", "10450", "EFL10450");
                        ProductPriceCrawl("Traxxas", "24054", "TRA24054");
                        ProductPriceCrawl("Lionel", "630218", "LNL630218");
                        ProductPriceCrawl("Melissa & Doug", "2371", "LCI2371");
                        ProductPriceCrawl("walthers", "931870", "931-870");
                        ProductPriceCrawl("Losi", "202", "LOSB0202T1");
                        break;
                    case 2: // Run test for all products
                        ProductPriceCrawlFromFile();
                        break;
                    case 99:
                        exitApp = true;
                        break;
                }

                // check to see if we want to exit the app
                if (exitApp)
                {
                    break; // exit the while loop
                }

                // re-initialize the menu selection
                menuSelection = InitConsoleMenu();
            }

        }

        private static int InitConsoleMenu()
        {
            int result;

            Console.WriteLine("Select desired option:");
            Console.WriteLine(" 1: run product price crawl integration test");
            Console.WriteLine(" 2: run product price crawl from file");
            Console.WriteLine("99: exit");
            string selection = Console.ReadLine();
            if (int.TryParse(selection, out result) == false)
            {
                result = 0;
            }

            return result;
        }

        private static void ProductPriceCrawl(string brand, string productCode, string industryCode)
        {
            var mgr = new PriceCrawlManager();
            var products = mgr.GetProductPricingUsingSearch(brand, productCode, industryCode, false, _connString);

            // Write out the results to the console window
            foreach (Product product in products)
            {
                Console.WriteLine("{0}: {1} : {2}", product.Site, product.Price, product.ProductName);
            }

            Console.WriteLine();
        }

        private static void ProductPriceCrawlFromFile()
        {
            // load the file
            using (StreamReader file = new StreamReader(@"Resources\products.csv"))
            {
                var mgr = new PriceCrawlManager();
                string textLine;
                // Loop until the end of file and call the operation for the line
                while ((textLine = file.ReadLine()) != null)
                {
                    string[] productParams = textLine.Split(',');
                    var products = mgr.GetProductPricingUsingSearch(productParams[2], productParams[1], productParams[0], false, _connString);

                    // Write out the results to the console window
                    foreach (Product product in products)
                    {
                        Console.WriteLine("{0}: {1} : {2}", product.Site, product.Price, product.ProductName);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
