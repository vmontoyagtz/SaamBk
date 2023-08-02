using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.EmployeeEmailAddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateEmployeeEmailAddressRequest>.WithActionResult<
        UpdateEmployeeEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmployeeEmailAddress> _repository;

        public Update(
            IRepository<EmployeeEmailAddress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/employeeEmailAddresses")]
        [SwaggerOperation(
            Summary = "Updates a EmployeeEmailAddress",
            Description = "Updates a EmployeeEmailAddress",
            OperationId = "employeeEmailAddresses.update",
            Tags = new[] { "EmployeeEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateEmployeeEmailAddressResponse>> HandleAsync(
            UpdateEmployeeEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateEmployeeEmailAddressResponse(request.CorrelationId());

            var eeameapeaToUpdate = _mapper.Map<EmployeeEmailAddress>(request);

            var employeeEmailAddressToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (employeeEmailAddressToUpdateTest is null)
            {
                return NotFound();
            }

            eeameapeaToUpdate.UpdateEmailAddressForEmployeeEmailAddress(request.EmailAddressId);
            eeameapeaToUpdate.UpdateEmailAddressTypeForEmployeeEmailAddress(request.EmailAddressTypeId);
            eeameapeaToUpdate.UpdateEmployeeForEmployeeEmailAddress(request.EmployeeId);
            await _repository.UpdateAsync(eeameapeaToUpdate);

            var employeeEmailAddressUpdatedEvent =
                new EmployeeEmailAddressUpdatedEvent(eeameapeaToUpdate, "Mongo-History");
            _messagePublisher.Publish(employeeEmailAddressUpdatedEvent);

            var dto = _mapper.Map<EmployeeEmailAddressDto>(eeameapeaToUpdate);
            response.EmployeeEmailAddress = dto;

            return Ok(response);
        }
    }
}