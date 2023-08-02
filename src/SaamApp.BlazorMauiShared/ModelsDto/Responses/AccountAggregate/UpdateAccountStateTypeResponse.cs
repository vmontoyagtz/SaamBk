using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountStateType
{
    public class UpdateAccountStateTypeResponse : BaseResponse
    {
        public UpdateAccountStateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAccountStateTypeResponse()
        {
        }

        public AccountStateTypeDto AccountStateType { get; set; } = new();
    }
}