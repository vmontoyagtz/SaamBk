using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class JournalEntryReferenceCreatedEvent : BaseDomainEvent
    {
        public JournalEntryReferenceCreatedEvent(JournalEntryReference journalEntryReference, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "JournalEntryReference";
            Content = JsonConvert.SerializeObject(journalEntryReference, JsonSerializerSettingsSingleton.Instance);
            EventType = "JournalEntryReferenceCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}