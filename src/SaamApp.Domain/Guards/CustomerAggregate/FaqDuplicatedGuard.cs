using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class FaqGuardExtensions
    {
        public static void DuplicateFaq(this IGuardClause guardClause, IEnumerable<Faq> existingFaqs, Faq newFaq,
            string parameterName)
        {
            if (existingFaqs.Any(a => a.FaqId == newFaq.FaqId))
            {
                throw new DuplicateFaqException("Cannot add duplicate faq.", parameterName);
            }
        }
    }
}