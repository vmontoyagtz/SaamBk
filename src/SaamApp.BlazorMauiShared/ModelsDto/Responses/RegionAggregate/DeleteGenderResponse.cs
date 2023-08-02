using System;

namespace SaamApp.BlazorMauiShared.Models.Gender
{
    public class DeleteGenderResponse : BaseResponse
    {
        public DeleteGenderResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteGenderResponse()
        {
        }
    }
}