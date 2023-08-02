using System;

namespace SaamApp.BlazorMauiShared.Models.IdentityDocument
{
    public class CreateIdentityDocumentRequest : BaseRequest
    {
        public Guid CountryId { get; set; }
        public string IdentityDocumentName { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public string? IdentityDocumentDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}