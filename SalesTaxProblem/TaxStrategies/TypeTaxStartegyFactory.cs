// ———————————————————————–
// 
//  <copyright file="TypeTaxStartegyFactory.cs" >
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
using System.ComponentModel;
using SalesTaxProblem.Domain;

namespace SalesTaxProblem.TaxStrategies
{
    public class TypeTaxStartegyFactory
    {

        public static ITaxable GetTypeStrategy(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Books:
                case ProductType.Food:
                case ProductType.MedicalProducts:
                    return new ExemptTaxStrategy();
                case ProductType.Other:
                    return new SalesTaxStrategy();
                default:
                    throw new InvalidEnumArgumentException(nameof(productType));
            }
        }
    }

    public class SalesTaxStrategy : BaseTaxStrategy
    {
        public override double GetTax() => 0.1F;
    }

    public class ExemptTaxStrategy : BaseTaxStrategy
    {
        public override double GetTax() => 0;
    }
}
