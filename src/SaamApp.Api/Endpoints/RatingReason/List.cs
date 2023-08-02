using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListRatingReasonRequest>.WithActionResult<
        ListRatingReasonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<RatingReason> _repository;

        public List(IRepository<RatingReason> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/ratingReasons")]
        [SwaggerOperation(
            Summary = "List RatingReasons",
            Description = "List RatingReasons",
            OperationId = "ratingReasons.List",
            Tags = new[] { "RatingReasonEndpoints" })
        ]
        public override async Task<ActionResult<ListRatingReasonResponse>> HandleAsync(
            [FromQuery] ListRatingReasonRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListRatingReasonResponse(request.CorrelationId());

            var spec = new RatingReasonGetListSpec();
            var ratingReasons = await _repository.ListAsync(spec);
            if (ratingReasons is null)
            {
                return NotFound();
            }

            response.RatingReasons = _mapper.Map<List<RatingReasonDto>>(ratingReasons);
            response.Count = response.RatingReasons.Count;

            return Ok(response);
        }
    }
}