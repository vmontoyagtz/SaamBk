using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TaxInformationGuardExtensions
    {
        public static void DuplicateTaxInformation(this IGuardClause guardClause,
            IEnumerable<TaxInformation> existingTaxInformations, TaxInformation newTaxInformation, string parameterName)
        {
            if (existingTaxInformations.Any(a => a.TaxInformationId == newTaxInformation.TaxInformationId))
            {
                throw new DuplicateTaxInformationException("Cannot add duplicate taxInformation.", parameterName);
            }
        }
    }
}