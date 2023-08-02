using System;

namespace SaamApp.BlazorMauiShared.Models.BankAccount
{
    public class CreateBankAccountRequest : BaseRequest
    {
        public Guid BankId { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountNotificationPhoneNumber { get; set; }
        public string BankAccountNotificationEmailAddress { get; set; }
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public Guid TenantId { get; set; }
    }
}