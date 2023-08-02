using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.State
{
    public class GetByIdStateResponse : BaseResponse
    {
        public GetByIdStateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdStateResponse()
        {
        }

        public StateDto State { get; set; } = new();
    }
}