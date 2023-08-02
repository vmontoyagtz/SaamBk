using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.BusinessUnitDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitDocumentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateBusinessUnitDocumentRequest>.WithActionResult<
        CreateBusinessUnitDocumentResponse>
    {
        private readonly IRepository<BusinessUnit> _businessUnitRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitDocument> _repository;

        public Create(
            IRepository<BusinessUnitDocument> repository,
            IRepository<BusinessUnit> businessUnitRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _businessUnitRepository = businessUnitRepository;
        }

        [HttpPost("api/businessUnitDocuments")]
        [SwaggerOperation(
            Summary = "Creates a new BusinessUnitDocument",
            Description = "Creates a new BusinessUnitDocument",
            OperationId = "businessUnitDocuments.create",
            Tags = new[] { "BusinessUnitDocumentEndpoints" })
        ]
        public override async Task<ActionResult<CreateBusinessUnitDocumentResponse>> HandleAsync(
            CreateBusinessUnitDocumentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateBusinessUnitDocumentResponse(request.CorrelationId());

            //var businessUnit = await _businessUnitRepository.GetByIdAsync(request.BusinessUnitId);// parent entity

            var newBusinessUnitDocument = new BusinessUnitDocument(
                request.BusinessUnitId,
                request.DocumentId,
                request.DocumentTypeId
            );


            await _repository.AddAsync(newBusinessUnitDocument);

            _logger.LogInformation(
                $"BusinessUnitDocument created  with Id {newBusinessUnitDocument.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<BusinessUnitDocumentDto>(newBusinessUnitDocument);

            var businessUnitDocumentCreatedEvent =
                new BusinessUnitDocumentCreatedEvent(newBusinessUnitDocument, "Mongo-History");
            _messagePublisher.Publish(businessUnitDocumentCreatedEvent);

            response.BusinessUnitDocument = dto;


            return Ok(response);
        }
    }
}