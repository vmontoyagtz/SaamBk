using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListPaymentFrequencyRequest>.WithActionResult<
        ListPaymentFrequencyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PaymentFrequency> _repository;

        public List(IRepository<PaymentFrequency> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/paymentFrequencies")]
        [SwaggerOperation(
            Summary = "List PaymentFrequencies",
            Description = "List PaymentFrequencies",
            OperationId = "paymentFrequencies.List",
            Tags = new[] { "PaymentFrequencyEndpoints" })
        ]
        public override async Task<ActionResult<ListPaymentFrequencyResponse>> HandleAsync(
            [FromQuery] ListPaymentFrequencyRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListPaymentFrequencyResponse(request.CorrelationId());

            var spec = new PaymentFrequencyGetListSpec();
            var paymentFrequencies = await _repository.ListAsync(spec);
            if (paymentFrequencies is null)
            {
                return NotFound();
            }

            response.PaymentFrequencies = _mapper.Map<List<PaymentFrequencyDto>>(paymentFrequencies);
            response.Count = response.PaymentFrequencies.Count;

            return Ok(response);
        }
    }
}