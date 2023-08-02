using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustment
{
    public class GetByIdAccountAdjustmentResponse : BaseResponse
    {
        public GetByIdAccountAdjustmentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAccountAdjustmentResponse()
        {
        }

        public AccountAdjustmentDto AccountAdjustment { get; set; } = new();
    }
}