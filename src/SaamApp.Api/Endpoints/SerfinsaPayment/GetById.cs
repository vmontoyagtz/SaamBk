using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.SerfinsaPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.SerfinsaPaymentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdSerfinsaPaymentRequest>.WithActionResult<
        GetByIdSerfinsaPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<SerfinsaPayment> _repository;

        public GetById(
            IRepository<SerfinsaPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/serfinsaPayments/{SerfinsaPaymentId}")]
        [SwaggerOperation(
            Summary = "Get a SerfinsaPayment by Id",
            Description = "Gets a SerfinsaPayment by Id",
            OperationId = "serfinsaPayments.GetById",
            Tags = new[] { "SerfinsaPaymentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdSerfinsaPaymentResponse>> HandleAsync(
            [FromRoute] GetByIdSerfinsaPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdSerfinsaPaymentResponse(request.CorrelationId());

            var serfinsaPayment = await _repository.GetByIdAsync(request.SerfinsaPaymentId);
            if (serfinsaPayment is null)
            {
                return NotFound();
            }

            response.SerfinsaPayment = _mapper.Map<SerfinsaPaymentDto>(serfinsaPayment);

            return Ok(response);
        }
    }
}