using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmailAddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmailAddressTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteEmailAddressTypeRequest>.WithActionResult<
        DeleteEmailAddressTypeResponse>
    {
        private readonly IRepository<AdvisorEmailAddress> _advisorEmailAddressRepository;
        private readonly IRepository<BusinessUnitEmailAddress> _businessUnitEmailAddressRepository;
        private readonly IRepository<CustomerEmailAddress> _customerEmailAddressRepository;
        private readonly IRepository<EmailAddressType> _emailAddressTypeReadRepository;
        private readonly IRepository<EmployeeEmailAddress> _employeeEmailAddressRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmailAddressType> _repository;

        public Delete(IRepository<EmailAddressType> EmailAddressTypeRepository,
            IRepository<EmailAddressType> EmailAddressTypeReadRepository,
            IRepository<AdvisorEmailAddress> advisorEmailAddressRepository,
            IRepository<BusinessUnitEmailAddress> businessUnitEmailAddressRepository,
            IRepository<CustomerEmailAddress> customerEmailAddressRepository,
            IRepository<EmployeeEmailAddress> employeeEmailAddressRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = EmailAddressTypeRepository;
            _emailAddressTypeReadRepository = EmailAddressTypeReadRepository;
            _advisorEmailAddressRepository = advisorEmailAddressRepository;
            _businessUnitEmailAddressRepository = businessUnitEmailAddressRepository;
            _customerEmailAddressRepository = customerEmailAddressRepository;
            _employeeEmailAddressRepository = employeeEmailAddressRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/emailAddressTypes/{EmailAddressTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an EmailAddressType",
            Description = "Deletes an EmailAddressType",
            OperationId = "emailAddressTypes.delete",
            Tags = new[] { "EmailAddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteEmailAddressTypeResponse>> HandleAsync(
            [FromRoute] DeleteEmailAddressTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteEmailAddressTypeResponse(request.CorrelationId());

            var emailAddressType = await _emailAddressTypeReadRepository.GetByIdAsync(request.EmailAddressTypeId);

            if (emailAddressType == null)
            {
                return NotFound();
            }

            var advisorEmailAddressSpec =
                new GetAdvisorEmailAddressWithEmailAddressTypeKeySpec(emailAddressType.EmailAddressTypeId);
            var advisorEmailAddresses = await _advisorEmailAddressRepository.ListAsync(advisorEmailAddressSpec);
            await _advisorEmailAddressRepository.DeleteRangeAsync(advisorEmailAddresses);
            var businessUnitEmailAddressSpec =
                new GetBusinessUnitEmailAddressWithEmailAddressTypeKeySpec(emailAddressType.EmailAddressTypeId);
            var businessUnitEmailAddresses =
                await _businessUnitEmailAddressRepository.ListAsync(businessUnitEmailAddressSpec);
            await _businessUnitEmailAddressRepository.DeleteRangeAsync(businessUnitEmailAddresses);
            var customerEmailAddressSpec =
                new GetCustomerEmailAddressWithEmailAddressTypeKeySpec(emailAddressType.EmailAddressTypeId);
            var customerEmailAddresses = await _customerEmailAddressRepository.ListAsync(customerEmailAddressSpec);
            await _customerEmailAddressRepository.DeleteRangeAsync(customerEmailAddresses);
            var employeeEmailAddressSpec =
                new GetEmployeeEmailAddressWithEmailAddressTypeKeySpec(emailAddressType.EmailAddressTypeId);
            var employeeEmailAddresses = await _employeeEmailAddressRepository.ListAsync(employeeEmailAddressSpec);
            await _employeeEmailAddressRepository.DeleteRangeAsync(employeeEmailAddresses);

            var emailAddressTypeDeletedEvent = new EmailAddressTypeDeletedEvent(emailAddressType, "Mongo-History");
            _messagePublisher.Publish(emailAddressTypeDeletedEvent);

            await _repository.DeleteAsync(emailAddressType);

            return Ok(response);
        }
    }
}