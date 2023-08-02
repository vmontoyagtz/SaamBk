using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TaxInformation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TaxInformationEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTaxInformationRequest>.WithActionResult<
        CreateTaxInformationResponse>
    {
        private readonly IRepository<BusinessUnit> _businessUnitRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TaxInformation> _repository;

        public Create(
            IRepository<TaxInformation> repository,
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

        [HttpPost("api/taxInformations")]
        [SwaggerOperation(
            Summary = "Creates a new TaxInformation",
            Description = "Creates a new TaxInformation",
            OperationId = "taxInformations.create",
            Tags = new[] { "TaxInformationEndpoints" })
        ]
        public override async Task<ActionResult<CreateTaxInformationResponse>> HandleAsync(
            CreateTaxInformationRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTaxInformationResponse(request.CorrelationId());

            //var businessUnit = await _businessUnitRepository.GetByIdAsync(request.BusinessUnitId);// parent entity

            var newTaxInformation = new TaxInformation(
                Guid.NewGuid(),
                request.BusinessUnitId,
                request.TaxpayerTypeId,
                request.BusinessTypeId,
                request.TaxInformationBusinessName,
                request.TaxInformationCommercialName,
                request.TaxInformationRegistrationId,
                request.TaxInformationBusinessIndustry,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newTaxInformation);

            _logger.LogInformation(
                $"TaxInformation created  with Id {newTaxInformation.TaxInformationId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TaxInformationDto>(newTaxInformation);

            var taxInformationCreatedEvent = new TaxInformationCreatedEvent(newTaxInformation, "Mongo-History");
            _messagePublisher.Publish(taxInformationCreatedEvent);

            response.TaxInformation = dto;


            return Ok(response);
        }
    }
}