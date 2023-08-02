using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class RegionAreaAdvisorCategoryDeletedEvent : BaseDomainEvent
    {
        public RegionAreaAdvisorCategoryDeletedEvent(RegionAreaAdvisorCategory regionAreaAdvisorCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "RegionAreaAdvisorCategory";
            Content = JsonConvert.SerializeObject(regionAreaAdvisorCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "RegionAreaAdvisorCategoryDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}