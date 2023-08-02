using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountStateType
{
    public class ListAccountStateTypeResponse : BaseResponse
    {
        public ListAccountStateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAccountStateTypeResponse()
        {
        }

        public List<AccountStateTypeDto> AccountStateTypes { get; set; } = new();

        public int Count { get; set; }
    }
}