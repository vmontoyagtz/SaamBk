using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAddressEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsCustomerAddressRequest>.WithActionResult<
        GetByIdCustomerAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerAddress> _repository;

        public GetByRelsIds(
            IRepository<CustomerAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerAddresses/{AddressId}/{CustomerId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerAddress by rel Ids",
            Description = "Gets a CustomerAddress by rel Ids",
            OperationId = "customerAddresses.GetByRelsIds",
            Tags = new[] { "CustomerAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerAddressResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsCustomerAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerAddressResponse(request.CorrelationId());

            var spec = new CustomerAddressByRelIdsSpec(request.AddressId, request.CustomerId);

            var customerAddress = await _repository.FirstOrDefaultAsync(spec);


            if (customerAddress is null)
            {
                return NotFound();
            }

            response.CustomerAddress = _mapper.Map<CustomerAddressDto>(customerAddress);

            return Ok(response);
        }
    }
}