using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Message;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListMessageRequest>.WithActionResult<ListMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Message> _repository;

        public List(IRepository<Message> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/messages")]
        [SwaggerOperation(
            Summary = "List Messages",
            Description = "List Messages",
            OperationId = "messages.List",
            Tags = new[] { "MessageEndpoints" })
        ]
        public override async Task<ActionResult<ListMessageResponse>> HandleAsync(
            [FromQuery] ListMessageRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListMessageResponse(request.CorrelationId());

            var spec = new MessageGetListSpec();
            var messages = await _repository.ListAsync(spec);
            if (messages is null)
            {
                return NotFound();
            }

            response.Messages = _mapper.Map<List<MessageDto>>(messages);
            response.Count = response.Messages.Count;

            return Ok(response);
        }
    }
}