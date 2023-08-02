using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class JournalEntryLineUpdatedEvent : BaseDomainEvent
    {
        public JournalEntryLineUpdatedEvent(JournalEntryLine journalEntryLine, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "JournalEntryLine";
            Content = JsonConvert.SerializeObject(journalEntryLine, JsonSerializerSettingsSingleton.Instance);
            EventType = "JournalEntryLineUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}