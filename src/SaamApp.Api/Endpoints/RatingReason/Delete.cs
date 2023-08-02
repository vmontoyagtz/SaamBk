using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.RatingReason;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RatingReasonEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteRatingReasonRequest>.WithActionResult<
        DeleteRatingReasonResponse>
    {
        private readonly IRepository<AdvisorRating> _advisorRatingRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RatingReason> _ratingReasonReadRepository;
        private readonly IRepository<RatingReason> _repository;

        public Delete(IRepository<RatingReason> RatingReasonRepository,
            IRepository<RatingReason> RatingReasonReadRepository,
            IRepository<AdvisorRating> advisorRatingRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = RatingReasonRepository;
            _ratingReasonReadRepository = RatingReasonReadRepository;
            _advisorRatingRepository = advisorRatingRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/ratingReasons/{RatingReasonId}")]
        [SwaggerOperation(
            Summary = "Deletes an RatingReason",
            Description = "Deletes an RatingReason",
            OperationId = "ratingReasons.delete",
            Tags = new[] { "RatingReasonEndpoints" })
        ]
        public override async Task<ActionResult<DeleteRatingReasonResponse>> HandleAsync(
            [FromRoute] DeleteRatingReasonRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteRatingReasonResponse(request.CorrelationId());

            var ratingReason = await _ratingReasonReadRepository.GetByIdAsync(request.RatingReasonId);

            if (ratingReason == null)
            {
                return NotFound();
            }

            var advisorRatingSpec = new GetAdvisorRatingWithRatingReasonKeySpec(ratingReason.RatingReasonId);
            var advisorRatings = await _advisorRatingRepository.ListAsync(advisorRatingSpec);
            await _advisorRatingRepository.DeleteRangeAsync(advisorRatings);

            var ratingReasonDeletedEvent = new RatingReasonDeletedEvent(ratingReason, "Mongo-History");
            _messagePublisher.Publish(ratingReasonDeletedEvent);

            await _repository.DeleteAsync(ratingReason);

            return Ok(response);
        }
    }
}