using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.EmployeePhoneNumberEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateEmployeePhoneNumberRequest>.WithActionResult<
        UpdateEmployeePhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmployeePhoneNumber> _repository;

        public Update(
            IRepository<EmployeePhoneNumber> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/employeePhoneNumbers")]
        [SwaggerOperation(
            Summary = "Updates a EmployeePhoneNumber",
            Description = "Updates a EmployeePhoneNumber",
            OperationId = "employeePhoneNumbers.update",
            Tags = new[] { "EmployeePhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<UpdateEmployeePhoneNumberResponse>> HandleAsync(
            UpdateEmployeePhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateEmployeePhoneNumberResponse(request.CorrelationId());

            var epnmpnppnToUpdate = _mapper.Map<EmployeePhoneNumber>(request);

            var employeePhoneNumberToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (employeePhoneNumberToUpdateTest is null)
            {
                return NotFound();
            }

            epnmpnppnToUpdate.UpdateEmployeeForEmployeePhoneNumber(request.EmployeeId);
            epnmpnppnToUpdate.UpdatePhoneNumberForEmployeePhoneNumber(request.PhoneNumberId);
            epnmpnppnToUpdate.UpdatePhoneNumberTypeForEmployeePhoneNumber(request.PhoneNumberTypeId);
            await _repository.UpdateAsync(epnmpnppnToUpdate);

            var employeePhoneNumberUpdatedEvent =
                new EmployeePhoneNumberUpdatedEvent(epnmpnppnToUpdate, "Mongo-History");
            _messagePublisher.Publish(employeePhoneNumberUpdatedEvent);

            var dto = _mapper.Map<EmployeePhoneNumberDto>(epnmpnppnToUpdate);
            response.EmployeePhoneNumber = dto;

            return Ok(response);
        }
    }
}