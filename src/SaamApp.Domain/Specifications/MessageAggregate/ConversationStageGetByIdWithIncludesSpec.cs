using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ConversationStageByIdWithIncludesSpec : Specification<ConversationStage>, ISingleResultSpecification
    {
        public ConversationStageByIdWithIncludesSpec(Guid conversationStageId)
        {
            Guard.Against.NullOrEmpty(conversationStageId, nameof(conversationStageId));
            Query.Where(conversationStage => conversationStage.ConversationStageId == conversationStageId)
                .AsNoTracking();
        }
    }
}