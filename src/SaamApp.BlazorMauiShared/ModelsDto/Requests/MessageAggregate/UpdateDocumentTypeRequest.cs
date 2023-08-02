using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DocumentType
{
    public class UpdateDocumentTypeRequest : BaseRequest
    {
        public Guid DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string? DocumentTypeDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateDocumentTypeRequest FromDto(DocumentTypeDto documentTypeDto)
        {
            return new UpdateDocumentTypeRequest
            {
                DocumentTypeId = documentTypeDto.DocumentTypeId,
                DocumentTypeName = documentTypeDto.DocumentTypeName,
                DocumentTypeDescription = documentTypeDto.DocumentTypeDescription,
                TenantId = documentTypeDto.TenantId
            };
        }
    }
}