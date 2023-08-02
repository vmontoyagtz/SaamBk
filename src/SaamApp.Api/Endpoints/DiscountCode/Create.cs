using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.DiscountCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DiscountCodeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateDiscountCodeRequest>.WithActionResult<
        CreateDiscountCodeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Region> _regionRepository;
        private readonly IRepository<DiscountCode> _repository;

        public Create(
            IRepository<DiscountCode> repository,
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

        [HttpPost("api/discountCodes")]
        [SwaggerOperation(
            Summary = "Creates a new DiscountCode",
            Description = "Creates a new DiscountCode",
            OperationId = "discountCodes.create",
            Tags = new[] { "DiscountCodeEndpoints" })
        ]
        public override async Task<ActionResult<CreateDiscountCodeResponse>> HandleAsync(
            CreateDiscountCodeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateDiscountCodeResponse(request.CorrelationId());

            //var region = await _regionRepository.GetByIdAsync(request.RegionId);// parent entity

            var newDiscountCode = new DiscountCode(
                Guid.NewGuid(),
                request.RegionId,
                request.DiscountCodeName,
                request.DiscountCodeValue,
                request.DiscountCodePercentage,
                request.DiscountCodeStartDate,
                request.DiscountCodeEndDate,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newDiscountCode);

            _logger.LogInformation(
                $"DiscountCode created  with Id {newDiscountCode.DiscountCodeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<DiscountCodeDto>(newDiscountCode);

            var discountCodeCreatedEvent = new DiscountCodeCreatedEvent(newDiscountCode, "Mongo-History");
            _messagePublisher.Publish(discountCodeCreatedEvent);

            response.DiscountCode = dto;


            return Ok(response);
        }
    }
}