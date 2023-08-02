using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerEmailAddressEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListCustomerEmailAddressRequest>.WithActionResult<
        ListCustomerEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerEmailAddress> _repository;

        public List(IRepository<CustomerEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerEmailAddresses")]
        [SwaggerOperation(
            Summary = "List CustomerEmailAddresses",
            Description = "List CustomerEmailAddresses",
            OperationId = "customerEmailAddresses.List",
            Tags = new[] { "CustomerEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerEmailAddressResponse>> HandleAsync(
            [FromQuery] ListCustomerEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerEmailAddressResponse(request.CorrelationId());

            var spec = new CustomerEmailAddressGetListSpec();
            var customerEmailAddresses = await _repository.ListAsync(spec);
            if (customerEmailAddresses is null)
            {
                return NotFound();
            }

            response.CustomerEmailAddresses = _mapper.Map<List<CustomerEmailAddressDto>>(customerEmailAddresses);
            response.Count = response.CustomerEmailAddresses.Count;

            return Ok(response);
        }
    }
}