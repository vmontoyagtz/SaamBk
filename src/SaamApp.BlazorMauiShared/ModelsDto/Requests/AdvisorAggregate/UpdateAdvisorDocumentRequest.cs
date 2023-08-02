using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorDocument
{
    public class UpdateAdvisorDocumentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }

        public static UpdateAdvisorDocumentRequest FromDto(AdvisorDocumentDto advisorDocumentDto)
        {
            return new UpdateAdvisorDocumentRequest
            {
                RowId = advisorDocumentDto.RowId,
                AdvisorId = advisorDocumentDto.AdvisorId,
                DocumentId = advisorDocumentDto.DocumentId,
                DocumentTypeId = advisorDocumentDto.DocumentTypeId
            };
        }
    }
}