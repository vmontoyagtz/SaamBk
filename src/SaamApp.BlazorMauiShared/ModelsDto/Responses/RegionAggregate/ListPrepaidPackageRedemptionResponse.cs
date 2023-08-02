using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption
{
    public class ListPrepaidPackageRedemptionResponse : BaseResponse
    {
        public ListPrepaidPackageRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListPrepaidPackageRedemptionResponse()
        {
        }

        public List<PrepaidPackageRedemptionDto> PrepaidPackageRedemptions { get; set; } = new();

        public int Count { get; set; }
    }
}