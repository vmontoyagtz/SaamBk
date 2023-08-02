using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListCityRequest>.WithActionResult<ListCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<City> _repository;

        public List(IRepository<City> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/cities")]
        [SwaggerOperation(
            Summary = "List Cities",
            Description = "List Cities",
            OperationId = "cities.List",
            Tags = new[] { "CityEndpoints" })
        ]
        public override async Task<ActionResult<ListCityResponse>> HandleAsync([FromQuery] ListCityRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCityResponse(request.CorrelationId());

            var spec = new CityGetListSpec();
            var cities = await _repository.ListAsync(spec);
            if (cities is null)
            {
                return NotFound();
            }

            response.Cities = _mapper.Map<List<CityDto>>(cities);
            response.Count = response.Cities.Count;

            return Ok(response);
        }
    }
}