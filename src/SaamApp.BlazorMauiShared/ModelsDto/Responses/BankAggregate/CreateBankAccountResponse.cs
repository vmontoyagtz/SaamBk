using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BankAccount
{
    public class CreateBankAccountResponse : BaseResponse
    {
        public CreateBankAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateBankAccountResponse()
        {
        }

        public BankAccountDto BankAccount { get; set; } = new();
    }
}