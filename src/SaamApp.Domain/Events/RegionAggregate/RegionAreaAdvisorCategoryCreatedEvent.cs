using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class RegionAreaAdvisorCategoryCreatedEvent : BaseDomainEvent
    {
        public RegionAreaAdvisorCategoryCreatedEvent(RegionAreaAdvisorCategory regionAreaAdvisorCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "RegionAreaAdvisorCategory";
            Content = JsonConvert.SerializeObject(regionAreaAdvisorCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "RegionAreaAdvisorCategoryCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}