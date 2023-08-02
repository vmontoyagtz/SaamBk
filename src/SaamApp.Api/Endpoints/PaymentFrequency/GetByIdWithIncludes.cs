using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PaymentFrequency;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PaymentFrequencyEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdPaymentFrequencyRequest>.WithActionResult<
        GetByIdPaymentFrequencyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PaymentFrequency> _repository;

        public GetByIdWithIncludes(
            IRepository<PaymentFrequency> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/paymentFrequencies/i/{PaymentFrequencyId}")]
        [SwaggerOperation(
            Summary = "Get a PaymentFrequency by Id With Includes",
            Description = "Gets a PaymentFrequency by Id With Includes",
            OperationId = "paymentFrequencies.GetByIdWithIncludes",
            Tags = new[] { "PaymentFrequencyEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPaymentFrequencyResponse>> HandleAsync(
            [FromRoute] GetByIdPaymentFrequencyRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdPaymentFrequencyResponse(request.CorrelationId());

            var spec = new PaymentFrequencyByIdWithIncludesSpec(request.PaymentFrequencyId);

            var paymentFrequency = await _repository.FirstOrDefaultAsync(spec);


            if (paymentFrequency is null)
            {
                return NotFound();
            }

            response.PaymentFrequency = _mapper.Map<PaymentFrequencyDto>(paymentFrequency);

            return Ok(response);
        }
    }
}