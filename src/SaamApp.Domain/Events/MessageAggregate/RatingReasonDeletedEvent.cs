using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class RatingReasonDeletedEvent : BaseDomainEvent
    {
        public RatingReasonDeletedEvent(RatingReason ratingReason, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "RatingReason";
            Content = JsonConvert.SerializeObject(ratingReason, JsonSerializerSettingsSingleton.Instance);
            EventType = "RatingReasonDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}