using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TaxpayerType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TaxpayerTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTaxpayerTypeRequest>.WithActionResult<
        GetByIdTaxpayerTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TaxpayerType> _repository;

        public GetById(
            IRepository<TaxpayerType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/taxpayerTypes/{TaxpayerTypeId}")]
        [SwaggerOperation(
            Summary = "Get a TaxpayerType by Id",
            Description = "Gets a TaxpayerType by Id",
            OperationId = "taxpayerTypes.GetById",
            Tags = new[] { "TaxpayerTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTaxpayerTypeResponse>> HandleAsync(
            [FromRoute] GetByIdTaxpayerTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTaxpayerTypeResponse(request.CorrelationId());

            var taxpayerType = await _repository.GetByIdAsync(request.TaxpayerTypeId);
            if (taxpayerType is null)
            {
                return NotFound();
            }

            response.TaxpayerType = _mapper.Map<TaxpayerTypeDto>(taxpayerType);

            return Ok(response);
        }
    }
}