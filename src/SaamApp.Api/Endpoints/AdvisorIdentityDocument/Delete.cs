using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorIdentityDocumentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorIdentityDocumentRequest>.WithActionResult<
        DeleteAdvisorIdentityDocumentResponse>
    {
        private readonly IRepository<AdvisorIdentityDocument> _advisorIdentityDocumentReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorIdentityDocument> _repository;

        public Delete(IRepository<AdvisorIdentityDocument> AdvisorIdentityDocumentRepository,
            IRepository<AdvisorIdentityDocument> AdvisorIdentityDocumentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorIdentityDocumentRepository;
            _advisorIdentityDocumentReadRepository = AdvisorIdentityDocumentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorIdentityDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorIdentityDocument",
            Description = "Deletes an AdvisorIdentityDocument",
            OperationId = "advisorIdentityDocuments.delete",
            Tags = new[] { "AdvisorIdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorIdentityDocumentResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorIdentityDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorIdentityDocumentResponse(request.CorrelationId());

            var advisorIdentityDocument = await _advisorIdentityDocumentReadRepository.GetByIdAsync(request.RowId);

            if (advisorIdentityDocument == null)
            {
                return NotFound();
            }


            var advisorIdentityDocumentDeletedEvent =
                new AdvisorIdentityDocumentDeletedEvent(advisorIdentityDocument, "Mongo-History");
            _messagePublisher.Publish(advisorIdentityDocumentDeletedEvent);

            await _repository.DeleteAsync(advisorIdentityDocument);

            return Ok(response);
        }
    }
}