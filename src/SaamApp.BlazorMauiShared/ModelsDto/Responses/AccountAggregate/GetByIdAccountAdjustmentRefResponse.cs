using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef
{
    public class GetByIdAccountAdjustmentRefResponse : BaseResponse
    {
        public GetByIdAccountAdjustmentRefResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAccountAdjustmentRefResponse()
        {
        }

        public AccountAdjustmentRefDto AccountAdjustmentRef { get; set; } = new();
    }
}