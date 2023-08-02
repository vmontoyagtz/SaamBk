using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorPaymentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorPaymentRequest>.WithActionResult<
        GetByIdAdvisorPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorPayment> _repository;

        public GetById(
            IRepository<AdvisorPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorPayments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorPayment by Id",
            Description = "Gets a AdvisorPayment by Id",
            OperationId = "advisorPayments.GetById",
            Tags = new[] { "AdvisorPaymentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorPaymentResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorPaymentResponse(request.CorrelationId());

            var advisorPayment = await _repository.GetByIdAsync(request.RowId);
            if (advisorPayment is null)
            {
                return NotFound();
            }

            response.AdvisorPayment = _mapper.Map<AdvisorPaymentDto>(advisorPayment);

            return Ok(response);
        }
    }
}