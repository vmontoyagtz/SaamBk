using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Area
{
    public class GetByIdAreaResponse : BaseResponse
    {
        public GetByIdAreaResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAreaResponse()
        {
        }

        public AreaDto Area { get; set; } = new();
    }
}