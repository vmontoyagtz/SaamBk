using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ConversationPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationPaymentEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsConversationPaymentRequest>.WithActionResult<
        GetByIdConversationPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ConversationPayment> _repository;

        public GetByRelsIds(
            IRepository<ConversationPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/conversationPayments/{AdvisorPaymentId}/{ConversationId}")]
        [SwaggerOperation(
            Summary = "Get a ConversationPayment by rel Ids",
            Description = "Gets a ConversationPayment by rel Ids",
            OperationId = "conversationPayments.GetByRelsIds",
            Tags = new[] { "ConversationPaymentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdConversationPaymentResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsConversationPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdConversationPaymentResponse(request.CorrelationId());

            var spec = new ConversationPaymentByRelIdsSpec(request.AdvisorPaymentId, request.ConversationId);

            var conversationPayment = await _repository.FirstOrDefaultAsync(spec);


            if (conversationPayment is null)
            {
                return NotFound();
            }

            response.ConversationPayment = _mapper.Map<ConversationPaymentDto>(conversationPayment);

            return Ok(response);
        }
    }
}