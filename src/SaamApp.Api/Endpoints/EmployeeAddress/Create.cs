using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.EmployeeAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeAddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateEmployeeAddressRequest>.WithActionResult<
        CreateEmployeeAddressResponse>
    {
        private readonly IRepository<Address> _addressRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmployeeAddress> _repository;

        public Create(
            IRepository<EmployeeAddress> repository,
            IRepository<Address> addressRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _addressRepository = addressRepository;
        }

        [HttpPost("api/employeeAddresses")]
        [SwaggerOperation(
            Summary = "Creates a new EmployeeAddress",
            Description = "Creates a new EmployeeAddress",
            OperationId = "employeeAddresses.create",
            Tags = new[] { "EmployeeAddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateEmployeeAddressResponse>> HandleAsync(
            CreateEmployeeAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateEmployeeAddressResponse(request.CorrelationId());

            //var address = await _addressRepository.GetByIdAsync(request.AddressId);// parent entity

            var newEmployeeAddress = new EmployeeAddress(
                request.AddressId,
                request.AddressTypeId,
                request.EmployeeId
            );


            await _repository.AddAsync(newEmployeeAddress);

            _logger.LogInformation(
                $"EmployeeAddress created  with Id {newEmployeeAddress.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<EmployeeAddressDto>(newEmployeeAddress);

            var employeeAddressCreatedEvent = new EmployeeAddressCreatedEvent(newEmployeeAddress, "Mongo-History");
            _messagePublisher.Publish(employeeAddressCreatedEvent);

            response.EmployeeAddress = dto;


            return Ok(response);
        }
    }
}