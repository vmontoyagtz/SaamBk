using System;

namespace SaamApp.BlazorMauiShared.Models.AccountType
{
    public class CreateAccountTypeRequest : BaseRequest
    {
        public string AccountTypeCode { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountTypeDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}