using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.IdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.IdentityDocumentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteIdentityDocumentRequest>.WithActionResult<
        DeleteIdentityDocumentResponse>
    {
        private readonly IRepository<AdvisorIdentityDocument> _advisorIdentityDocumentRepository;
        private readonly IRepository<IdentityDocument> _identityDocumentReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<IdentityDocument> _repository;

        public Delete(IRepository<IdentityDocument> IdentityDocumentRepository,
            IRepository<IdentityDocument> IdentityDocumentReadRepository,
            IRepository<AdvisorIdentityDocument> advisorIdentityDocumentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = IdentityDocumentRepository;
            _identityDocumentReadRepository = IdentityDocumentReadRepository;
            _advisorIdentityDocumentRepository = advisorIdentityDocumentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/identityDocuments/{IdentityDocumentId}")]
        [SwaggerOperation(
            Summary = "Deletes an IdentityDocument",
            Description = "Deletes an IdentityDocument",
            OperationId = "identityDocuments.delete",
            Tags = new[] { "IdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteIdentityDocumentResponse>> HandleAsync(
            [FromRoute] DeleteIdentityDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteIdentityDocumentResponse(request.CorrelationId());

            var identityDocument = await _identityDocumentReadRepository.GetByIdAsync(request.IdentityDocumentId);

            if (identityDocument == null)
            {
                return NotFound();
            }

            var advisorIdentityDocumentSpec =
                new GetAdvisorIdentityDocumentWithIdentityDocumentKeySpec(identityDocument.IdentityDocumentId);
            var advisorIdentityDocuments =
                await _advisorIdentityDocumentRepository.ListAsync(advisorIdentityDocumentSpec);
            await _advisorIdentityDocumentRepository.DeleteRangeAsync(advisorIdentityDocuments);

            var identityDocumentDeletedEvent = new IdentityDocumentDeletedEvent(identityDocument, "Mongo-History");
            _messagePublisher.Publish(identityDocumentDeletedEvent);

            await _repository.DeleteAsync(identityDocument);

            return Ok(response);
        }
    }
}