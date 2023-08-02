using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorRatingDeletedEvent : BaseDomainEvent
    {
        public AdvisorRatingDeletedEvent(AdvisorRating advisorRating, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorRating";
            Content = JsonConvert.SerializeObject(advisorRating, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorRatingDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}