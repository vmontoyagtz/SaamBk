using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Advisor;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorRequest>.WithActionResult<
        CreateAdvisorResponse>
    {
        private readonly IRepository<BusinessUnit> _businessUnitRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Advisor> _repository;

        public Create(
            IRepository<Advisor> repository,
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



        [HttpPost("api/advisors")]
        [SwaggerOperation(
            Summary = "Creates a new Advisor",
            Description = "Creates a new Advisor",
            OperationId = "advisors.create",
            Tags = new[] { "AdvisorEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorResponse>> HandleAsync(
            CreateAdvisorRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorResponse(request.CorrelationId());

            //var businessUnit = await _businessUnitRepository.GetByIdAsync(request.BusinessUnitId);// parent entity

            var newAdvisor = new Advisor(
                Guid.NewGuid(),
                request.BusinessUnitId,
                request.GenderId,
                request.PaymentFrequencyId,
                request.TaxInformationId,
                request.AdvisorFirstName,
                request.AdvisorLastName,
                request.AdvisorNote,
                request.AdvisorTitle,
                request.AdvisorJsonResume,
                request.IsNaturalPerson,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newAdvisor);

            _logger.LogInformation(
                $"Advisor created  with Id {newAdvisor.AdvisorId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorDto>(newAdvisor);

            var advisorCreatedEvent = new AdvisorCreatedEvent(newAdvisor, "Mongo-History");
            _messagePublisher.Publish(advisorCreatedEvent);

            response.Advisor = dto;


            return Ok(response);
        }
    }
}