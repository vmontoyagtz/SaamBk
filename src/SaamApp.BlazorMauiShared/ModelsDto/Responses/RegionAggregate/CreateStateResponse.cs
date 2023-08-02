using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.State
{
    public class CreateStateResponse : BaseResponse
    {
        public CreateStateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateStateResponse()
        {
        }

        public StateDto State { get; set; } = new();
    }
}