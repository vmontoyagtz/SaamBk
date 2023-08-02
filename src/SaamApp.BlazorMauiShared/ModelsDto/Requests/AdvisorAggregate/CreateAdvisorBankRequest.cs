using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBank
{
    public class CreateAdvisorBankRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid BankAccountId { get; set; }
        public bool IsDefault { get; set; }
    }
}