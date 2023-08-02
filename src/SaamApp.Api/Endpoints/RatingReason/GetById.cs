using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.RatingReason;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RatingReasonEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdRatingReasonRequest>.WithActionResult<
        GetByIdRatingReasonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<RatingReason> _repository;

        public GetById(
            IRepository<RatingReason> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/ratingReasons/{RatingReasonId}")]
        [SwaggerOperation(
            Summary = "Get a RatingReason by Id",
            Description = "Gets a RatingReason by Id",
            OperationId = "ratingReasons.GetById",
            Tags = new[] { "RatingReasonEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdRatingReasonResponse>> HandleAsync(
            [FromRoute] GetByIdRatingReasonRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdRatingReasonResponse(request.CorrelationId());

            var ratingReason = await _repository.GetByIdAsync(request.RatingReasonId);
            if (ratingReason is null)
            {
                return NotFound();
            }

            response.RatingReason = _mapper.Map<RatingReasonDto>(ratingReason);

            return Ok(response);
        }
    }
}