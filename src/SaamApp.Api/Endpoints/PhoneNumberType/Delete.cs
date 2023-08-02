using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PhoneNumberType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PhoneNumberTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeletePhoneNumberTypeRequest>.WithActionResult<
        DeletePhoneNumberTypeResponse>
    {
        private readonly IRepository<AdvisorPhoneNumber> _advisorPhoneNumberRepository;
        private readonly IRepository<BusinessUnitPhoneNumber> _businessUnitPhoneNumberRepository;
        private readonly IRepository<CustomerPhoneNumber> _customerPhoneNumberRepository;
        private readonly IRepository<EmployeePhoneNumber> _employeePhoneNumberRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PhoneNumberType> _phoneNumberTypeReadRepository;
        private readonly IRepository<PhoneNumberType> _repository;

        public Delete(IRepository<PhoneNumberType> PhoneNumberTypeRepository,
            IRepository<PhoneNumberType> PhoneNumberTypeReadRepository,
            IRepository<AdvisorPhoneNumber> advisorPhoneNumberRepository,
            IRepository<BusinessUnitPhoneNumber> businessUnitPhoneNumberRepository,
            IRepository<CustomerPhoneNumber> customerPhoneNumberRepository,
            IRepository<EmployeePhoneNumber> employeePhoneNumberRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = PhoneNumberTypeRepository;
            _phoneNumberTypeReadRepository = PhoneNumberTypeReadRepository;
            _advisorPhoneNumberRepository = advisorPhoneNumberRepository;
            _businessUnitPhoneNumberRepository = businessUnitPhoneNumberRepository;
            _customerPhoneNumberRepository = customerPhoneNumberRepository;
            _employeePhoneNumberRepository = employeePhoneNumberRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/phoneNumberTypes/{PhoneNumberTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an PhoneNumberType",
            Description = "Deletes an PhoneNumberType",
            OperationId = "phoneNumberTypes.delete",
            Tags = new[] { "PhoneNumberTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeletePhoneNumberTypeResponse>> HandleAsync(
            [FromRoute] DeletePhoneNumberTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePhoneNumberTypeResponse(request.CorrelationId());

            var phoneNumberType = await _phoneNumberTypeReadRepository.GetByIdAsync(request.PhoneNumberTypeId);

            if (phoneNumberType == null)
            {
                return NotFound();
            }

            var advisorPhoneNumberSpec =
                new GetAdvisorPhoneNumberWithPhoneNumberTypeKeySpec(phoneNumberType.PhoneNumberTypeId);
            var advisorPhoneNumbers = await _advisorPhoneNumberRepository.ListAsync(advisorPhoneNumberSpec);
            await _advisorPhoneNumberRepository.DeleteRangeAsync(advisorPhoneNumbers);
            var businessUnitPhoneNumberSpec =
                new GetBusinessUnitPhoneNumberWithPhoneNumberTypeKeySpec(phoneNumberType.PhoneNumberTypeId);
            var businessUnitPhoneNumbers =
                await _businessUnitPhoneNumberRepository.ListAsync(businessUnitPhoneNumberSpec);
            await _businessUnitPhoneNumberRepository.DeleteRangeAsync(businessUnitPhoneNumbers);
            var customerPhoneNumberSpec =
                new GetCustomerPhoneNumberWithPhoneNumberTypeKeySpec(phoneNumberType.PhoneNumberTypeId);
            var customerPhoneNumbers = await _customerPhoneNumberRepository.ListAsync(customerPhoneNumberSpec);
            await _customerPhoneNumberRepository.DeleteRangeAsync(customerPhoneNumbers);
            var employeePhoneNumberSpec =
                new GetEmployeePhoneNumberWithPhoneNumberTypeKeySpec(phoneNumberType.PhoneNumberTypeId);
            var employeePhoneNumbers = await _employeePhoneNumberRepository.ListAsync(employeePhoneNumberSpec);
            await _employeePhoneNumberRepository.DeleteRangeAsync(employeePhoneNumbers);

            var phoneNumberTypeDeletedEvent = new PhoneNumberTypeDeletedEvent(phoneNumberType, "Mongo-History");
            _messagePublisher.Publish(phoneNumberTypeDeletedEvent);

            await _repository.DeleteAsync(phoneNumberType);

            return Ok(response);
        }
    }
}