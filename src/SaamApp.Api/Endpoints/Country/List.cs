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
    public class List : EndpointBaseAsync.WithRequest<ListCountryRequest>.WithActionResult<ListCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Country> _repository;

        public List(IRepository<Country> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/countries")]
        [SwaggerOperation(
            Summary = "List Countries",
            Description = "List Countries",
            OperationId = "countries.List",
            Tags = new[] { "CountryEndpoints" })
        ]
        public override async Task<ActionResult<ListCountryResponse>> HandleAsync(
            [FromQuery] ListCountryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCountryResponse(request.CorrelationId());

            var spec = new CountryGetListSpec();
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