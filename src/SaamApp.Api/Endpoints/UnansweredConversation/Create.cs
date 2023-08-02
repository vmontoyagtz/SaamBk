using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.UnansweredConversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.UnansweredConversationEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateUnansweredConversationRequest>.WithActionResult<
        CreateUnansweredConversationResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<UnansweredConversation> _repository;

        public Create(
            IRepository<UnansweredConversation> repository,
            IRepository<Customer> customerRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _customerRepository = customerRepository;
        }

        [HttpPost("api/unansweredConversations")]
        [SwaggerOperation(
            Summary = "Creates a new UnansweredConversation",
            Description = "Creates a new UnansweredConversation",
            OperationId = "unansweredConversations.create",
            Tags = new[] { "UnansweredConversationEndpoints" })
        ]
        public override async Task<ActionResult<CreateUnansweredConversationResponse>> HandleAsync(
            CreateUnansweredConversationRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateUnansweredConversationResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newUnansweredConversation = new UnansweredConversation(
                Guid.NewGuid(),
                request.CustomerId,
                request.InteractionTypeId,
                request.RegionAreaAdvisorCategoryId,
                request.UnansweredConversationQuestion,
                request.UnansweredConversationAnsweredTime,
                request.Answered,
                request.Canceled,
                request.Unanswered,
                request.AiRobot,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newUnansweredConversation);

            _logger.LogInformation(
                $"UnansweredConversation created  with Id {newUnansweredConversation.UnansweredConversationId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<UnansweredConversationDto>(newUnansweredConversation);

            var unansweredConversationCreatedEvent =
                new UnansweredConversationCreatedEvent(newUnansweredConversation, "Mongo-History");
            _messagePublisher.Publish(unansweredConversationCreatedEvent);

            response.UnansweredConversation = dto;


            return Ok(response);
        }
    }
}