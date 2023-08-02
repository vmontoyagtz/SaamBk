using System;

namespace SaamApp.BlazorMauiShared.Models.Bank
{
    public class GetByIdBankRequest : BaseRequest
    {
        public Guid BankId { get; set; }
    }
}