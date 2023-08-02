using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Comission
{
    public class ListComissionResponse : BaseResponse
    {
        public ListComissionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListComissionResponse()
        {
        }

        public List<ComissionDto> Comissions { get; set; } = new();

        public int Count { get; set; }
    }
}