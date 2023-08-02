using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TaxInformation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TaxInformationEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdTaxInformationRequest>.WithActionResult<
        GetByIdTaxInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TaxInformation> _repository;

        public GetByIdWithIncludes(
            IRepository<TaxInformation> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/taxInformations/i/{TaxInformationId}")]
        [SwaggerOperation(
            Summary = "Get a TaxInformation by Id With Includes",
            Description = "Gets a TaxInformation by Id With Includes",
            OperationId = "taxInformations.GetByIdWithIncludes",
            Tags = new[] { "TaxInformationEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTaxInformationResponse>> HandleAsync(
            [FromRoute] GetByIdTaxInformationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTaxInformationResponse(request.CorrelationId());

            var spec = new TaxInformationByIdWithIncludesSpec(request.TaxInformationId);

            var taxInformation = await _repository.FirstOrDefaultAsync(spec);


            if (taxInformation is null)
            {
                return NotFound();
            }

            response.TaxInformation = _mapper.Map<TaxInformationDto>(taxInformation);

            return Ok(response);
        }
    }
}