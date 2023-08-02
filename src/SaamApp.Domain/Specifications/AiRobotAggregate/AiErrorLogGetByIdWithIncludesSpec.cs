using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiErrorLogByIdWithIncludesSpec : Specification<AiErrorLog>, ISingleResultSpecification
    {
        public AiErrorLogByIdWithIncludesSpec(Guid aiErrorLogId)
        {
            Guard.Against.NullOrEmpty(aiErrorLogId, nameof(aiErrorLogId));
            Query.Where(aiErrorLog => aiErrorLog.AiErrorLogId == aiErrorLogId)
                .AsNoTracking();
        }
    }
}