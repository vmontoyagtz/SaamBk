using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateDocument
{
    public class UpdateTemplateDocumentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid TemplateId { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTemplateDocumentRequest FromDto(TemplateDocumentDto templateDocumentDto)
        {
            return new UpdateTemplateDocumentRequest
            {
                RowId = templateDocumentDto.RowId,
                DocumentId = templateDocumentDto.DocumentId,
                DocumentTypeId = templateDocumentDto.DocumentTypeId,
                TemplateId = templateDocumentDto.TemplateId,
                TenantId = templateDocumentDto.TenantId
            };
        }
    }
}