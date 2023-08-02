using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitDocumentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteBusinessUnitDocumentRequest>.WithActionResult<
        DeleteBusinessUnitDocumentResponse>
    {
        private readonly IRepository<BusinessUnitDocument> _businessUnitDocumentReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitDocument> _repository;

        public Delete(IRepository<BusinessUnitDocument> BusinessUnitDocumentRepository,
            IRepository<BusinessUnitDocument> BusinessUnitDocumentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = BusinessUnitDocumentRepository;
            _businessUnitDocumentReadRepository = BusinessUnitDocumentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/businessUnitDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an BusinessUnitDocument",
            Description = "Deletes an BusinessUnitDocument",
            OperationId = "businessUnitDocuments.delete",
            Tags = new[] { "BusinessUnitDocumentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteBusinessUnitDocumentResponse>> HandleAsync(
            [FromRoute] DeleteBusinessUnitDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBusinessUnitDocumentResponse(request.CorrelationId());

            var businessUnitDocument = await _businessUnitDocumentReadRepository.GetByIdAsync(request.RowId);

            if (businessUnitDocument == null)
            {
                return NotFound();
            }


            var businessUnitDocumentDeletedEvent =
                new BusinessUnitDocumentDeletedEvent(businessUnitDocument, "Mongo-History");
            _messagePublisher.Publish(businessUnitDocumentDeletedEvent);

            await _repository.DeleteAsync(businessUnitDocument);

            return Ok(response);
        }
    }
}