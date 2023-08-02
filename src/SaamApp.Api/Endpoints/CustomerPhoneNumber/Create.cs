using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPhoneNumberEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerPhoneNumberRequest>.WithActionResult<
        CreateCustomerPhoneNumberResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerPhoneNumber> _repository;

        public Create(
            IRepository<CustomerPhoneNumber> repository,
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

        [HttpPost("api/customerPhoneNumbers")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerPhoneNumber",
            Description = "Creates a new CustomerPhoneNumber",
            OperationId = "customerPhoneNumbers.create",
            Tags = new[] { "CustomerPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerPhoneNumberResponse>> HandleAsync(
            CreateCustomerPhoneNumberRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerPhoneNumberResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newCustomerPhoneNumber = new CustomerPhoneNumber(
                request.CustomerId,
                request.PhoneNumberId,
                request.PhoneNumberTypeId
            );


            await _repository.AddAsync(newCustomerPhoneNumber);

            _logger.LogInformation(
                $"CustomerPhoneNumber created  with Id {newCustomerPhoneNumber.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerPhoneNumberDto>(newCustomerPhoneNumber);

            var customerPhoneNumberCreatedEvent =
                new CustomerPhoneNumberCreatedEvent(newCustomerPhoneNumber, "Mongo-History");
            _messagePublisher.Publish(customerPhoneNumberCreatedEvent);

            response.CustomerPhoneNumber = dto;


            return Ok(response);
        }
    }
}