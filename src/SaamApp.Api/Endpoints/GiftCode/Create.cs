using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.GiftCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GiftCodeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateGiftCodeRequest>.WithActionResult<
        CreateGiftCodeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Region> _regionRepository;
        private readonly IRepository<GiftCode> _repository;

        public Create(
            IRepository<GiftCode> repository,
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

        [HttpPost("api/giftCodes")]
        [SwaggerOperation(
            Summary = "Creates a new GiftCode",
            Description = "Creates a new GiftCode",
            OperationId = "giftCodes.create",
            Tags = new[] { "GiftCodeEndpoints" })
        ]
        public override async Task<ActionResult<CreateGiftCodeResponse>> HandleAsync(
            CreateGiftCodeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateGiftCodeResponse(request.CorrelationId());

            //var region = await _regionRepository.GetByIdAsync(request.RegionId);// parent entity

            var newGiftCode = new GiftCode(
                Guid.NewGuid(),
                request.RegionId,
                request.GiftCodeName,
                request.GiftCodeValue,
                request.GiftCodeAmount,
                request.GiftCodeStartDate,
                request.GiftCodeEndDate,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newGiftCode);

            _logger.LogInformation(
                $"GiftCode created  with Id {newGiftCode.GiftCodeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<GiftCodeDto>(newGiftCode);

            var giftCodeCreatedEvent = new GiftCodeCreatedEvent(newGiftCode, "Mongo-History");
            _messagePublisher.Publish(giftCodeCreatedEvent);

            response.GiftCode = dto;


            return Ok(response);
        }
    }
}