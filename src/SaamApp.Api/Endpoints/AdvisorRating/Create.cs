using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorRating;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorRatingEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorRatingRequest>.WithActionResult<
        CreateAdvisorRatingResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorRating> _repository;

        public Create(
            IRepository<AdvisorRating> repository,
            IRepository<Advisor> advisorRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _advisorRepository = advisorRepository;
        }

        [HttpPost("api/advisorRatings")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorRating",
            Description = "Creates a new AdvisorRating",
            OperationId = "advisorRatings.create",
            Tags = new[] { "AdvisorRatingEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorRatingResponse>> HandleAsync(
            CreateAdvisorRatingRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorRatingResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorRating = new AdvisorRating(
                request.AdvisorId,
                request.ConversationId,
                request.CustomerId,
                request.RatingReasonId,
                request.AdvisorRatingFeedback,
                request.AdvisorRatingRate,
                request.AdvisorRatingDate
            );


            await _repository.AddAsync(newAdvisorRating);

            _logger.LogInformation(
                $"AdvisorRating created  with Id {newAdvisorRating.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorRatingDto>(newAdvisorRating);

            var advisorRatingCreatedEvent = new AdvisorRatingCreatedEvent(newAdvisorRating, "Mongo-History");
            _messagePublisher.Publish(advisorRatingCreatedEvent);

            response.AdvisorRating = dto;


            return Ok(response);
        }
    }
}