using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BankAccount
{
    public class ListBankAccountResponse : BaseResponse
    {
        public ListBankAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListBankAccountResponse()
        {
        }

        public List<BankAccountDto> BankAccounts { get; set; } = new();

        public int Count { get; set; }
    }
}