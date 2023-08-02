using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustment
{
    public class UpdateAccountAdjustmentResponse : BaseResponse
    {
        public UpdateAccountAdjustmentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAccountAdjustmentResponse()
        {
        }

        public AccountAdjustmentDto AccountAdjustment { get; set; } = new();
    }
}