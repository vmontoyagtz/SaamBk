using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Account
{
    public class GetByIdAccountResponse : BaseResponse
    {
        public GetByIdAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAccountResponse()
        {
        }

        public AccountDto Account { get; set; } = new();
    }
}