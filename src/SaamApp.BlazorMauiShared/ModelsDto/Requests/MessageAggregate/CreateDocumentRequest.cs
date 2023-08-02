using System;

namespace SaamApp.BlazorMauiShared.Models.Document
{
    public class CreateDocumentRequest : BaseRequest
    {
        public string DocumentUri { get; set; }
        public string DocumentToken { get; set; }
        public string DocumentSecuredUrl { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}