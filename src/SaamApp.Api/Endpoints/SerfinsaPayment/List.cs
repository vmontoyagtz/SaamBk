using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.SerfinsaPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.SerfinsaPaymentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListSerfinsaPaymentRequest>.WithActionResult<
        ListSerfinsaPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<SerfinsaPayment> _repository;

        public List(IRepository<SerfinsaPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/serfinsaPayments")]
        [SwaggerOperation(
            Summary = "List SerfinsaPayments",
            Description = "List SerfinsaPayments",
            OperationId = "serfinsaPayments.List",
            Tags = new[] { "SerfinsaPaymentEndpoints" })
        ]
        public override async Task<ActionResult<ListSerfinsaPaymentResponse>> HandleAsync(
            [FromQuery] ListSerfinsaPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListSerfinsaPaymentResponse(request.CorrelationId());

            var spec = new SerfinsaPaymentGetListSpec();
            var serfinsaPayments = await _repository.ListAsync(spec);
            if (serfinsaPayments is null)
            {
                return NotFound();
            }

            response.SerfinsaPayments = _mapper.Map<List<SerfinsaPaymentDto>>(serfinsaPayments);
            response.Count = response.SerfinsaPayments.Count;

            return Ok(response);
        }
    }
}