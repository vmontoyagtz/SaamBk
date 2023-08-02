using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitDocument
{
    public class CreateBusinessUnitDocumentRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
    }
}