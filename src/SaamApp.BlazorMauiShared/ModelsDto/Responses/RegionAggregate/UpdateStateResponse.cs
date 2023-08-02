using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.State
{
    public class UpdateStateResponse : BaseResponse
    {
        public UpdateStateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateStateResponse()
        {
        }

        public StateDto State { get; set; } = new();
    }
}