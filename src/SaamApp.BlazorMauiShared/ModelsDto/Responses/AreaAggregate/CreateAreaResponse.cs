using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Area
{
    public class CreateAreaResponse : BaseResponse
    {
        public CreateAreaResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAreaResponse()
        {
        }

        public AreaDto Area { get; set; } = new();
    }
}