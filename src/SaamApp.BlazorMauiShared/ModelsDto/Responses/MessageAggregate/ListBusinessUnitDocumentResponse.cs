using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitDocument
{
    public class ListBusinessUnitDocumentResponse : BaseResponse
    {
        public ListBusinessUnitDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListBusinessUnitDocumentResponse()
        {
        }

        public List<BusinessUnitDocumentDto> BusinessUnitDocuments { get; set; } = new();

        public int Count { get; set; }
    }
}