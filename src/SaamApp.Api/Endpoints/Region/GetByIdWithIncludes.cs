using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Region;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RegionEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdRegionRequest>.WithActionResult<
        GetByIdRegionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Region> _repository;

        public GetByIdWithIncludes(
            IRepository<Region> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/regions/i/{RegionId}")]
        [SwaggerOperation(
            Summary = "Get a Region by Id With Includes",
            Description = "Gets a Region by Id With Includes",
            OperationId = "regions.GetByIdWithIncludes",
            Tags = new[] { "RegionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdRegionResponse>> HandleAsync(
            [FromRoute] GetByIdRegionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdRegionResponse(request.CorrelationId());

            var spec = new RegionByIdWithIncludesSpec(request.RegionId);

            var region = await _repository.FirstOrDefaultAsync(spec);


            if (region is null)
            {
                return NotFound();
            }

            response.Region = _mapper.Map<RegionDto>(region);

            return Ok(response);
        }
    }
}