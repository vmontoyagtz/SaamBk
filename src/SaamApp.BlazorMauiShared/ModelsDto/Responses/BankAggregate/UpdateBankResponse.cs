using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Bank
{
    public class UpdateBankResponse : BaseResponse
    {
        public UpdateBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateBankResponse()
        {
        }

        public BankDto Bank { get; set; } = new();
    }
}