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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdSerfinsaPaymentRequest>.WithActionResult<
        GetByIdSerfinsaPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<SerfinsaPayment> _repository;

        public GetByIdWithIncludes(
            IRepository<SerfinsaPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/serfinsaPayments/i/{SerfinsaPaymentId}")]
        [SwaggerOperation(
            Summary = "Get a SerfinsaPayment by Id With Includes",
            Description = "Gets a SerfinsaPayment by Id With Includes",
            OperationId = "serfinsaPayments.GetByIdWithIncludes",
            Tags = new[] { "SerfinsaPaymentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdSerfinsaPaymentResponse>> HandleAsync(
            [FromRoute] GetByIdSerfinsaPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdSerfinsaPaymentResponse(request.CorrelationId());

            var spec = new SerfinsaPaymentByIdWithIncludesSpec(request.SerfinsaPaymentId);

            var serfinsaPayment = await _repository.FirstOrDefaultAsync(spec);


            if (serfinsaPayment is null)
            {
                return NotFound();
            }

            response.SerfinsaPayment = _mapper.Map<SerfinsaPaymentDto>(serfinsaPayment);

            return Ok(response);
        }
    }
}