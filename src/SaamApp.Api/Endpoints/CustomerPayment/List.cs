using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPaymentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListCustomerPaymentRequest>.WithActionResult<
        ListCustomerPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerPayment> _repository;

        public List(IRepository<CustomerPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerPayments")]
        [SwaggerOperation(
            Summary = "List CustomerPayments",
            Description = "List CustomerPayments",
            OperationId = "customerPayments.List",
            Tags = new[] { "CustomerPaymentEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerPaymentResponse>> HandleAsync(
            [FromQuery] ListCustomerPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerPaymentResponse(request.CorrelationId());

            var spec = new CustomerPaymentGetListSpec();
            var customerPayments = await _repository.ListAsync(spec);
            if (customerPayments is null)
            {
                return NotFound();
            }

            response.CustomerPayments = _mapper.Map<List<CustomerPaymentDto>>(customerPayments);
            response.Count = response.CustomerPayments.Count;

            return Ok(response);
        }
    }
}