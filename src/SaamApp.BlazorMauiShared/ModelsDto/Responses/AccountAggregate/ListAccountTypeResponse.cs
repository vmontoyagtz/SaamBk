using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountType
{
    public class ListAccountTypeResponse : BaseResponse
    {
        public ListAccountTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAccountTypeResponse()
        {
        }

        public List<AccountTypeDto> AccountTypes { get; set; } = new();

        public int Count { get; set; }
    }
}