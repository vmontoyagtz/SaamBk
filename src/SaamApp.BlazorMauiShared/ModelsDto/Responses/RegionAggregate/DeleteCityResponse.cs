using System;

namespace SaamApp.BlazorMauiShared.Models.City
{
    public class DeleteCityResponse : BaseResponse
    {
        public DeleteCityResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCityResponse()
        {
        }
    }
}