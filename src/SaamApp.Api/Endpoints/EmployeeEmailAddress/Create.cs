using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeEmailAddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateEmployeeEmailAddressRequest>.WithActionResult<
        CreateEmployeeEmailAddressResponse>
    {
        private readonly IRepository<EmailAddress> _emailAddressRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmployeeEmailAddress> _repository;

        public Create(
            IRepository<EmployeeEmailAddress> repository,
            IRepository<EmailAddress> emailAddressRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _emailAddressRepository = emailAddressRepository;
        }

        [HttpPost("api/employeeEmailAddresses")]
        [SwaggerOperation(
            Summary = "Creates a new EmployeeEmailAddress",
            Description = "Creates a new EmployeeEmailAddress",
            OperationId = "employeeEmailAddresses.create",
            Tags = new[] { "EmployeeEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateEmployeeEmailAddressResponse>> HandleAsync(
            CreateEmployeeEmailAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateEmployeeEmailAddressResponse(request.CorrelationId());

            //var emailAddress = await _emailAddressRepository.GetByIdAsync(request.EmailAddressId);// parent entity

            var newEmployeeEmailAddress = new EmployeeEmailAddress(
                request.EmailAddressId,
                request.EmailAddressTypeId,
                request.EmployeeId
            );


            await _repository.AddAsync(newEmployeeEmailAddress);

            _logger.LogInformation(
                $"EmployeeEmailAddress created  with Id {newEmployeeEmailAddress.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<EmployeeEmailAddressDto>(newEmployeeEmailAddress);

            var employeeEmailAddressCreatedEvent =
                new EmployeeEmailAddressCreatedEvent(newEmployeeEmailAddress, "Mongo-History");
            _messagePublisher.Publish(employeeEmailAddressCreatedEvent);

            response.EmployeeEmailAddress = dto;


            return Ok(response);
        }
    }
}