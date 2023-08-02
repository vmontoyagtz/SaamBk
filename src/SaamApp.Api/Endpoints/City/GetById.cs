using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.City;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CityEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCityRequest>.WithActionResult<
        GetByIdCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<City> _repository;

        public GetById(
            IRepository<City> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/cities/{CityId}")]
        [SwaggerOperation(
            Summary = "Get a City by Id",
            Description = "Gets a City by Id",
            OperationId = "cities.GetById",
            Tags = new[] { "CityEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCityResponse>> HandleAsync(
            [FromRoute] GetByIdCityRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCityResponse(request.CorrelationId());

            var city = await _repository.GetByIdAsync(request.CityId);
            if (city is null)
            {
                return NotFound();
            }

            response.City = _mapper.Map<CityDto>(city);

            return Ok(response);
        }
    }
}