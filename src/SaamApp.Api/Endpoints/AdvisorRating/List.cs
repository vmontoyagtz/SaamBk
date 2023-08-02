using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorRatingRequest>.WithActionResult<
        ListAdvisorRatingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorRating> _repository;

        public List(IRepository<AdvisorRating> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorRatings")]
        [SwaggerOperation(
            Summary = "List AdvisorRatings",
            Description = "List AdvisorRatings",
            OperationId = "advisorRatings.List",
            Tags = new[] { "AdvisorRatingEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorRatingResponse>> HandleAsync(
            [FromQuery] ListAdvisorRatingRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorRatingResponse(request.CorrelationId());

            var spec = new AdvisorRatingGetListSpec();
            var advisorRatings = await _repository.ListAsync(spec);
            if (advisorRatings is null)
            {
                return NotFound();
            }

            response.AdvisorRatings = _mapper.Map<List<AdvisorRatingDto>>(advisorRatings);
            response.Count = response.AdvisorRatings.Count;

            return Ok(response);
        }
    }
}