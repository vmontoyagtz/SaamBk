using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Comission;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ComissionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateComissionRequest>.WithActionResult<
        CreateComissionResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RegionAreaAdvisorCategory> _regionAreaAdvisorCategoryRepository;
        private readonly IRepository<Comission> _repository;

        public Create(
            IRepository<Comission> repository,
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

        [HttpPost("api/comissions")]
        [SwaggerOperation(
            Summary = "Creates a new Comission",
            Description = "Creates a new Comission",
            OperationId = "comissions.create",
            Tags = new[] { "ComissionEndpoints" })
        ]
        public override async Task<ActionResult<CreateComissionResponse>> HandleAsync(
            CreateComissionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateComissionResponse(request.CorrelationId());

            //var regionAreaAdvisorCategory = await _regionAreaAdvisorCategoryRepository.GetByIdAsync(request.RegionAreaAdvisorCategoryId);// parent entity

            var newComission = new Comission(
                Guid.NewGuid(),
                request.RegionAreaAdvisorCategoryId,
                request.ComissionPercentage,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId,
                request.IsDefault
            );


            await _repository.AddAsync(newComission);

            _logger.LogInformation(
                $"Comission created  with Id {newComission.ComissionId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<ComissionDto>(newComission);

            var comissionCreatedEvent = new ComissionCreatedEvent(newComission, "Mongo-History");
            _messagePublisher.Publish(comissionCreatedEvent);

            response.Comission = dto;


            return Ok(response);
        }
    }
}