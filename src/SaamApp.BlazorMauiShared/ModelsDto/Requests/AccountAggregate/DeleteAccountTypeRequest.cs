using System;

namespace SaamApp.BlazorMauiShared.Models.AccountType
{
    public class DeleteAccountTypeRequest : BaseRequest
    {
        public Guid AccountTypeId { get; set; }
    }
}