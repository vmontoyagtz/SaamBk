using System;

namespace SaamApp.BlazorMauiShared.Models.Bank
{
    public class CreateBankRequest : BaseRequest
    {
        public string BankName { get; set; }
        public string? BankSwiftCodeInfo { get; set; }
        public string BankAddress { get; set; }
        public string BankPhoneNumber { get; set; }
        public string BankEmailAddress { get; set; }
        public string BankNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}