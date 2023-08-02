using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Document
{
    public class UpdateDocumentRequest : BaseRequest
    {
        public Guid DocumentId { get; set; }
        public string DocumentUri { get; set; }
        public string DocumentToken { get; set; }
        public string DocumentSecuredUrl { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateDocumentRequest FromDto(DocumentDto documentDto)
        {
            return new UpdateDocumentRequest
            {
                DocumentId = documentDto.DocumentId,
                DocumentUri = documentDto.DocumentUri,
                DocumentToken = documentDto.DocumentToken,
                DocumentSecuredUrl = documentDto.DocumentSecuredUrl,
                DocumentTitle = documentDto.DocumentTitle,
                DocumentDescription = documentDto.DocumentDescription,
                TenantId = documentDto.TenantId
            };
        }
    }
}