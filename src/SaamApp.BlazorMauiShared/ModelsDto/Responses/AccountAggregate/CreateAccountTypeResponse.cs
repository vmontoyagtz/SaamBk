using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountType
{
    public class CreateAccountTypeResponse : BaseResponse
    {
        public CreateAccountTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAccountTypeResponse()
        {
        }

        public AccountTypeDto AccountType { get; set; } = new();
    }
}