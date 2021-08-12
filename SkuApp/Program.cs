using SkuApp.Repositories;
using System;
using System.Collections.Generic;

namespace SkuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter comma delimited list of products to order:");
            string items = Console.ReadLine();
            string[] list = items.Split(',');
            CalculationEngine calculationEngine = new CalculationEngine(new SkuRepository());
            List<string> products = new List<string>(list);
            decimal total = calculationEngine.GetTotalPrice(products);
            Console.WriteLine($"Total Ordered = {total}");
        }
    }
}
