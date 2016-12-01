// ———————————————————————–
// 
//  <copyright file="TaxCalculator.cs" >
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
using System.Collections.Generic;
using SalesTaxProblem.Domain;
using SalesTaxProblem.TaxStrategies;

namespace SalesTaxProblem
{
    public class TaxCalculator
    {
        public string CreateReceipt(List<Product> products)
        {
            var receiptContext = new ReceiptContextWriter();

            foreach (var product in products)
            {
                var taxKindStrategy = TypeTaxStartegyFactory.GetTypeStrategy(product.Kind);
                var kindTax = taxKindStrategy.GetTaxAmount(product.Price, product.Quantity);

                var taxOriginStrategy = OriginTaxStrategyFactory.GetOriginStrategy(product.Origin);
                var originTax = taxOriginStrategy.GetTaxAmount(product.Price, product.Quantity);

                var currentTax = (kindTax + originTax);
                
                receiptContext.AddEntryToReceipt(product, currentTax);
            }

            return receiptContext.PrintReceipt();
        }
    }
}
