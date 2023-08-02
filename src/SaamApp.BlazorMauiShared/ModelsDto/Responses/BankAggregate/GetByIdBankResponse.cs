using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Bank
{
    public class GetByIdBankResponse : BaseResponse
    {
        public GetByIdBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdBankResponse()
        {
        }

        public BankDto Bank { get; set; } = new();
    }
}