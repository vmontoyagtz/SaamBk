using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateVoiceNoteDocumentException : ArgumentException
    {
        public DuplicateVoiceNoteDocumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}