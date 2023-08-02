using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Message;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateMessageRequest>.WithActionResult<
        CreateMessageResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _repository;

        public Create(
            IRepository<Message> repository,
            IRepository<Advisor> advisorRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _advisorRepository = advisorRepository;
        }

        [HttpPost("api/messages")]
        [SwaggerOperation(
            Summary = "Creates a new Message",
            Description = "Creates a new Message",
            OperationId = "messages.create",
            Tags = new[] { "MessageEndpoints" })
        ]
        public override async Task<ActionResult<CreateMessageResponse>> HandleAsync(
            CreateMessageRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateMessageResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newMessage = new Message(
                Guid.NewGuid(),
                request.AdvisorId,
                request.ConversationId,
                request.CustomerId,
                request.InteractionTypeId,
                request.MessageTypeId,
                request.ProductId,
                request.RegionAreaAdvisorCategoryId,
                request.MessageContent,
                request.MessageDetailTimeInSecs,
                request.MessageDetailSpent,
                request.TemplatetId,
                request.ReplyToMessageId,
                request.SentByAdvisor,
                request.SentByCustomer,
                request.HasBeenReadByCustomer,
                request.HasBeenReadByAdvisor,
                request.ReadByCustomerAt,
                request.ReadByAdvisorAt,
                request.HasAttachments,
                request.AiRobot,
                request.IsChat,
                request.IsVoiceCall,
                request.IsVideoCall,
                request.IsVoiceNote,
                request.VoiceNoteApproved,
                request.VoiceNoteSize,
                request.LowBalance,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newMessage);

            _logger.LogInformation(
                $"Message created  with Id {newMessage.MessageId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<MessageDto>(newMessage);

            var messageCreatedEvent = new MessageCreatedEvent(newMessage, "Mongo-History");
            _messagePublisher.Publish(messageCreatedEvent);

            response.Message = dto;


            return Ok(response);
        }
    }
}