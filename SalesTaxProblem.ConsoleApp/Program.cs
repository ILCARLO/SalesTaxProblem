// ———————————————————————–
// 
//  <copyright file="Program.cs" >
//      Copyright © 2016 All rights reserved. 
//      Carlo Menapace
//      01 / 12 / 2016
//  </copyright>
// 
// Copyright  © 2016 Carlo Menapace
// 
//  This file is part of SalesTaxProblem.
// 
//     SalesTaxProblem free software: you can redistribute it and/or modify
//     it under the terms of the Affero GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     SalesTaxProblem distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     Affero GNU General Public License for more details.
// 
//     You should have received a copy of the Affero GNU General Public License
//     along with SalesTaxProblem.  If not, see <http://www.gnu.org/licenses/>.
// 
// ———————————————————————–
using System;
using System.Collections.Generic;
using SalesTaxProblem.Domain;

namespace SalesTaxProblem.ConsoleApp
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("SalesTaxProblem Copyright(C) 2016  Carlo Menapace ");
            Console.WriteLine("This program comes with ABSOLUTELY NO WARRANTY.");
            Console.WriteLine("This is free software, and you are welcome to redistribute it under certain conditions.");
            Console.WriteLine("For more details, see the license conditions released with this source code");
            Console.WriteLine("---------------------------------------------------------------------------");

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
            Console.WriteLine("Output for input2:");
            var input2List = new List<Product>();
            input2List.Add(new Product(1, "Choclate", 10.00, ProductType.Food, Origin.Imported));
            input2List.Add(new Product(1, "Perfume", 47.50, ProductType.Other, Origin.Imported));

            var receiptForInput2 = taxCaluclator.CreateReceipt(input2List);
            Console.WriteLine(receiptForInput2);

            //input3
            Console.WriteLine("Output for input3:");
            var input3List = new List<Product>();
            input3List.Add(new Product(1, "Bootle of parfume", 27.99, ProductType.Other, Origin.Imported));
            input3List.Add(new Product(1, "Bootle of parfume", 18.99, ProductType.Other, Origin.Local));
            input3List.Add(new Product(1, "packet of headache pills", 9.75, ProductType.MedicalProducts, Origin.Local));
            input3List.Add(new Product(1, "box of chocolates", 11.25, ProductType.Food, Origin.Imported));

            var receiptForInput3 = taxCaluclator.CreateReceipt(input3List);
            Console.WriteLine(receiptForInput3);

            Console.ReadLine();
        }
    }
}