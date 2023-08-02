using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PaymentFrequency;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PaymentFrequencyEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdPaymentFrequencyRequest>.WithActionResult<
        GetByIdPaymentFrequencyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PaymentFrequency> _repository;

        public GetById(
            IRepository<PaymentFrequency> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/paymentFrequencies/{PaymentFrequencyId}")]
        [SwaggerOperation(
            Summary = "Get a PaymentFrequency by Id",
            Description = "Gets a PaymentFrequency by Id",
            OperationId = "paymentFrequencies.GetById",
            Tags = new[] { "PaymentFrequencyEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPaymentFrequencyResponse>> HandleAsync(
            [FromRoute] GetByIdPaymentFrequencyRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdPaymentFrequencyResponse(request.CorrelationId());

            var paymentFrequency = await _repository.GetByIdAsync(request.PaymentFrequencyId);
            if (paymentFrequency is null)
            {
                return NotFound();
            }

            response.PaymentFrequency = _mapper.Map<PaymentFrequencyDto>(paymentFrequency);

            return Ok(response);
        }
    }
}