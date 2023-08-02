using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerAddressRequest>.WithActionResult<
        GetByIdCustomerAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerAddress> _repository;

        public GetById(
            IRepository<CustomerAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerAddress by Id",
            Description = "Gets a CustomerAddress by Id",
            OperationId = "customerAddresses.GetById",
            Tags = new[] { "CustomerAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerAddressResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerAddressResponse(request.CorrelationId());

            var customerAddress = await _repository.GetByIdAsync(request.RowId);
            if (customerAddress is null)
            {
                return NotFound();
            }

            response.CustomerAddress = _mapper.Map<CustomerAddressDto>(customerAddress);

            return Ok(response);
        }
    }
}