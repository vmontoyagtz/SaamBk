using System;

namespace SaamApp.Domain.Exceptions
{
    public class VoiceNoteDocumentNotFoundException : Exception
    {
        public VoiceNoteDocumentNotFoundException(string message) : base(message)
        {
        }

        public VoiceNoteDocumentNotFoundException(int rowId) : base($"No voiceNoteDocument with id {rowId} found.")
        {
        }
    }
}