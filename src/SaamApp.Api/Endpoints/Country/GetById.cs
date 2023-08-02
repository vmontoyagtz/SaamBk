using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Country;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CountryEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCountryRequest>.WithActionResult<
        GetByIdCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Country> _repository;

        public GetById(
            IRepository<Country> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/countries/{CountryId}")]
        [SwaggerOperation(
            Summary = "Get a Country by Id",
            Description = "Gets a Country by Id",
            OperationId = "countries.GetById",
            Tags = new[] { "CountryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCountryResponse>> HandleAsync(
            [FromRoute] GetByIdCountryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCountryResponse(request.CorrelationId());

            var country = await _repository.GetByIdAsync(request.CountryId);
            if (country is null)
            {
                return NotFound();
            }

            response.Country = _mapper.Map<CountryDto>(country);

            return Ok(response);
        }
    }
}