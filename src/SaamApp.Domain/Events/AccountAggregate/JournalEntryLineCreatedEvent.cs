using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class JournalEntryLineCreatedEvent : BaseDomainEvent
    {
        public JournalEntryLineCreatedEvent(JournalEntryLine journalEntryLine, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "JournalEntryLine";
            Content = JsonConvert.SerializeObject(journalEntryLine, JsonSerializerSettingsSingleton.Instance);
            EventType = "JournalEntryLineCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}