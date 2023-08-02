using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorPaymentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorPaymentRequest>.WithActionResult<
        ListAdvisorPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorPayment> _repository;

        public List(IRepository<AdvisorPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorPayments")]
        [SwaggerOperation(
            Summary = "List AdvisorPayments",
            Description = "List AdvisorPayments",
            OperationId = "advisorPayments.List",
            Tags = new[] { "AdvisorPaymentEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorPaymentResponse>> HandleAsync(
            [FromQuery] ListAdvisorPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorPaymentResponse(request.CorrelationId());

            var spec = new AdvisorPaymentGetListSpec();
            var advisorPayments = await _repository.ListAsync(spec);
            if (advisorPayments is null)
            {
                return NotFound();
            }

            response.AdvisorPayments = _mapper.Map<List<AdvisorPaymentDto>>(advisorPayments);
            response.Count = response.AdvisorPayments.Count;

            return Ok(response);
        }
    }
}