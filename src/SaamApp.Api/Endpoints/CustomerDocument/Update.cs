using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerDocumentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerDocumentRequest>.WithActionResult<
        UpdateCustomerDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerDocument> _repository;

        public Update(
            IRepository<CustomerDocument> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerDocuments")]
        [SwaggerOperation(
            Summary = "Updates a CustomerDocument",
            Description = "Updates a CustomerDocument",
            OperationId = "customerDocuments.update",
            Tags = new[] { "CustomerDocumentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerDocumentResponse>> HandleAsync(
            UpdateCustomerDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerDocumentResponse(request.CorrelationId());

            var cdudsdToUpdate = _mapper.Map<CustomerDocument>(request);

            var customerDocumentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (customerDocumentToUpdateTest is null)
            {
                return NotFound();
            }

            //cdudsdToUpdate.UpdateCustomerForCustomerDocument(request.CustomerId);
            //cdudsdToUpdate.UpdateDocumentForCustomerDocument(request.DocumentId);
            //cdudsdToUpdate.UpdateDocumentTypeForCustomerDocument(request.DocumentTypeId);
            await _repository.UpdateAsync(cdudsdToUpdate);

            var customerDocumentUpdatedEvent = new CustomerDocumentUpdatedEvent(cdudsdToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerDocumentUpdatedEvent);

            var dto = _mapper.Map<CustomerDocumentDto>(cdudsdToUpdate);
            response.CustomerDocument = dto;

            return Ok(response);
        }
    }
}