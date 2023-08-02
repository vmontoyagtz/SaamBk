using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorRating;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorRatingEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsAdvisorRatingRequest>.WithActionResult<
        GetByIdAdvisorRatingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorRating> _repository;

        public GetByRelsIds(
            IRepository<AdvisorRating> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(
            "api/advisorRatings/{AdvisorRatingRate}/{AdvisorRatingDate}/{AdvisorId}/{ConversationId}/{CustomerId}/{RatingReasonId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorRating by rel Ids",
            Description = "Gets a AdvisorRating by rel Ids",
            OperationId = "advisorRatings.GetByRelsIds",
            Tags = new[] { "AdvisorRatingEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorRatingResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsAdvisorRatingRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorRatingResponse(request.CorrelationId());

            var spec = new AdvisorRatingByRelIdsSpec(request.AdvisorRatingRate, request.AdvisorRatingDate,
                request.AdvisorId, request.ConversationId, request.CustomerId, request.RatingReasonId);

            var advisorRating = await _repository.FirstOrDefaultAsync(spec);


            if (advisorRating is null)
            {
                return NotFound();
            }

            response.AdvisorRating = _mapper.Map<AdvisorRatingDto>(advisorRating);

            return Ok(response);
        }
    }
}