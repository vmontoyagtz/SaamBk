using System;

namespace SaamApp.BlazorMauiShared.Models.Template
{
    public class DeleteTemplateRequest : BaseRequest
    {
        public Guid TemplateId { get; set; }
    }
}