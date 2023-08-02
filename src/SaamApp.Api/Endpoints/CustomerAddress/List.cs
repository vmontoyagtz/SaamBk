using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListCustomerAddressRequest>.WithActionResult<
        ListCustomerAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerAddress> _repository;

        public List(IRepository<CustomerAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerAddresses")]
        [SwaggerOperation(
            Summary = "List CustomerAddresses",
            Description = "List CustomerAddresses",
            OperationId = "customerAddresses.List",
            Tags = new[] { "CustomerAddressEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerAddressResponse>> HandleAsync(
            [FromQuery] ListCustomerAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerAddressResponse(request.CorrelationId());

            var spec = new CustomerAddressGetListSpec();
            var customerAddresses = await _repository.ListAsync(spec);
            if (customerAddresses is null)
            {
                return NotFound();
            }

            response.CustomerAddresses = _mapper.Map<List<CustomerAddressDto>>(customerAddresses);
            response.Count = response.CustomerAddresses.Count;

            return Ok(response);
        }
    }
}