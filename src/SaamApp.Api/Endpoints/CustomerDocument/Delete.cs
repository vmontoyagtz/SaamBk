using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerDocumentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerDocumentRequest>.WithActionResult<
        DeleteCustomerDocumentResponse>
    {
        private readonly IRepository<CustomerDocument> _customerDocumentReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerDocument> _repository;

        public Delete(IRepository<CustomerDocument> CustomerDocumentRepository,
            IRepository<CustomerDocument> CustomerDocumentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerDocumentRepository;
            _customerDocumentReadRepository = CustomerDocumentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerDocument",
            Description = "Deletes an CustomerDocument",
            OperationId = "customerDocuments.delete",
            Tags = new[] { "CustomerDocumentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerDocumentResponse>> HandleAsync(
            [FromRoute] DeleteCustomerDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerDocumentResponse(request.CorrelationId());

            var customerDocument = await _customerDocumentReadRepository.GetByIdAsync(request.RowId);

            if (customerDocument == null)
            {
                return NotFound();
            }


            var customerDocumentDeletedEvent = new CustomerDocumentDeletedEvent(customerDocument, "Mongo-History");
            _messagePublisher.Publish(customerDocumentDeletedEvent);

            await _repository.DeleteAsync(customerDocument);

            return Ok(response);
        }
    }
}