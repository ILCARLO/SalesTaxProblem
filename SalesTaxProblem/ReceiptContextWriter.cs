// ———————————————————————–
// 
//  <copyright file="ReceiptContextWriter.cs" >
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
using System.Globalization;
using System.Text;
using System.Threading;
using SalesTaxProblem.Domain;

namespace SalesTaxProblem
{
    public class ReceiptContextWriter
    {
        private double _total;
        private double _taxes;
        private readonly List<Product> _boughtProducts;

        public ReceiptContextWriter()
        {
            _total = 0F;
            _taxes = 0F;
            _boughtProducts = new List<Product>(0);
        }

        public void AddEntryToReceipt(Product product, double tax)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.Price = (product.Price * product.Quantity) + tax;
            _boughtProducts.Add(product);
            _total += product.Price;
            _taxes += tax;
        }

        public string PrintReceipt()
        {
            // Just in case your machine has other cultures
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var builder = new StringBuilder();
            foreach (var product in _boughtProducts)
            {
                builder.AppendLine($"{product.Quantity} {product.Name}: {GetDoubleValue(product.Price)}");
            }

            builder.AppendLine($"Sales Taxes: {GetDoubleValue(_taxes)}");
            builder.AppendLine($"Total: {GetDoubleValue(_total)}");
            return builder.ToString();
        }

        private string GetDoubleValue(double value)
        {
            return $"{value:0.00}";
        }
    }
}
