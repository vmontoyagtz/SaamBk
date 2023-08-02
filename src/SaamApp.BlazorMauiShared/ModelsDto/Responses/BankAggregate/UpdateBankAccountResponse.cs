using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BankAccount
{
    public class UpdateBankAccountResponse : BaseResponse
    {
        public UpdateBankAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateBankAccountResponse()
        {
        }

        public BankAccountDto BankAccount { get; set; } = new();
    }
}