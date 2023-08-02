using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TaxpayerType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TaxpayerTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListTaxpayerTypeRequest>.WithActionResult<
        ListTaxpayerTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TaxpayerType> _repository;

        public List(IRepository<TaxpayerType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/taxpayerTypes")]
        [SwaggerOperation(
            Summary = "List TaxpayerTypes",
            Description = "List TaxpayerTypes",
            OperationId = "taxpayerTypes.List",
            Tags = new[] { "TaxpayerTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListTaxpayerTypeResponse>> HandleAsync(
            [FromQuery] ListTaxpayerTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTaxpayerTypeResponse(request.CorrelationId());

            var spec = new TaxpayerTypeGetListSpec();
            var taxpayerTypes = await _repository.ListAsync(spec);
            if (taxpayerTypes is null)
            {
                return NotFound();
            }

            response.TaxpayerTypes = _mapper.Map<List<TaxpayerTypeDto>>(taxpayerTypes);
            response.Count = response.TaxpayerTypes.Count;

            return Ok(response);
        }
    }
}