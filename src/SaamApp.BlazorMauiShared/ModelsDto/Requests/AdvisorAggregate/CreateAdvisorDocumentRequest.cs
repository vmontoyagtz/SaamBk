using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorDocument
{
    public class CreateAdvisorDocumentRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
    }
}