using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPhoneNumberEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListCustomerPhoneNumberRequest>.WithActionResult<
        ListCustomerPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerPhoneNumber> _repository;

        public List(IRepository<CustomerPhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerPhoneNumbers")]
        [SwaggerOperation(
            Summary = "List CustomerPhoneNumbers",
            Description = "List CustomerPhoneNumbers",
            OperationId = "customerPhoneNumbers.List",
            Tags = new[] { "CustomerPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerPhoneNumberResponse>> HandleAsync(
            [FromQuery] ListCustomerPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerPhoneNumberResponse(request.CorrelationId());

            var spec = new CustomerPhoneNumberGetListSpec();
            var customerPhoneNumbers = await _repository.ListAsync(spec);
            if (customerPhoneNumbers is null)
            {
                return NotFound();
            }

            response.CustomerPhoneNumbers = _mapper.Map<List<CustomerPhoneNumberDto>>(customerPhoneNumbers);
            response.Count = response.CustomerPhoneNumbers.Count;

            return Ok(response);
        }
    }
}