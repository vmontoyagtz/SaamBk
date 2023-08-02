using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitDocument
{
    public class UpdateBusinessUnitDocumentResponse : BaseResponse
    {
        public UpdateBusinessUnitDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateBusinessUnitDocumentResponse()
        {
        }

        public BusinessUnitDocumentDto BusinessUnitDocument { get; set; } = new();
    }
}