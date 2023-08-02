using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AiFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiFeedbackEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAiFeedbackRequest>.WithActionResult<
        CreateAiFeedbackResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiFeedback> _repository;

        public Create(
            IRepository<AiFeedback> repository,
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

        [HttpPost("api/aiFeedbacks")]
        [SwaggerOperation(
            Summary = "Creates a new AiFeedback",
            Description = "Creates a new AiFeedback",
            OperationId = "aiFeedbacks.create",
            Tags = new[] { "AiFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<CreateAiFeedbackResponse>> HandleAsync(
            CreateAiFeedbackRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAiFeedbackResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newAiFeedback = new AiFeedback(
                Guid.NewGuid(),
                request.CustomerId,
                request.ModelId,
                request.Question,
                request.Response,
                request.UserFeedback,
                request.AISessionId,
                request.InteractionTime
            );


            await _repository.AddAsync(newAiFeedback);

            _logger.LogInformation(
                $"AiFeedback created  with Id {newAiFeedback.AiFeedbackId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AiFeedbackDto>(newAiFeedback);

            var aiFeedbackCreatedEvent = new AiFeedbackCreatedEvent(newAiFeedback, "Mongo-History");
            _messagePublisher.Publish(aiFeedbackCreatedEvent);

            response.AiFeedback = dto;


            return Ok(response);
        }
    }
}