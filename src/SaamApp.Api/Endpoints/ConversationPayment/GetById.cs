using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ConversationPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationPaymentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdConversationPaymentRequest>.WithActionResult<
        GetByIdConversationPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ConversationPayment> _repository;

        public GetById(
            IRepository<ConversationPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/conversationPayments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a ConversationPayment by Id",
            Description = "Gets a ConversationPayment by Id",
            OperationId = "conversationPayments.GetById",
            Tags = new[] { "ConversationPaymentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdConversationPaymentResponse>> HandleAsync(
            [FromRoute] GetByIdConversationPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdConversationPaymentResponse(request.CorrelationId());

            var conversationPayment = await _repository.GetByIdAsync(request.RowId);
            if (conversationPayment is null)
            {
                return NotFound();
            }

            response.ConversationPayment = _mapper.Map<ConversationPaymentDto>(conversationPayment);

            return Ok(response);
        }
    }
}