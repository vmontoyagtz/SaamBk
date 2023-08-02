using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountType
{
    public class GetByIdAccountTypeResponse : BaseResponse
    {
        public GetByIdAccountTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAccountTypeResponse()
        {
        }

        public AccountTypeDto AccountType { get; set; } = new();
    }
}