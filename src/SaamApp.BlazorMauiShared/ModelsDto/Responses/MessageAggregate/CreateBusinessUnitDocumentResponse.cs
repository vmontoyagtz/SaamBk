using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitDocument
{
    public class CreateBusinessUnitDocumentResponse : BaseResponse
    {
        public CreateBusinessUnitDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateBusinessUnitDocumentResponse()
        {
        }

        public BusinessUnitDocumentDto BusinessUnitDocument { get; set; } = new();
    }
}