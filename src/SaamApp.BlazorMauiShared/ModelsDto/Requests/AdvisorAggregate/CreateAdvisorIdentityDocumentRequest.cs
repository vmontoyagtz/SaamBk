using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument
{
    public class CreateAdvisorIdentityDocumentRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid IdentityDocumentId { get; set; }
    }
}