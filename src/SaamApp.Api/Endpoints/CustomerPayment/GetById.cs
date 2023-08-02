using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPaymentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerPaymentRequest>.WithActionResult<
        GetByIdCustomerPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerPayment> _repository;

        public GetById(
            IRepository<CustomerPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerPayments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerPayment by Id",
            Description = "Gets a CustomerPayment by Id",
            OperationId = "customerPayments.GetById",
            Tags = new[] { "CustomerPaymentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerPaymentResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerPaymentResponse(request.CorrelationId());

            var customerPayment = await _repository.GetByIdAsync(request.RowId);
            if (customerPayment is null)
            {
                return NotFound();
            }

            response.CustomerPayment = _mapper.Map<CustomerPaymentDto>(customerPayment);

            return Ok(response);
        }
    }
}