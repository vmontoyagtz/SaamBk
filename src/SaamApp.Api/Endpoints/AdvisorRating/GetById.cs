using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorRating;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorRatingEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorRatingRequest>.WithActionResult<
        GetByIdAdvisorRatingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorRating> _repository;

        public GetById(
            IRepository<AdvisorRating> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorRatings/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorRating by Id",
            Description = "Gets a AdvisorRating by Id",
            OperationId = "advisorRatings.GetById",
            Tags = new[] { "AdvisorRatingEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorRatingResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorRatingRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorRatingResponse(request.CorrelationId());

            var advisorRating = await _repository.GetByIdAsync(request.RowId);
            if (advisorRating is null)
            {
                return NotFound();
            }

            response.AdvisorRating = _mapper.Map<AdvisorRatingDto>(advisorRating);

            return Ok(response);
        }
    }
}