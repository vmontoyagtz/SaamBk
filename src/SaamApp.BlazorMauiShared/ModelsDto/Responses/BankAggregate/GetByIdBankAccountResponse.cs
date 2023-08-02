using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BankAccount
{
    public class GetByIdBankAccountResponse : BaseResponse
    {
        public GetByIdBankAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdBankAccountResponse()
        {
        }

        public BankAccountDto BankAccount { get; set; } = new();
    }
}