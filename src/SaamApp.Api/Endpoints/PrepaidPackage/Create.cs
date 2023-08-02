using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.PrepaidPackage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PrepaidPackageEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreatePrepaidPackageRequest>.WithActionResult<
        CreatePrepaidPackageResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Region> _regionRepository;
        private readonly IRepository<PrepaidPackage> _repository;

        public Create(
            IRepository<PrepaidPackage> repository,
            IRepository<Region> regionRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _regionRepository = regionRepository;
        }

        [HttpPost("api/prepaidPackages")]
        [SwaggerOperation(
            Summary = "Creates a new PrepaidPackage",
            Description = "Creates a new PrepaidPackage",
            OperationId = "prepaidPackages.create",
            Tags = new[] { "PrepaidPackageEndpoints" })
        ]
        public override async Task<ActionResult<CreatePrepaidPackageResponse>> HandleAsync(
            CreatePrepaidPackageRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreatePrepaidPackageResponse(request.CorrelationId());

            //var region = await _regionRepository.GetByIdAsync(request.RegionId);// parent entity

            var newPrepaidPackage = new PrepaidPackage(
                Guid.NewGuid(),
                request.RegionId,
                request.PrepaidPackageName,
                request.PrepaidPackagePrice,
                request.PrepaidPackageIsActive,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newPrepaidPackage);

            _logger.LogInformation(
                $"PrepaidPackage created  with Id {newPrepaidPackage.PrepaidPackageId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<PrepaidPackageDto>(newPrepaidPackage);

            var prepaidPackageCreatedEvent = new PrepaidPackageCreatedEvent(newPrepaidPackage, "Mongo-History");
            _messagePublisher.Publish(prepaidPackageCreatedEvent);

            response.PrepaidPackage = dto;


            return Ok(response);
        }
    }
}