using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.IdentityDocument
{
    public class UpdateIdentityDocumentRequest : BaseRequest
    {
        public Guid IdentityDocumentId { get; set; }
        public Guid CountryId { get; set; }
        public string IdentityDocumentName { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public string? IdentityDocumentDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateIdentityDocumentRequest FromDto(IdentityDocumentDto identityDocumentDto)
        {
            return new UpdateIdentityDocumentRequest
            {
                IdentityDocumentId = identityDocumentDto.IdentityDocumentId,
                CountryId = identityDocumentDto.CountryId,
                IdentityDocumentName = identityDocumentDto.IdentityDocumentName,
                IdentityDocumentNumber = identityDocumentDto.IdentityDocumentNumber,
                IdentityDocumentDescription = identityDocumentDto.IdentityDocumentDescription,
                TenantId = identityDocumentDto.TenantId
            };
        }
    }
}