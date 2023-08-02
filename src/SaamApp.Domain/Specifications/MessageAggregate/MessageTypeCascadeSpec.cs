using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetMessageWithMessageTypeKeySpec : Specification<Message>
    {
        public GetMessageWithMessageTypeKeySpec(Guid messageTypeId)
        {
            Guard.Against.NullOrEmpty(messageTypeId, nameof(messageTypeId));
            Query.Where(m => m.MessageTypeId == messageTypeId).AsNoTracking();
        }
    }
}