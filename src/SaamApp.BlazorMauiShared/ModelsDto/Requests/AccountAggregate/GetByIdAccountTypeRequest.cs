using System;

namespace SaamApp.BlazorMauiShared.Models.AccountType
{
    public class GetByIdAccountTypeRequest : BaseRequest
    {
        public Guid AccountTypeId { get; set; }
    }
}