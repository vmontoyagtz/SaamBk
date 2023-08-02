using System;

namespace SaamApp.BlazorMauiShared.Models.DocumentType
{
    public class GetByIdDocumentTypeRequest : BaseRequest
    {
        public Guid DocumentTypeId { get; set; }
    }
}