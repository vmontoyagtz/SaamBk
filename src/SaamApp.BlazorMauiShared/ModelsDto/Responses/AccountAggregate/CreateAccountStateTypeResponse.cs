using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountStateType
{
    public class CreateAccountStateTypeResponse : BaseResponse
    {
        public CreateAccountStateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAccountStateTypeResponse()
        {
        }

        public AccountStateTypeDto AccountStateType { get; set; } = new();
    }
}