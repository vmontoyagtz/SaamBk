using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Area
{
    public class UpdateAreaResponse : BaseResponse
    {
        public UpdateAreaResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAreaResponse()
        {
        }

        public AreaDto Area { get; set; } = new();
    }
}