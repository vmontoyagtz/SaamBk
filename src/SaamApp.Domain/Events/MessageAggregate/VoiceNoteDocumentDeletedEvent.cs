using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class VoiceNoteDocumentDeletedEvent : BaseDomainEvent
    {
        public VoiceNoteDocumentDeletedEvent(VoiceNoteDocument voiceNoteDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "VoiceNoteDocument";
            Content = JsonConvert.SerializeObject(voiceNoteDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "VoiceNoteDocumentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}