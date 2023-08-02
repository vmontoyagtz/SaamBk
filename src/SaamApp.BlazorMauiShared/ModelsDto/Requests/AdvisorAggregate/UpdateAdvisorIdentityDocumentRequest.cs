using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument
{
    public class UpdateAdvisorIdentityDocumentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid IdentityDocumentId { get; set; }

        public static UpdateAdvisorIdentityDocumentRequest FromDto(
            AdvisorIdentityDocumentDto advisorIdentityDocumentDto)
        {
            return new UpdateAdvisorIdentityDocumentRequest
            {
                RowId = advisorIdentityDocumentDto.RowId,
                AdvisorId = advisorIdentityDocumentDto.AdvisorId,
                DocumentId = advisorIdentityDocumentDto.DocumentId,
                DocumentTypeId = advisorIdentityDocumentDto.DocumentTypeId,
                IdentityDocumentId = advisorIdentityDocumentDto.IdentityDocumentId
            };
        }
    }
}