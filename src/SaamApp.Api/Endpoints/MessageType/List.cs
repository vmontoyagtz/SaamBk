using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.MessageType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListMessageTypeRequest>.WithActionResult<ListMessageTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<MessageType> _repository;

        public List(IRepository<MessageType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/messageTypes")]
        [SwaggerOperation(
            Summary = "List MessageTypes",
            Description = "List MessageTypes",
            OperationId = "messageTypes.List",
            Tags = new[] { "MessageTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListMessageTypeResponse>> HandleAsync(
            [FromQuery] ListMessageTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListMessageTypeResponse(request.CorrelationId());

            var spec = new MessageTypeGetListSpec();
            var messageTypes = await _repository.ListAsync(spec);
            if (messageTypes is null)
            {
                return NotFound();
            }

            response.MessageTypes = _mapper.Map<List<MessageTypeDto>>(messageTypes);
            response.Count = response.MessageTypes.Count;

            return Ok(response);
        }
    }
}