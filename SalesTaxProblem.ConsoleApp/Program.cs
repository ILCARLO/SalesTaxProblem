using System;
using System.Collections.Generic;
using SalesTaxProblem.Domain;

namespace SalesTaxProblem.ConsoleApp
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var taxCaluclator = new TaxCalculator();

            //input 1
            Console.WriteLine("Output for input1:");
            var input1List = new List<Product>();
            input1List.Add(new Product(1, "Book", 12.49, ProductType.Books, Origin.Local));
            input1List.Add(new Product(1, "CD", 14.99, ProductType.Other, Origin.Local));
            input1List.Add(new Product(1, "Choclate", 0.85, ProductType.Food, Origin.Local));

            var receiptForInput1 = taxCaluclator.CreateReceipt(input1List);
            Console.WriteLine(receiptForInput1);

            //input 2
            System.Console.WriteLine("Output for input2:");
            var input2List = new List<Product>();
            input2List.Add(new Product(1, "Choclate", 10.00, ProductType.Food, Origin.Imported));
            input2List.Add(new Product(1, "Perfume", 47.50, ProductType.Other, Origin.Imported));

            var receiptForInput2 = taxCaluclator.CreateReceipt(input2List);
            System.Console.WriteLine(receiptForInput2);

            //input3
            System.Console.WriteLine("Output for input3:");
            var input3List = new List<Product>();
            input3List.Add(new Product(1, "Bootle of parfume", 27.99, ProductType.Other, Origin.Imported));
            input3List.Add(new Product(1, "Bootle of parfume", 18.99, ProductType.Other, Origin.Local));
            input3List.Add(new Product(1, "packet of headache pills", 9.75, ProductType.MedicalProducts, Origin.Local));
            input3List.Add(new Product(1, " box of chocolates", 11.25, ProductType.Food, Origin.Imported));

            var receiptForInput3 = taxCaluclator.CreateReceipt(input3List);
            System.Console.WriteLine(receiptForInput3);

            Console.ReadLine();



        }
    }
}