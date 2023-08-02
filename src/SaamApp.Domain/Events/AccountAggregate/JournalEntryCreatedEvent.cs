using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class JournalEntryCreatedEvent : BaseDomainEvent
    {
        public JournalEntryCreatedEvent(JournalEntry journalEntry, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "JournalEntry";
            Content = JsonConvert.SerializeObject(journalEntry, JsonSerializerSettingsSingleton.Instance);
            EventType = "JournalEntryCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}