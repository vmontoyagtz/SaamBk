using System;

namespace SaamApp.BlazorMauiShared.Models.BankAccount
{
    public class GetByIdBankAccountRequest : BaseRequest
    {
        public Guid BankAccountId { get; set; }
    }
}