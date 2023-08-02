using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class VoiceNoteDocumentUpdatedEvent : BaseDomainEvent
    {
        public VoiceNoteDocumentUpdatedEvent(VoiceNoteDocument voiceNoteDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "VoiceNoteDocument";
            Content = JsonConvert.SerializeObject(voiceNoteDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "VoiceNoteDocumentUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}