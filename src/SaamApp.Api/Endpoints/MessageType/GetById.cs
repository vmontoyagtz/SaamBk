using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.MessageType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdMessageTypeRequest>.WithActionResult<
        GetByIdMessageTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<MessageType> _repository;

        public GetById(
            IRepository<MessageType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/messageTypes/{MessageTypeId}")]
        [SwaggerOperation(
            Summary = "Get a MessageType by Id",
            Description = "Gets a MessageType by Id",
            OperationId = "messageTypes.GetById",
            Tags = new[] { "MessageTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdMessageTypeResponse>> HandleAsync(
            [FromRoute] GetByIdMessageTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdMessageTypeResponse(request.CorrelationId());

            var messageType = await _repository.GetByIdAsync(request.MessageTypeId);
            if (messageType is null)
            {
                return NotFound();
            }

            response.MessageType = _mapper.Map<MessageTypeDto>(messageType);

            return Ok(response);
        }
    }
}