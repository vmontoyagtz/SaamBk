using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.MessageType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.MessageTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateMessageTypeRequest>.WithActionResult<
        UpdateMessageTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<MessageType> _repository;

        public Update(
            IRepository<MessageType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/messageTypes")]
        [SwaggerOperation(
            Summary = "Updates a MessageType",
            Description = "Updates a MessageType",
            OperationId = "messageTypes.update",
            Tags = new[] { "MessageTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateMessageTypeResponse>> HandleAsync(
            UpdateMessageTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateMessageTypeResponse(request.CorrelationId());

            var mtetstToUpdate = _mapper.Map<MessageType>(request);

            var messageTypeToUpdateTest = await _repository.GetByIdAsync(request.MessageTypeId);
            if (messageTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(mtetstToUpdate);

            var messageTypeUpdatedEvent = new MessageTypeUpdatedEvent(mtetstToUpdate, "Mongo-History");
            _messagePublisher.Publish(messageTypeUpdatedEvent);

            var dto = _mapper.Map<MessageTypeDto>(mtetstToUpdate);
            response.MessageType = dto;

            return Ok(response);
        }
    }
}