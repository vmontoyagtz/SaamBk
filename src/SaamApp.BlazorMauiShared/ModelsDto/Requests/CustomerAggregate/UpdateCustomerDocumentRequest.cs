using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerDocument
{
    public class UpdateCustomerDocumentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }

        public static UpdateCustomerDocumentRequest FromDto(CustomerDocumentDto customerDocumentDto)
        {
            return new UpdateCustomerDocumentRequest
            {
                RowId = customerDocumentDto.RowId,
                CustomerId = customerDocumentDto.CustomerId,
                DocumentId = customerDocumentDto.DocumentId,
                DocumentTypeId = customerDocumentDto.DocumentTypeId
            };
        }
    }
}