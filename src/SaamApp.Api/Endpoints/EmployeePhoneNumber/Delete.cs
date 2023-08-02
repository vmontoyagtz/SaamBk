using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeePhoneNumberEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteEmployeePhoneNumberRequest>.WithActionResult<
        DeleteEmployeePhoneNumberResponse>
    {
        private readonly IRepository<EmployeePhoneNumber> _employeePhoneNumberReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmployeePhoneNumber> _repository;

        public Delete(IRepository<EmployeePhoneNumber> EmployeePhoneNumberRepository,
            IRepository<EmployeePhoneNumber> EmployeePhoneNumberReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = EmployeePhoneNumberRepository;
            _employeePhoneNumberReadRepository = EmployeePhoneNumberReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/employeePhoneNumbers/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an EmployeePhoneNumber",
            Description = "Deletes an EmployeePhoneNumber",
            OperationId = "employeePhoneNumbers.delete",
            Tags = new[] { "EmployeePhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<DeleteEmployeePhoneNumberResponse>> HandleAsync(
            [FromRoute] DeleteEmployeePhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteEmployeePhoneNumberResponse(request.CorrelationId());

            var employeePhoneNumber = await _employeePhoneNumberReadRepository.GetByIdAsync(request.RowId);

            if (employeePhoneNumber == null)
            {
                return NotFound();
            }


            var employeePhoneNumberDeletedEvent =
                new EmployeePhoneNumberDeletedEvent(employeePhoneNumber, "Mongo-History");
            _messagePublisher.Publish(employeePhoneNumberDeletedEvent);

            await _repository.DeleteAsync(employeePhoneNumber);

            return Ok(response);
        }
    }
}