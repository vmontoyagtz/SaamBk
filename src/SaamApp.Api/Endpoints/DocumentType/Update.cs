using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DocumentType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.DocumentTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateDocumentTypeRequest>.WithActionResult<
        UpdateDocumentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<DocumentType> _repository;

        public Update(
            IRepository<DocumentType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/documentTypes")]
        [SwaggerOperation(
            Summary = "Updates a DocumentType",
            Description = "Updates a DocumentType",
            OperationId = "documentTypes.update",
            Tags = new[] { "DocumentTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateDocumentTypeResponse>> HandleAsync(
            UpdateDocumentTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateDocumentTypeResponse(request.CorrelationId());

            var dtotctToUpdate = _mapper.Map<DocumentType>(request);

            var documentTypeToUpdateTest = await _repository.GetByIdAsync(request.DocumentTypeId);
            if (documentTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(dtotctToUpdate);

            var documentTypeUpdatedEvent = new DocumentTypeUpdatedEvent(dtotctToUpdate, "Mongo-History");
            _messagePublisher.Publish(documentTypeUpdatedEvent);

            var dto = _mapper.Map<DocumentTypeDto>(dtotctToUpdate);
            response.DocumentType = dto;

            return Ok(response);
        }
    }
}