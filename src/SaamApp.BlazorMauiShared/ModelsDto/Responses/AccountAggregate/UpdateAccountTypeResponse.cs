using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountType
{
    public class UpdateAccountTypeResponse : BaseResponse
    {
        public UpdateAccountTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAccountTypeResponse()
        {
        }

        public AccountTypeDto AccountType { get; set; } = new();
    }
}