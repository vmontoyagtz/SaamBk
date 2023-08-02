using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitDocument
{
    public class GetByIdBusinessUnitDocumentResponse : BaseResponse
    {
        public GetByIdBusinessUnitDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdBusinessUnitDocumentResponse()
        {
        }

        public BusinessUnitDocumentDto BusinessUnitDocument { get; set; } = new();
    }
}