using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustment
{
    public class ListAccountAdjustmentResponse : BaseResponse
    {
        public ListAccountAdjustmentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAccountAdjustmentResponse()
        {
        }

        public List<AccountAdjustmentDto> AccountAdjustments { get; set; } = new();

        public int Count { get; set; }
    }
}