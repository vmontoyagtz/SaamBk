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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdCountryRequest>.WithActionResult<
        GetByIdCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Country> _repository;

        public GetByIdWithIncludes(
            IRepository<Country> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/countries/i/{CountryId}")]
        [SwaggerOperation(
            Summary = "Get a Country by Id With Includes",
            Description = "Gets a Country by Id With Includes",
            OperationId = "countries.GetByIdWithIncludes",
            Tags = new[] { "CountryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCountryResponse>> HandleAsync(
            [FromRoute] GetByIdCountryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCountryResponse(request.CorrelationId());

            var spec = new CountryByIdWithIncludesSpec(request.CountryId);

            var country = await _repository.FirstOrDefaultAsync(spec);


            if (country is null)
            {
                return NotFound();
            }

            response.Country = _mapper.Map<CountryDto>(country);

            return Ok(response);
        }
    }
}