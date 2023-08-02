using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class JournalEntryUpdatedEvent : BaseDomainEvent
    {
        public JournalEntryUpdatedEvent(JournalEntry journalEntry, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "JournalEntry";
            Content = JsonConvert.SerializeObject(journalEntry, JsonSerializerSettingsSingleton.Instance);
            EventType = "JournalEntryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}