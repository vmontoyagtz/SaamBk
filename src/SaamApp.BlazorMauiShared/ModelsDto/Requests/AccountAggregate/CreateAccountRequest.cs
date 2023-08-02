using System;

namespace SaamApp.BlazorMauiShared.Models.Account
{
    public class CreateAccountRequest : BaseRequest
    {
        public Guid AccountStateTypeId { get; set; }
        public Guid AccountTypeId { get; set; }
        public Guid TaxInformationId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}