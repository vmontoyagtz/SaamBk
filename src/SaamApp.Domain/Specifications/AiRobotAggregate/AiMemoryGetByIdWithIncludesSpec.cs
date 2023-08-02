using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiMemoryByIdWithIncludesSpec : Specification<AiMemory>, ISingleResultSpecification
    {
        public AiMemoryByIdWithIncludesSpec(Guid aiMemoryId)
        {
            Guard.Against.NullOrEmpty(aiMemoryId, nameof(aiMemoryId));
            Query.Where(aiMemory => aiMemory.AiMemoryId == aiMemoryId)
                .AsNoTracking();
        }
    }
}