using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorDocumentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorDocumentRequest>.WithActionResult<
        UpdateAdvisorDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorDocument> _repository;

        public Update(
            IRepository<AdvisorDocument> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorDocuments")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorDocument",
            Description = "Updates a AdvisorDocument",
            OperationId = "advisorDocuments.update",
            Tags = new[] { "AdvisorDocumentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorDocumentResponse>> HandleAsync(
            UpdateAdvisorDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorDocumentResponse(request.CorrelationId());

            var adddvdToUpdate = _mapper.Map<AdvisorDocument>(request);

            var advisorDocumentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (advisorDocumentToUpdateTest is null)
            {
                return NotFound();
            }

            //adddvdToUpdate.UpdateAdvisorForAdvisorDocument(request.AdvisorId);
            //adddvdToUpdate.UpdateDocumentForAdvisorDocument(request.DocumentId);
            //adddvdToUpdate.UpdateDocumentTypeForAdvisorDocument(request.DocumentTypeId);
            await _repository.UpdateAsync(adddvdToUpdate);

            var advisorDocumentUpdatedEvent = new AdvisorDocumentUpdatedEvent(adddvdToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorDocumentUpdatedEvent);

            var dto = _mapper.Map<AdvisorDocumentDto>(adddvdToUpdate);
            response.AdvisorDocument = dto;

            return Ok(response);
        }
    }
}