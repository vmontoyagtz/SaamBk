using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListPaymentMethodRequest>.WithActionResult<
        ListPaymentMethodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PaymentMethod> _repository;

        public List(IRepository<PaymentMethod> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/paymentMethods")]
        [SwaggerOperation(
            Summary = "List PaymentMethods",
            Description = "List PaymentMethods",
            OperationId = "paymentMethods.List",
            Tags = new[] { "PaymentMethodEndpoints" })
        ]
        public override async Task<ActionResult<ListPaymentMethodResponse>> HandleAsync(
            [FromQuery] ListPaymentMethodRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListPaymentMethodResponse(request.CorrelationId());

            var spec = new PaymentMethodGetListSpec();
            var paymentMethods = await _repository.ListAsync(spec);
            if (paymentMethods is null)
            {
                return NotFound();
            }

            response.PaymentMethods = _mapper.Map<List<PaymentMethodDto>>(paymentMethods);
            response.Count = response.PaymentMethods.Count;

            return Ok(response);
        }
    }
}