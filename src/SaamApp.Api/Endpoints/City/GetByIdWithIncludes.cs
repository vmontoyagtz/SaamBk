using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.City;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CityEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdCityRequest>.WithActionResult<
        GetByIdCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<City> _repository;

        public GetByIdWithIncludes(
            IRepository<City> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/cities/i/{CityId}")]
        [SwaggerOperation(
            Summary = "Get a City by Id With Includes",
            Description = "Gets a City by Id With Includes",
            OperationId = "cities.GetByIdWithIncludes",
            Tags = new[] { "CityEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCityResponse>> HandleAsync(
            [FromRoute] GetByIdCityRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCityResponse(request.CorrelationId());

            var spec = new CityByIdWithIncludesSpec(request.CityId);

            var city = await _repository.FirstOrDefaultAsync(spec);


            if (city is null)
            {
                return NotFound();
            }

            response.City = _mapper.Map<CityDto>(city);

            return Ok(response);
        }
    }
}