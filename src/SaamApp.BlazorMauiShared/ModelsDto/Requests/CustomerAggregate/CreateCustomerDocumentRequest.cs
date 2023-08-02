using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerDocument
{
    public class CreateCustomerDocumentRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
    }
}