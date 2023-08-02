using System;

namespace SaamApp.BlazorMauiShared.Models.Template
{
    public class DeleteTemplateResponse : BaseResponse
    {
        public DeleteTemplateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTemplateResponse()
        {
        }
    }
}