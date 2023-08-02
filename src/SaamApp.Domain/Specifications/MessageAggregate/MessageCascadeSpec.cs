using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetMessageDocumentWithMessageKeySpec : Specification<MessageDocument>
    {
        public GetMessageDocumentWithMessageKeySpec(Guid messageId)
        {
            Guard.Against.NullOrEmpty(messageId, nameof(messageId));
            Query.Where(md => md.MessageId == messageId).AsNoTracking();
        }
    }

    public class GetVoiceNoteDocumentWithMessageKeySpec : Specification<VoiceNoteDocument>
    {
        public GetVoiceNoteDocumentWithMessageKeySpec(Guid messageId)
        {
            Guard.Against.NullOrEmpty(messageId, nameof(messageId));
            Query.Where(vnd => vnd.MessageId == messageId).AsNoTracking();
        }
    }
}