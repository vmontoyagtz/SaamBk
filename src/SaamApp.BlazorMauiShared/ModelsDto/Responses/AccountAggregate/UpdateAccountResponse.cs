using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Account
{
    public class UpdateAccountResponse : BaseResponse
    {
        public UpdateAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAccountResponse()
        {
        }

        public AccountDto Account { get; set; } = new();
    }
}