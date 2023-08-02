using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorIdentityDocumentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorIdentityDocumentRequest>.WithActionResult<
        UpdateAdvisorIdentityDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorIdentityDocument> _repository;

        public Update(
            IRepository<AdvisorIdentityDocument> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorIdentityDocuments")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorIdentityDocument",
            Description = "Updates a AdvisorIdentityDocument",
            OperationId = "advisorIdentityDocuments.update",
            Tags = new[] { "AdvisorIdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorIdentityDocumentResponse>> HandleAsync(
            UpdateAdvisorIdentityDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorIdentityDocumentResponse(request.CorrelationId());

            var aiddidvidToUpdate = _mapper.Map<AdvisorIdentityDocument>(request);

            var advisorIdentityDocumentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (advisorIdentityDocumentToUpdateTest is null)
            {
                return NotFound();
            }

            //aiddidvidToUpdate.UpdateAdvisorForAdvisorIdentityDocument(request.AdvisorId);
            //aiddidvidToUpdate.UpdateDocumentForAdvisorIdentityDocument(request.DocumentId);
            //aiddidvidToUpdate.UpdateDocumentTypeForAdvisorIdentityDocument(request.DocumentTypeId);
            //aiddidvidToUpdate.UpdateIdentityDocumentForAdvisorIdentityDocument(request.IdentityDocumentId);
            await _repository.UpdateAsync(aiddidvidToUpdate);

            var advisorIdentityDocumentUpdatedEvent =
                new AdvisorIdentityDocumentUpdatedEvent(aiddidvidToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorIdentityDocumentUpdatedEvent);

            var dto = _mapper.Map<AdvisorIdentityDocumentDto>(aiddidvidToUpdate);
            response.AdvisorIdentityDocument = dto;

            return Ok(response);
        }
    }
}