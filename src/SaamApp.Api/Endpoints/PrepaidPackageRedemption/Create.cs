using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PrepaidPackageRedemptionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreatePrepaidPackageRedemptionRequest>.WithActionResult<
        CreatePrepaidPackageRedemptionResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PrepaidPackageRedemption> _repository;

        public Create(
            IRepository<PrepaidPackageRedemption> repository,
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

        [HttpPost("api/prepaidPackageRedemptions")]
        [SwaggerOperation(
            Summary = "Creates a new PrepaidPackageRedemption",
            Description = "Creates a new PrepaidPackageRedemption",
            OperationId = "prepaidPackageRedemptions.create",
            Tags = new[] { "PrepaidPackageRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<CreatePrepaidPackageRedemptionResponse>> HandleAsync(
            CreatePrepaidPackageRedemptionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreatePrepaidPackageRedemptionResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newPrepaidPackageRedemption = new PrepaidPackageRedemption(
                Guid.NewGuid(),
                request.CustomerId,
                request.PrepaidPackageId,
                request.PrepaidPackageAmount,
                request.PrepaidPackageRedemptionDate
            );


            await _repository.AddAsync(newPrepaidPackageRedemption);

            _logger.LogInformation(
                $"PrepaidPackageRedemption created  with Id {newPrepaidPackageRedemption.PrepaidPackageRedemptionId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<PrepaidPackageRedemptionDto>(newPrepaidPackageRedemption);

            var prepaidPackageRedemptionCreatedEvent =
                new PrepaidPackageRedemptionCreatedEvent(newPrepaidPackageRedemption, "Mongo-History");
            _messagePublisher.Publish(prepaidPackageRedemptionCreatedEvent);

            response.PrepaidPackageRedemption = dto;


            return Ok(response);
        }
    }
}