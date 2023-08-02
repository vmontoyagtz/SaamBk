using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBank
{
    public class GetByRelsIdsAdvisorBankRequest : BaseRequest
    {
        public bool IsDefault { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid BankAccountId { get; set; }
    }
}