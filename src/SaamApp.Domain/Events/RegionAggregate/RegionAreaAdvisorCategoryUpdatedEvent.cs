using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class RegionAreaAdvisorCategoryUpdatedEvent : BaseDomainEvent
    {
        public RegionAreaAdvisorCategoryUpdatedEvent(RegionAreaAdvisorCategory regionAreaAdvisorCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "RegionAreaAdvisorCategory";
            Content = JsonConvert.SerializeObject(regionAreaAdvisorCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "RegionAreaAdvisorCategoryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}