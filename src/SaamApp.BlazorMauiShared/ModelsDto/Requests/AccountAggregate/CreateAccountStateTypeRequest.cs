using System;

namespace SaamApp.BlazorMauiShared.Models.AccountStateType
{
    public class CreateAccountStateTypeRequest : BaseRequest
    {
        public string AccountStateTypeCode { get; set; }
        public string AccountStateTypeName { get; set; }
        public string? AccountStateTypeDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}