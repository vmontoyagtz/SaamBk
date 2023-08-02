using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.RatingReason;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RatingReasonEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdRatingReasonRequest>.WithActionResult<
        GetByIdRatingReasonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<RatingReason> _repository;

        public GetByIdWithIncludes(
            IRepository<RatingReason> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/ratingReasons/i/{RatingReasonId}")]
        [SwaggerOperation(
            Summary = "Get a RatingReason by Id With Includes",
            Description = "Gets a RatingReason by Id With Includes",
            OperationId = "ratingReasons.GetByIdWithIncludes",
            Tags = new[] { "RatingReasonEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdRatingReasonResponse>> HandleAsync(
            [FromRoute] GetByIdRatingReasonRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdRatingReasonResponse(request.CorrelationId());

            var spec = new RatingReasonByIdWithIncludesSpec(request.RatingReasonId);

            var ratingReason = await _repository.FirstOrDefaultAsync(spec);


            if (ratingReason is null)
            {
                return NotFound();
            }

            response.RatingReason = _mapper.Map<RatingReasonDto>(ratingReason);

            return Ok(response);
        }
    }
}