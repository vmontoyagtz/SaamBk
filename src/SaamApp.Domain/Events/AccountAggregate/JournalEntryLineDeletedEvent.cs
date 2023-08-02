using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class JournalEntryLineDeletedEvent : BaseDomainEvent
    {
        public JournalEntryLineDeletedEvent(JournalEntryLine journalEntryLine, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "JournalEntryLine";
            Content = JsonConvert.SerializeObject(journalEntryLine, JsonSerializerSettingsSingleton.Instance);
            EventType = "JournalEntryLineDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}