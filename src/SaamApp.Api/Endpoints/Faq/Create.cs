using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Faq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.FaqEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateFaqRequest>.WithActionResult<
        CreateFaqResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Faq> _repository;

        public Create(
            IRepository<Faq> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/faqs")]
        [SwaggerOperation(
            Summary = "Creates a new Faq",
            Description = "Creates a new Faq",
            OperationId = "faqs.create",
            Tags = new[] { "FaqEndpoints" })
        ]
        public override async Task<ActionResult<CreateFaqResponse>> HandleAsync(
            CreateFaqRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateFaqResponse(request.CorrelationId());


            var newFaq = new Faq(
                Guid.NewGuid(),
                request.FaqQuestion,
                request.FaqAnswer,
                request.TenantId
            );


            await _repository.AddAsync(newFaq);

            _logger.LogInformation($"Faq created  with Id {newFaq.FaqId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<FaqDto>(newFaq);

            var faqCreatedEvent = new FaqCreatedEvent(newFaq, "Mongo-History");
            _messagePublisher.Publish(faqCreatedEvent);

            response.Faq = dto;


            return Ok(response);
        }
    }
}