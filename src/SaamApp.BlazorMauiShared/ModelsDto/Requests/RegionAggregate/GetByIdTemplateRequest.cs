using System;

namespace SaamApp.BlazorMauiShared.Models.Template
{
    public class GetByIdTemplateRequest : BaseRequest
    {
        public Guid TemplateId { get; set; }
    }
}