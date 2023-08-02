using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Account
{
    public class CreateAccountResponse : BaseResponse
    {
        public CreateAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAccountResponse()
        {
        }

        public AccountDto Account { get; set; } = new();
    }
}