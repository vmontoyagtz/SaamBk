using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountStateType
{
    public class GetByIdAccountStateTypeResponse : BaseResponse
    {
        public GetByIdAccountStateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAccountStateTypeResponse()
        {
        }

        public AccountStateTypeDto AccountStateType { get; set; } = new();
    }
}