using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PhoneNumberEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeletePhoneNumberRequest>.WithActionResult<
        DeletePhoneNumberResponse>
    {
        private readonly IRepository<AdvisorPhoneNumber> _advisorPhoneNumberRepository;
        private readonly IRepository<BusinessUnitPhoneNumber> _businessUnitPhoneNumberRepository;
        private readonly IRepository<CustomerPhoneNumber> _customerPhoneNumberRepository;
        private readonly IRepository<EmployeePhoneNumber> _employeePhoneNumberRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PhoneNumber> _phoneNumberReadRepository;
        private readonly IRepository<PhoneNumber> _repository;

        public Delete(IRepository<PhoneNumber> PhoneNumberRepository,
            IRepository<PhoneNumber> PhoneNumberReadRepository,
            IRepository<AdvisorPhoneNumber> advisorPhoneNumberRepository,
            IRepository<BusinessUnitPhoneNumber> businessUnitPhoneNumberRepository,
            IRepository<CustomerPhoneNumber> customerPhoneNumberRepository,
            IRepository<EmployeePhoneNumber> employeePhoneNumberRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = PhoneNumberRepository;
            _phoneNumberReadRepository = PhoneNumberReadRepository;
            _advisorPhoneNumberRepository = advisorPhoneNumberRepository;
            _businessUnitPhoneNumberRepository = businessUnitPhoneNumberRepository;
            _customerPhoneNumberRepository = customerPhoneNumberRepository;
            _employeePhoneNumberRepository = employeePhoneNumberRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/phoneNumbers/{PhoneNumberId}")]
        [SwaggerOperation(
            Summary = "Deletes an PhoneNumber",
            Description = "Deletes an PhoneNumber",
            OperationId = "phoneNumbers.delete",
            Tags = new[] { "PhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<DeletePhoneNumberResponse>> HandleAsync(
            [FromRoute] DeletePhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePhoneNumberResponse(request.CorrelationId());

            var phoneNumber = await _phoneNumberReadRepository.GetByIdAsync(request.PhoneNumberId);

            if (phoneNumber == null)
            {
                return NotFound();
            }

            var advisorPhoneNumberSpec = new GetAdvisorPhoneNumberWithPhoneNumberKeySpec(phoneNumber.PhoneNumberId);
            var advisorPhoneNumbers = await _advisorPhoneNumberRepository.ListAsync(advisorPhoneNumberSpec);
            await _advisorPhoneNumberRepository.DeleteRangeAsync(advisorPhoneNumbers);
            var businessUnitPhoneNumberSpec =
                new GetBusinessUnitPhoneNumberWithPhoneNumberKeySpec(phoneNumber.PhoneNumberId);
            var businessUnitPhoneNumbers =
                await _businessUnitPhoneNumberRepository.ListAsync(businessUnitPhoneNumberSpec);
            await _businessUnitPhoneNumberRepository.DeleteRangeAsync(businessUnitPhoneNumbers);
            var customerPhoneNumberSpec = new GetCustomerPhoneNumberWithPhoneNumberKeySpec(phoneNumber.PhoneNumberId);
            var customerPhoneNumbers = await _customerPhoneNumberRepository.ListAsync(customerPhoneNumberSpec);
            await _customerPhoneNumberRepository.DeleteRangeAsync(customerPhoneNumbers);
            var employeePhoneNumberSpec = new GetEmployeePhoneNumberWithPhoneNumberKeySpec(phoneNumber.PhoneNumberId);
            var employeePhoneNumbers = await _employeePhoneNumberRepository.ListAsync(employeePhoneNumberSpec);
            await _employeePhoneNumberRepository.DeleteRangeAsync(employeePhoneNumbers);

            var phoneNumberDeletedEvent = new PhoneNumberDeletedEvent(phoneNumber, "Mongo-History");
            _messagePublisher.Publish(phoneNumberDeletedEvent);

            await _repository.DeleteAsync(phoneNumber);

            return Ok(response);
        }
    }
}