using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAiInteractionWithUserSessionKeySpec : Specification<AiInteraction>
    {
        public GetAiInteractionWithUserSessionKeySpec(Guid sessionId)
        {
            Guard.Against.NullOrEmpty(sessionId, nameof(sessionId));
            Query.Where(ai => ai.SessionId == sessionId).AsNoTracking();
        }
    }
}