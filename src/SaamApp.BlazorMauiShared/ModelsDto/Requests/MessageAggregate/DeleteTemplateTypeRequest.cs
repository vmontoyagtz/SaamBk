using System;

namespace SaamApp.BlazorMauiShared.Models.TemplateType
{
    public class DeleteTemplateTypeRequest : BaseRequest
    {
        public Guid TemplateTypeId { get; set; }
    }
}