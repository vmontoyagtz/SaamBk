using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorDocumentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorDocumentRequest>.WithActionResult<
        DeleteAdvisorDocumentResponse>
    {
        private readonly IRepository<AdvisorDocument> _advisorDocumentReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorDocument> _repository;

        public Delete(IRepository<AdvisorDocument> AdvisorDocumentRepository,
            IRepository<AdvisorDocument> AdvisorDocumentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorDocumentRepository;
            _advisorDocumentReadRepository = AdvisorDocumentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorDocument",
            Description = "Deletes an AdvisorDocument",
            OperationId = "advisorDocuments.delete",
            Tags = new[] { "AdvisorDocumentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorDocumentResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorDocumentResponse(request.CorrelationId());

            var advisorDocument = await _advisorDocumentReadRepository.GetByIdAsync(request.RowId);

            if (advisorDocument == null)
            {
                return NotFound();
            }


            var advisorDocumentDeletedEvent = new AdvisorDocumentDeletedEvent(advisorDocument, "Mongo-History");
            _messagePublisher.Publish(advisorDocumentDeletedEvent);

            await _repository.DeleteAsync(advisorDocument);

            return Ok(response);
        }
    }
}