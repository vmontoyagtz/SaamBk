using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class FaqByIdWithIncludesSpec : Specification<Faq>, ISingleResultSpecification
    {
        public FaqByIdWithIncludesSpec(Guid faqId)
        {
            Guard.Against.NullOrEmpty(faqId, nameof(faqId));
            Query.Where(faq => faq.FaqId == faqId)
                .AsNoTracking();
        }
    }
}