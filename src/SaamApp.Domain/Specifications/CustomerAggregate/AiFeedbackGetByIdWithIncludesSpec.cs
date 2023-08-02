using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiFeedbackByIdWithIncludesSpec : Specification<AiFeedback>, ISingleResultSpecification
    {
        public AiFeedbackByIdWithIncludesSpec(Guid aiFeedbackId)
        {
            Guard.Against.NullOrEmpty(aiFeedbackId, nameof(aiFeedbackId));
            Query.Where(aiFeedback => aiFeedback.AiFeedbackId == aiFeedbackId)
                .Include(a => a.Customer)
                .AsNoTracking();
        }
    }
}