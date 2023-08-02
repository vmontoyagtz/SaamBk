using System;

namespace SaamApp.BlazorMauiShared.Models.Comission
{
    public class DeleteComissionResponse : BaseResponse
    {
        public DeleteComissionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteComissionResponse()
        {
        }
    }
}