using System;

namespace SaamApp.BlazorMauiShared.Models.Bank
{
    public class DeleteBankRequest : BaseRequest
    {
        public Guid BankId { get; set; }
    }
}