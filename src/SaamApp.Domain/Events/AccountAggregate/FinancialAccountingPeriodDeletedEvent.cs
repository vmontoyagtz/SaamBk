using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class FinancialAccountingPeriodDeletedEvent : BaseDomainEvent
    {
        public FinancialAccountingPeriodDeletedEvent(FinancialAccountingPeriod financialAccountingPeriod, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "FinancialAccountingPeriod";
            Content = JsonConvert.SerializeObject(financialAccountingPeriod, JsonSerializerSettingsSingleton.Instance);
            EventType = "FinancialAccountingPeriodDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}