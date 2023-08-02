using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeePhoneNumberEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateEmployeePhoneNumberRequest>.WithActionResult<
        CreateEmployeePhoneNumberResponse>
    {
        private readonly IRepository<Employee> _employeeRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmployeePhoneNumber> _repository;

        public Create(
            IRepository<EmployeePhoneNumber> repository,
            IRepository<Employee> employeeRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        [HttpPost("api/employeePhoneNumbers")]
        [SwaggerOperation(
            Summary = "Creates a new EmployeePhoneNumber",
            Description = "Creates a new EmployeePhoneNumber",
            OperationId = "employeePhoneNumbers.create",
            Tags = new[] { "EmployeePhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<CreateEmployeePhoneNumberResponse>> HandleAsync(
            CreateEmployeePhoneNumberRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateEmployeePhoneNumberResponse(request.CorrelationId());

            //var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);// parent entity

            var newEmployeePhoneNumber = new EmployeePhoneNumber(
                request.EmployeeId,
                request.PhoneNumberId,
                request.PhoneNumberTypeId
            );


            await _repository.AddAsync(newEmployeePhoneNumber);

            _logger.LogInformation(
                $"EmployeePhoneNumber created  with Id {newEmployeePhoneNumber.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<EmployeePhoneNumberDto>(newEmployeePhoneNumber);

            var employeePhoneNumberCreatedEvent =
                new EmployeePhoneNumberCreatedEvent(newEmployeePhoneNumber, "Mongo-History");
            _messagePublisher.Publish(employeePhoneNumberCreatedEvent);

            response.EmployeePhoneNumber = dto;


            return Ok(response);
        }
    }
}