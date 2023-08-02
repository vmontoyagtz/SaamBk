using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitDocument
{
    public class UpdateBusinessUnitDocumentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid BusinessUnitId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }

        public static UpdateBusinessUnitDocumentRequest FromDto(BusinessUnitDocumentDto businessUnitDocumentDto)
        {
            return new UpdateBusinessUnitDocumentRequest
            {
                RowId = businessUnitDocumentDto.RowId,
                BusinessUnitId = businessUnitDocumentDto.BusinessUnitId,
                DocumentId = businessUnitDocumentDto.DocumentId,
                DocumentTypeId = businessUnitDocumentDto.DocumentTypeId
            };
        }
    }
}