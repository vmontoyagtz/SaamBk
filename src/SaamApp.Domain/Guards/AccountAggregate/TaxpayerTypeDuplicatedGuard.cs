using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TaxpayerTypeGuardExtensions
    {
        public static void DuplicateTaxpayerType(this IGuardClause guardClause,
            IEnumerable<TaxpayerType> existingTaxpayerTypes, TaxpayerType newTaxpayerType, string parameterName)
        {
            if (existingTaxpayerTypes.Any(a => a.TaxpayerTypeId == newTaxpayerType.TaxpayerTypeId))
            {
                throw new DuplicateTaxpayerTypeException("Cannot add duplicate taxpayerType.", parameterName);
            }
        }
    }
}