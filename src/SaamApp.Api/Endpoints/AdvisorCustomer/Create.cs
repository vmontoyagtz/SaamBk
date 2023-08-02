using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorCustomer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorCustomerEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorCustomerRequest>.WithActionResult<
        CreateAdvisorCustomerResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorCustomer> _repository;

        public Create(
            IRepository<AdvisorCustomer> repository,
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

        [HttpPost("api/advisorCustomers")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorCustomer",
            Description = "Creates a new AdvisorCustomer",
            OperationId = "advisorCustomers.create",
            Tags = new[] { "AdvisorCustomerEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorCustomerResponse>> HandleAsync(
            CreateAdvisorCustomerRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorCustomerResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorCustomer = new AdvisorCustomer(
                request.AdvisorId,
                request.CustomerId
            );


            await _repository.AddAsync(newAdvisorCustomer);

            _logger.LogInformation(
                $"AdvisorCustomer created  with Id {newAdvisorCustomer.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorCustomerDto>(newAdvisorCustomer);

            var advisorCustomerCreatedEvent = new AdvisorCustomerCreatedEvent(newAdvisorCustomer, "Mongo-History");
            _messagePublisher.Publish(advisorCustomerCreatedEvent);

            response.AdvisorCustomer = dto;


            return Ok(response);
        }
    }
}