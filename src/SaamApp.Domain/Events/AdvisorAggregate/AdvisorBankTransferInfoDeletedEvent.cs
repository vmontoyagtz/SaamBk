using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorBankTransferInfoDeletedEvent : BaseDomainEvent
    {
        public AdvisorBankTransferInfoDeletedEvent(AdvisorBankTransferInfo advisorBankTransferInfo, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorBankTransferInfo";
            Content = JsonConvert.SerializeObject(advisorBankTransferInfo, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorBankTransferInfoDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}