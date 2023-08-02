using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustment
{
    public class CreateAccountAdjustmentResponse : BaseResponse
    {
        public CreateAccountAdjustmentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAccountAdjustmentResponse()
        {
        }

        public AccountAdjustmentDto AccountAdjustment { get; set; } = new();
    }
}