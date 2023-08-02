using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.IdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.IdentityDocumentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateIdentityDocumentRequest>.WithActionResult<
        UpdateIdentityDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<IdentityDocument> _repository;

        public Update(
            IRepository<IdentityDocument> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/identityDocuments")]
        [SwaggerOperation(
            Summary = "Updates a IdentityDocument",
            Description = "Updates a IdentityDocument",
            OperationId = "identityDocuments.update",
            Tags = new[] { "IdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateIdentityDocumentResponse>> HandleAsync(
            UpdateIdentityDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateIdentityDocumentResponse(request.CorrelationId());

            var idddedToUpdate = _mapper.Map<IdentityDocument>(request);

            var identityDocumentToUpdateTest = await _repository.GetByIdAsync(request.IdentityDocumentId);
            if (identityDocumentToUpdateTest is null)
            {
                return NotFound();
            }

            // idddedToUpdate.UpdateCountryForIdentityDocument(request.CountryId);
            await _repository.UpdateAsync(idddedToUpdate);

            var identityDocumentUpdatedEvent = new IdentityDocumentUpdatedEvent(idddedToUpdate, "Mongo-History");
            _messagePublisher.Publish(identityDocumentUpdatedEvent);

            var dto = _mapper.Map<IdentityDocumentDto>(idddedToUpdate);
            response.IdentityDocument = dto;

            return Ok(response);
        }
    }
}