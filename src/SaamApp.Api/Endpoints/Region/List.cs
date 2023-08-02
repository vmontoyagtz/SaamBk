using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListRegionRequest>.WithActionResult<ListRegionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Region> _repository;

        public List(IRepository<Region> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/regions")]
        [SwaggerOperation(
            Summary = "List Regions",
            Description = "List Regions",
            OperationId = "regions.List",
            Tags = new[] { "RegionEndpoints" })
        ]
        public override async Task<ActionResult<ListRegionResponse>> HandleAsync([FromQuery] ListRegionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListRegionResponse(request.CorrelationId());

            var spec = new RegionGetListSpec();
            var regions = await _repository.ListAsync(spec);
            if (regions is null)
            {
                return NotFound();
            }

            response.Regions = _mapper.Map<List<RegionDto>>(regions);
            response.Count = response.Regions.Count;

            return Ok(response);
        }
    }
}