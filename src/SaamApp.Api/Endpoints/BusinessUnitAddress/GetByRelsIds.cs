using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitAddressEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsBusinessUnitAddressRequest>.WithActionResult<
        GetByIdBusinessUnitAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitAddress> _repository;

        public GetByRelsIds(
            IRepository<BusinessUnitAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitAddresses/{AddressId}/{BusinessUnitId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitAddress by rel Ids",
            Description = "Gets a BusinessUnitAddress by rel Ids",
            OperationId = "businessUnitAddresses.GetByRelsIds",
            Tags = new[] { "BusinessUnitAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitAddressResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsBusinessUnitAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitAddressResponse(request.CorrelationId());

            var spec = new BusinessUnitAddressByRelIdsSpec(request.AddressId, request.BusinessUnitId);

            var businessUnitAddress = await _repository.FirstOrDefaultAsync(spec);


            if (businessUnitAddress is null)
            {
                return NotFound();
            }

            response.BusinessUnitAddress = _mapper.Map<BusinessUnitAddressDto>(businessUnitAddress);

            return Ok(response);
        }
    }
}