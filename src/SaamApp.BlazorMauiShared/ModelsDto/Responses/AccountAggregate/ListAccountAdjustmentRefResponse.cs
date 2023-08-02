using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef
{
    public class ListAccountAdjustmentRefResponse : BaseResponse
    {
        public ListAccountAdjustmentRefResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAccountAdjustmentRefResponse()
        {
        }

        public List<AccountAdjustmentRefDto> AccountAdjustmentRefs { get; set; } = new();

        public int Count { get; set; }
    }
}