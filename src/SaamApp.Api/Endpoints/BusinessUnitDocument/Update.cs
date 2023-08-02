using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.BusinessUnitDocumentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateBusinessUnitDocumentRequest>.WithActionResult<
        UpdateBusinessUnitDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitDocument> _repository;

        public Update(
            IRepository<BusinessUnitDocument> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/businessUnitDocuments")]
        [SwaggerOperation(
            Summary = "Updates a BusinessUnitDocument",
            Description = "Updates a BusinessUnitDocument",
            OperationId = "businessUnitDocuments.update",
            Tags = new[] { "BusinessUnitDocumentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateBusinessUnitDocumentResponse>> HandleAsync(
            UpdateBusinessUnitDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateBusinessUnitDocumentResponse(request.CorrelationId());

            var buduudsudToUpdate = _mapper.Map<BusinessUnitDocument>(request);

            var businessUnitDocumentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitDocumentToUpdateTest is null)
            {
                return NotFound();
            }

            //buduudsudToUpdate.UpdateBusinessUnitForBusinessUnitDocument(request.BusinessUnitId);
            //buduudsudToUpdate.UpdateDocumentForBusinessUnitDocument(request.DocumentId);
            //buduudsudToUpdate.UpdateDocumentTypeForBusinessUnitDocument(request.DocumentTypeId);
            await _repository.UpdateAsync(buduudsudToUpdate);

            var businessUnitDocumentUpdatedEvent =
                new BusinessUnitDocumentUpdatedEvent(buduudsudToUpdate, "Mongo-History");
            _messagePublisher.Publish(businessUnitDocumentUpdatedEvent);

            var dto = _mapper.Map<BusinessUnitDocumentDto>(buduudsudToUpdate);
            response.BusinessUnitDocument = dto;

            return Ok(response);
        }
    }
}