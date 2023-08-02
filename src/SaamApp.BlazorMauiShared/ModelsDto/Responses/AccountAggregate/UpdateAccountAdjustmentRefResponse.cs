using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef
{
    public class UpdateAccountAdjustmentRefResponse : BaseResponse
    {
        public UpdateAccountAdjustmentRefResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAccountAdjustmentRefResponse()
        {
        }

        public AccountAdjustmentRefDto AccountAdjustmentRef { get; set; } = new();
    }
}