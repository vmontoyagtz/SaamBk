using System;

namespace SaamApp.BlazorMauiShared.Models.TemplateType
{
    public class DeleteTemplateTypeResponse : BaseResponse
    {
        public DeleteTemplateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTemplateTypeResponse()
        {
        }
    }
}