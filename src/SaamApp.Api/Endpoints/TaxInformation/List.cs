using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListTaxInformationRequest>.WithActionResult<
        ListTaxInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TaxInformation> _repository;

        public List(IRepository<TaxInformation> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/taxInformations")]
        [SwaggerOperation(
            Summary = "List TaxInformations",
            Description = "List TaxInformations",
            OperationId = "taxInformations.List",
            Tags = new[] { "TaxInformationEndpoints" })
        ]
        public override async Task<ActionResult<ListTaxInformationResponse>> HandleAsync(
            [FromQuery] ListTaxInformationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTaxInformationResponse(request.CorrelationId());

            var spec = new TaxInformationGetListSpec();
            var taxInformations = await _repository.ListAsync(spec);
            if (taxInformations is null)
            {
                return NotFound();
            }

            response.TaxInformations = _mapper.Map<List<TaxInformationDto>>(taxInformations);
            response.Count = response.TaxInformations.Count;

            return Ok(response);
        }
    }
}