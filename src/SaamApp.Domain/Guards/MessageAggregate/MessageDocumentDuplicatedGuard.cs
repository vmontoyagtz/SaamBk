using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class MessageDocumentGuardExtensions
    {
        public static void DuplicateMessageDocument(this IGuardClause guardClause,
            IEnumerable<MessageDocument> existingMessageDocuments, MessageDocument newMessageDocument,
            string parameterName)
        {
            if (existingMessageDocuments.Any(a => a.RowId == newMessageDocument.RowId))
            {
                throw new DuplicateMessageDocumentException("Cannot add duplicate messageDocument.", parameterName);
            }
        }
    }
}