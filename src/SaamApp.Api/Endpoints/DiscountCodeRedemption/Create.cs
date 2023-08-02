using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DiscountCodeRedemptionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateDiscountCodeRedemptionRequest>.WithActionResult<
        CreateDiscountCodeRedemptionResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<DiscountCodeRedemption> _repository;

        public Create(
            IRepository<DiscountCodeRedemption> repository,
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

        [HttpPost("api/discountCodeRedemptions")]
        [SwaggerOperation(
            Summary = "Creates a new DiscountCodeRedemption",
            Description = "Creates a new DiscountCodeRedemption",
            OperationId = "discountCodeRedemptions.create",
            Tags = new[] { "DiscountCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<CreateDiscountCodeRedemptionResponse>> HandleAsync(
            CreateDiscountCodeRedemptionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateDiscountCodeRedemptionResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newDiscountCodeRedemption = new DiscountCodeRedemption(
                request.CustomerId,
                request.DiscountCodeId,
                request.DiscountCodeRedemptionDate
            );


            await _repository.AddAsync(newDiscountCodeRedemption);

            _logger.LogInformation(
                $"DiscountCodeRedemption created  with Id {newDiscountCodeRedemption.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<DiscountCodeRedemptionDto>(newDiscountCodeRedemption);

            var discountCodeRedemptionCreatedEvent =
                new DiscountCodeRedemptionCreatedEvent(newDiscountCodeRedemption, "Mongo-History");
            _messagePublisher.Publish(discountCodeRedemptionCreatedEvent);

            response.DiscountCodeRedemption = dto;


            return Ok(response);
        }
    }
}