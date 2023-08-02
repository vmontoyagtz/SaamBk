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
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsAdvisorPaymentRequest>.WithActionResult<
        GetByIdAdvisorPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorPayment> _repository;

        public GetByRelsIds(
            IRepository<AdvisorPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(
            "api/advisorPayments/{AdvisorPaymentDescription}/{AdvisorPaymentsAmount}/{CreatedAt}/{CreatedBy}/{AdvisorId}/{BankAccountId}/{PaymentMethodId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorPayment by rel Ids",
            Description = "Gets a AdvisorPayment by rel Ids",
            OperationId = "advisorPayments.GetByRelsIds",
            Tags = new[] { "AdvisorPaymentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorPaymentResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsAdvisorPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorPaymentResponse(request.CorrelationId());

            var spec = new AdvisorPaymentByRelIdsSpec(request.AdvisorPaymentDescription, request.AdvisorPaymentsAmount,
                request.CreatedAt, request.CreatedBy, request.AdvisorId, request.BankAccountId,
                request.PaymentMethodId);

            var advisorPayment = await _repository.FirstOrDefaultAsync(spec);


            if (advisorPayment is null)
            {
                return NotFound();
            }

            response.AdvisorPayment = _mapper.Map<AdvisorPaymentDto>(advisorPayment);

            return Ok(response);
        }
    }
}