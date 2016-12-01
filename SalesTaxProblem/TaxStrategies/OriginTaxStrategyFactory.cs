// ———————————————————————–
// 
//  <copyright file="OriginTaxStrategyFactory.cs" >
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
    public class OriginTaxStrategyFactory
    {

        public static ITaxable GetOriginStrategy(Origin productOrigin)
        {
            switch (productOrigin)
            {
                case Origin.Local:
                    return new LocalTaxStartegy();
                case Origin.Imported:
                    return new ImportedtaxStrategy();
                default:
                    throw new InvalidEnumArgumentException(nameof(productOrigin));
            }
        }
    }

    public class LocalTaxStartegy : BaseTaxStrategy
    {
        public override double GetTax() => 0;
    }

    public class ImportedtaxStrategy : BaseTaxStrategy
    {
        public override double GetTax() => 0.05F;
    }
}
