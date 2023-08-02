using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorRating;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorRatingEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorRatingRequest>.WithActionResult<
        DeleteAdvisorRatingResponse>
    {
        private readonly IRepository<AdvisorRating> _advisorRatingReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorRating> _repository;

        public Delete(IRepository<AdvisorRating> AdvisorRatingRepository,
            IRepository<AdvisorRating> AdvisorRatingReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorRatingRepository;
            _advisorRatingReadRepository = AdvisorRatingReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorRatings/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorRating",
            Description = "Deletes an AdvisorRating",
            OperationId = "advisorRatings.delete",
            Tags = new[] { "AdvisorRatingEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorRatingResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorRatingRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorRatingResponse(request.CorrelationId());

            var advisorRating = await _advisorRatingReadRepository.GetByIdAsync(request.RowId);

            if (advisorRating == null)
            {
                return NotFound();
            }


            var advisorRatingDeletedEvent = new AdvisorRatingDeletedEvent(advisorRating, "Mongo-History");
            _messagePublisher.Publish(advisorRatingDeletedEvent);

            await _repository.DeleteAsync(advisorRating);

            return Ok(response);
        }
    }
}