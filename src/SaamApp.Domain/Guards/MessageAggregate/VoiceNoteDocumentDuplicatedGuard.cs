using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class VoiceNoteDocumentGuardExtensions
    {
        public static void DuplicateVoiceNoteDocument(this IGuardClause guardClause,
            IEnumerable<VoiceNoteDocument> existingVoiceNoteDocuments, VoiceNoteDocument newVoiceNoteDocument,
            string parameterName)
        {
            if (existingVoiceNoteDocuments.Any(a => a.RowId == newVoiceNoteDocument.RowId))
            {
                throw new DuplicateVoiceNoteDocumentException("Cannot add duplicate voiceNoteDocument.", parameterName);
            }
        }
    }
}