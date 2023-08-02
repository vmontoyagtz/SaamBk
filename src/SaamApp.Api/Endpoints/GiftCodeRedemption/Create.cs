using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.GiftCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GiftCodeRedemptionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateGiftCodeRedemptionRequest>.WithActionResult<
        CreateGiftCodeRedemptionResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<GiftCodeRedemption> _repository;

        public Create(
            IRepository<GiftCodeRedemption> repository,
            IRepository<Customer> customerRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _customerRepository = customerRepository;
        }

        [HttpPost("api/giftCodeRedemptions")]
        [SwaggerOperation(
            Summary = "Creates a new GiftCodeRedemption",
            Description = "Creates a new GiftCodeRedemption",
            OperationId = "giftCodeRedemptions.create",
            Tags = new[] { "GiftCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<CreateGiftCodeRedemptionResponse>> HandleAsync(
            CreateGiftCodeRedemptionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateGiftCodeRedemptionResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newGiftCodeRedemption = new GiftCodeRedemption(
                Guid.NewGuid(),
                request.CustomerId,
                request.GiftCodeId,
                request.GiftCodeRedemptionDate
            );


            await _repository.AddAsync(newGiftCodeRedemption);

            _logger.LogInformation(
                $"GiftCodeRedemption created  with Id {newGiftCodeRedemption.GiftCodeRedemptionId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<GiftCodeRedemptionDto>(newGiftCodeRedemption);

            var giftCodeRedemptionCreatedEvent =
                new GiftCodeRedemptionCreatedEvent(newGiftCodeRedemption, "Mongo-History");
            _messagePublisher.Publish(giftCodeRedemptionCreatedEvent);

            response.GiftCodeRedemption = dto;


            return Ok(response);
        }
    }
}