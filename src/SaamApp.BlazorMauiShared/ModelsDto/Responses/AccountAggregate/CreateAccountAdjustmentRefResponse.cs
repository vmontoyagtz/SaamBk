using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef
{
    public class CreateAccountAdjustmentRefResponse : BaseResponse
    {
        public CreateAccountAdjustmentRefResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAccountAdjustmentRefResponse()
        {
        }

        public AccountAdjustmentRefDto AccountAdjustmentRef { get; set; } = new();
    }
}