using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmailAddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteEmailAddressRequest>.WithActionResult<
        DeleteEmailAddressResponse>
    {
        private readonly IRepository<AdvisorEmailAddress> _advisorEmailAddressRepository;
        private readonly IRepository<BusinessUnitEmailAddress> _businessUnitEmailAddressRepository;
        private readonly IRepository<CustomerEmailAddress> _customerEmailAddressRepository;
        private readonly IRepository<EmailAddress> _emailAddressReadRepository;
        private readonly IRepository<EmployeeEmailAddress> _employeeEmailAddressRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmailAddress> _repository;

        public Delete(IRepository<EmailAddress> EmailAddressRepository,
            IRepository<EmailAddress> EmailAddressReadRepository,
            IRepository<AdvisorEmailAddress> advisorEmailAddressRepository,
            IRepository<BusinessUnitEmailAddress> businessUnitEmailAddressRepository,
            IRepository<CustomerEmailAddress> customerEmailAddressRepository,
            IRepository<EmployeeEmailAddress> employeeEmailAddressRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = EmailAddressRepository;
            _emailAddressReadRepository = EmailAddressReadRepository;
            _advisorEmailAddressRepository = advisorEmailAddressRepository;
            _businessUnitEmailAddressRepository = businessUnitEmailAddressRepository;
            _customerEmailAddressRepository = customerEmailAddressRepository;
            _employeeEmailAddressRepository = employeeEmailAddressRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/emailAddresses/{EmailAddressId}")]
        [SwaggerOperation(
            Summary = "Deletes an EmailAddress",
            Description = "Deletes an EmailAddress",
            OperationId = "emailAddresses.delete",
            Tags = new[] { "EmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteEmailAddressResponse>> HandleAsync(
            [FromRoute] DeleteEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteEmailAddressResponse(request.CorrelationId());

            var emailAddress = await _emailAddressReadRepository.GetByIdAsync(request.EmailAddressId);

            if (emailAddress == null)
            {
                return NotFound();
            }

            var advisorEmailAddressSpec =
                new GetAdvisorEmailAddressWithEmailAddressKeySpec(emailAddress.EmailAddressId);
            var advisorEmailAddresses = await _advisorEmailAddressRepository.ListAsync(advisorEmailAddressSpec);
            await _advisorEmailAddressRepository.DeleteRangeAsync(advisorEmailAddresses);
            var businessUnitEmailAddressSpec =
                new GetBusinessUnitEmailAddressWithEmailAddressKeySpec(emailAddress.EmailAddressId);
            var businessUnitEmailAddresses =
                await _businessUnitEmailAddressRepository.ListAsync(businessUnitEmailAddressSpec);
            await _businessUnitEmailAddressRepository.DeleteRangeAsync(businessUnitEmailAddresses);
            var customerEmailAddressSpec =
                new GetCustomerEmailAddressWithEmailAddressKeySpec(emailAddress.EmailAddressId);
            var customerEmailAddresses = await _customerEmailAddressRepository.ListAsync(customerEmailAddressSpec);
            await _customerEmailAddressRepository.DeleteRangeAsync(customerEmailAddresses);
            var employeeEmailAddressSpec =
                new GetEmployeeEmailAddressWithEmailAddressKeySpec(emailAddress.EmailAddressId);
            var employeeEmailAddresses = await _employeeEmailAddressRepository.ListAsync(employeeEmailAddressSpec);
            await _employeeEmailAddressRepository.DeleteRangeAsync(employeeEmailAddresses);

            var emailAddressDeletedEvent = new EmailAddressDeletedEvent(emailAddress, "Mongo-History");
            _messagePublisher.Publish(emailAddressDeletedEvent);

            await _repository.DeleteAsync(emailAddress);

            return Ok(response);
        }
    }
}