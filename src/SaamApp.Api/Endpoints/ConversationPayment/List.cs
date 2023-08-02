using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListConversationPaymentRequest>.WithActionResult<
        ListConversationPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ConversationPayment> _repository;

        public List(IRepository<ConversationPayment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/conversationPayments")]
        [SwaggerOperation(
            Summary = "List ConversationPayments",
            Description = "List ConversationPayments",
            OperationId = "conversationPayments.List",
            Tags = new[] { "ConversationPaymentEndpoints" })
        ]
        public override async Task<ActionResult<ListConversationPaymentResponse>> HandleAsync(
            [FromQuery] ListConversationPaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListConversationPaymentResponse(request.CorrelationId());

            var spec = new ConversationPaymentGetListSpec();
            var conversationPayments = await _repository.ListAsync(spec);
            if (conversationPayments is null)
            {
                return NotFound();
            }

            response.ConversationPayments = _mapper.Map<List<ConversationPaymentDto>>(conversationPayments);
            response.Count = response.ConversationPayments.Count;

            return Ok(response);
        }
    }
}