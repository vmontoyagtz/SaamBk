using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo
{
    public class CreateAdvisorBankTransferInfoRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid BankAccountId { get; set; }
        public string? BankTransferNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}