using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerReview;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerReviewEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerReviewRequest>.WithActionResult<
        CreateCustomerReviewResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerReview> _repository;

        public Create(
            IRepository<CustomerReview> repository,
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

        [HttpPost("api/customerReviews")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerReview",
            Description = "Creates a new CustomerReview",
            OperationId = "customerReviews.create",
            Tags = new[] { "CustomerReviewEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerReviewResponse>> HandleAsync(
            CreateCustomerReviewRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerReviewResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newCustomerReview = new CustomerReview(
                Guid.NewGuid(),
                request.AdvisorId,
                request.CustomerId,
                request.Rating,
                request.ReviewText,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newCustomerReview);

            _logger.LogInformation(
                $"CustomerReview created  with Id {newCustomerReview.CustomerReviewId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerReviewDto>(newCustomerReview);

            var customerReviewCreatedEvent = new CustomerReviewCreatedEvent(newCustomerReview, "Mongo-History");
            _messagePublisher.Publish(customerReviewCreatedEvent);

            response.CustomerReview = dto;


            return Ok(response);
        }
    }
}