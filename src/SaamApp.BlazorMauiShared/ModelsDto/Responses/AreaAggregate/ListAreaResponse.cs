using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Area
{
    public class ListAreaResponse : BaseResponse
    {
        public ListAreaResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAreaResponse()
        {
        }

        public List<AreaDto> Areas { get; set; } = new();

        public int Count { get; set; }
    }
}