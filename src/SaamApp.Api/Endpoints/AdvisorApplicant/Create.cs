using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorApplicant;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorApplicantEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorApplicantRequest>.WithActionResult<
        CreateAdvisorApplicantResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RegionAreaAdvisorCategory> _regionAreaAdvisorCategoryRepository;
        private readonly IRepository<AdvisorApplicant> _repository;

        public Create(
            IRepository<AdvisorApplicant> repository,
            IRepository<RegionAreaAdvisorCategory> regionAreaAdvisorCategoryRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _regionAreaAdvisorCategoryRepository = regionAreaAdvisorCategoryRepository;
        }

        [HttpPost("api/advisorApplicants")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorApplicant",
            Description = "Creates a new AdvisorApplicant",
            OperationId = "advisorApplicants.create",
            Tags = new[] { "AdvisorApplicantEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorApplicantResponse>> HandleAsync(
            CreateAdvisorApplicantRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorApplicantResponse(request.CorrelationId());

            //var regionAreaAdvisorCategory = await _regionAreaAdvisorCategoryRepository.GetByIdAsync(request.RegionAreaAdvisorCategoryId);// parent entity

            var newAdvisorApplicant = new AdvisorApplicant(
                Guid.NewGuid(),
                request.RegionAreaAdvisorCategoryId,
                request.YearsOfExperience,
                request.Approved,
                request.ApplicantNotes,
                request.Stage,
                request.TenantId
            );


            await _repository.AddAsync(newAdvisorApplicant);

            _logger.LogInformation(
                $"AdvisorApplicant created  with Id {newAdvisorApplicant.AdvisorApplicantId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorApplicantDto>(newAdvisorApplicant);

            var advisorApplicantCreatedEvent = new AdvisorApplicantCreatedEvent(newAdvisorApplicant, "Mongo-History");
            _messagePublisher.Publish(advisorApplicantCreatedEvent);

            response.AdvisorApplicant = dto;


            return Ok(response);
        }
    }
}