using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Bank
{
    public class CreateBankResponse : BaseResponse
    {
        public CreateBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateBankResponse()
        {
        }

        public BankDto Bank { get; set; } = new();
    }
}