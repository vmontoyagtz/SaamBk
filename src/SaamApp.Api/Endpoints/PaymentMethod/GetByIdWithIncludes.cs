using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PaymentMethod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PaymentMethodEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdPaymentMethodRequest>.WithActionResult<
        GetByIdPaymentMethodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PaymentMethod> _repository;

        public GetByIdWithIncludes(
            IRepository<PaymentMethod> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/paymentMethods/i/{PaymentMethodId}")]
        [SwaggerOperation(
            Summary = "Get a PaymentMethod by Id With Includes",
            Description = "Gets a PaymentMethod by Id With Includes",
            OperationId = "paymentMethods.GetByIdWithIncludes",
            Tags = new[] { "PaymentMethodEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPaymentMethodResponse>> HandleAsync(
            [FromRoute] GetByIdPaymentMethodRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdPaymentMethodResponse(request.CorrelationId());

            var spec = new PaymentMethodByIdWithIncludesSpec(request.PaymentMethodId);

            var paymentMethod = await _repository.FirstOrDefaultAsync(spec);


            if (paymentMethod is null)
            {
                return NotFound();
            }

            response.PaymentMethod = _mapper.Map<PaymentMethodDto>(paymentMethod);

            return Ok(response);
        }
    }
}