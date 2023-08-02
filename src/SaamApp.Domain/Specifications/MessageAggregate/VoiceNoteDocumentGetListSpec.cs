using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class VoiceNoteDocumentGetListSpec : Specification<VoiceNoteDocument>
    {
        public VoiceNoteDocumentGetListSpec()
        {
            Query.OrderBy(voiceNoteDocument => voiceNoteDocument.RowId)
                .AsNoTracking();
        }
    }
}