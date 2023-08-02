using System;

namespace SaamApp.BlazorMauiShared.Models.TemplateType
{
    public class GetByIdTemplateTypeRequest : BaseRequest
    {
        public Guid TemplateTypeId { get; set; }
    }
}