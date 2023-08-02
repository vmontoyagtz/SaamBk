using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.RatingReason;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RatingReasonEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateRatingReasonRequest>.WithActionResult<
        CreateRatingReasonResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RatingReason> _repository;

        public Create(
            IRepository<RatingReason> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/ratingReasons")]
        [SwaggerOperation(
            Summary = "Creates a new RatingReason",
            Description = "Creates a new RatingReason",
            OperationId = "ratingReasons.create",
            Tags = new[] { "RatingReasonEndpoints" })
        ]
        public override async Task<ActionResult<CreateRatingReasonResponse>> HandleAsync(
            CreateRatingReasonRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateRatingReasonResponse(request.CorrelationId());


            var newRatingReason = new RatingReason(
                Guid.NewGuid(),
                request.RatingReasonDescription
            );


            await _repository.AddAsync(newRatingReason);

            _logger.LogInformation(
                $"RatingReason created  with Id {newRatingReason.RatingReasonId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<RatingReasonDto>(newRatingReason);

            var ratingReasonCreatedEvent = new RatingReasonCreatedEvent(newRatingReason, "Mongo-History");
            _messagePublisher.Publish(ratingReasonCreatedEvent);

            response.RatingReason = dto;


            return Ok(response);
        }
    }
}