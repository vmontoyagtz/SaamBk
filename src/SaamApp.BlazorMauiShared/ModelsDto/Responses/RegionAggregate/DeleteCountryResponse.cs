using System;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class DeleteCountryResponse : BaseResponse
    {
        public DeleteCountryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCountryResponse()
        {
        }
    }
}