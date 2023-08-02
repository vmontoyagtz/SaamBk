using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitAddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdBusinessUnitAddressRequest>.WithActionResult<
        GetByIdBusinessUnitAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitAddress> _repository;

        public GetById(
            IRepository<BusinessUnitAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitAddress by Id",
            Description = "Gets a BusinessUnitAddress by Id",
            OperationId = "businessUnitAddresses.GetById",
            Tags = new[] { "BusinessUnitAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitAddressResponse>> HandleAsync(
            [FromRoute] GetByIdBusinessUnitAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitAddressResponse(request.CorrelationId());

            var businessUnitAddress = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitAddress is null)
            {
                return NotFound();
            }

            response.BusinessUnitAddress = _mapper.Map<BusinessUnitAddressDto>(businessUnitAddress);

            return Ok(response);
        }
    }
}