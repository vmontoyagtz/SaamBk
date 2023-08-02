using System;

namespace SaamApp.BlazorMauiShared.Models.BankAccount
{
    public class DeleteBankAccountRequest : BaseRequest
    {
        public Guid BankAccountId { get; set; }
    }
}