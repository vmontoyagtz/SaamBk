using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiModelByIdWithIncludesSpec : Specification<AiModel>, ISingleResultSpecification
    {
        public AiModelByIdWithIncludesSpec(Guid aiModelId)
        {
            Guard.Against.NullOrEmpty(aiModelId, nameof(aiModelId));
            Query.Where(aiModel => aiModel.AiModelId == aiModelId)
                .OrderBy(aiModel => aiModel.ModelName)
                .AsNoTracking();
        }
    }
}