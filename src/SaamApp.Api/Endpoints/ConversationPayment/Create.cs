using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.ConversationPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationPaymentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateConversationPaymentRequest>.WithActionResult<
        CreateConversationPaymentResponse>
    {
        private readonly IRepository<Conversation> _conversationRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ConversationPayment> _repository;

        public Create(
            IRepository<ConversationPayment> repository,
            IRepository<Conversation> conversationRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _conversationRepository = conversationRepository;
        }

        [HttpPost("api/conversationPayments")]
        [SwaggerOperation(
            Summary = "Creates a new ConversationPayment",
            Description = "Creates a new ConversationPayment",
            OperationId = "conversationPayments.create",
            Tags = new[] { "ConversationPaymentEndpoints" })
        ]
        public override async Task<ActionResult<CreateConversationPaymentResponse>> HandleAsync(
            CreateConversationPaymentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateConversationPaymentResponse(request.CorrelationId());

            //var conversation = await _conversationRepository.GetByIdAsync(request.ConversationId);// parent entity

            var newConversationPayment = new ConversationPayment(
                request.ConversationId,
                request.AdvisorPaymentId,
                request.ConversationPaymentStage
            );


            await _repository.AddAsync(newConversationPayment);

            _logger.LogInformation(
                $"ConversationPayment created  with Id {newConversationPayment.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<ConversationPaymentDto>(newConversationPayment);

            var conversationPaymentCreatedEvent =
                new ConversationPaymentCreatedEvent(newConversationPayment, "Mongo-History");
            _messagePublisher.Publish(conversationPaymentCreatedEvent);

            response.ConversationPayment = dto;


            return Ok(response);
        }
    }
}