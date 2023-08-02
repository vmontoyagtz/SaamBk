using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Country;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CountryEndpoints
{
    public class GetListByRegionId : EndpointBaseAsync.WithRequest<ListCountryByRegionRequest>.WithActionResult<
        ListCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Country> _repository;

        public GetListByRegionId(IRepository<Country> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/getcountriesbyregionid/{RegionId}")]
        [SwaggerOperation(
            Summary = "List Countries by RegionId",
            Description = "List Countries by RegionId",
            OperationId = "countries.LisByRegionId",
            Tags = new[] { "CountryEndpoints" })
        ]
        public override async Task<ActionResult<ListCountryResponse>> HandleAsync(
            [FromRoute] ListCountryByRegionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCountryResponse(request.CorrelationId());

            var spec = new CountryGetListByRegionIdSpec(request.RegionId);
            var countries = await _repository.ListAsync(spec);
            if (countries is null)
            {
                return NotFound();
            }

            response.Countries = _mapper.Map<List<CountryDto>>(countries);
            response.Count = response.Countries.Count;
            return Ok(response);
        }
    }
}