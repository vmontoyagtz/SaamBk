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
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsCustomerPaymentRequest>.WithActionResult<
        GetByIdCustomerPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerPayment> _repository;

        public GetByRelsIds(
            IRepository<CustomerPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerPayments/{PaymentMethodId}/{SerfinsaPaymentId}/{TenantId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerPayment by rel Ids",
            Description = "Gets a CustomerPayment by rel Ids",
            OperationId = "customerPayments.GetByRelsIds",
            Tags = new[] { "CustomerPaymentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerPaymentResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsCustomerPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerPaymentResponse(request.CorrelationId());

            var spec = new CustomerPaymentByRelIdsSpec(request.PaymentMethodId, request.SerfinsaPaymentId,
                request.TenantId);

            var customerPayment = await _repository.FirstOrDefaultAsync(spec);


            if (customerPayment is null)
            {
                return NotFound();
            }

            response.CustomerPayment = _mapper.Map<CustomerPaymentDto>(customerPayment);

            return Ok(response);
        }
    }
}