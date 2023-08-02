using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.IdentityDocument
{
    public class ListIdentityDocumentResponse : BaseResponse
    {
        public ListIdentityDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListIdentityDocumentResponse()
        {
        }

        public List<IdentityDocumentDto> IdentityDocuments { get; set; } = new();

        public int Count { get; set; }
    }
}