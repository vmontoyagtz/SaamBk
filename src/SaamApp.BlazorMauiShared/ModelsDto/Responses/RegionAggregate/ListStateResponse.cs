using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.State
{
    public class ListStateResponse : BaseResponse
    {
        public ListStateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListStateResponse()
        {
        }

        public List<StateDto> States { get; set; } = new();

        public int Count { get; set; }
    }
}