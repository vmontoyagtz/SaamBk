using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AddressTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAddressTypeRequest>.WithActionResult<
        DeleteAddressTypeResponse>
    {
        private readonly IRepository<AddressType> _addressTypeReadRepository;
        private readonly IRepository<AdvisorAddress> _advisorAddressRepository;
        private readonly IRepository<BusinessUnitAddress> _businessUnitAddressRepository;
        private readonly IRepository<CustomerAddress> _customerAddressRepository;
        private readonly IRepository<EmployeeAddress> _employeeAddressRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AddressType> _repository;

        public Delete(IRepository<AddressType> AddressTypeRepository,
            IRepository<AddressType> AddressTypeReadRepository,
            IRepository<AdvisorAddress> advisorAddressRepository,
            IRepository<BusinessUnitAddress> businessUnitAddressRepository,
            IRepository<CustomerAddress> customerAddressRepository,
            IRepository<EmployeeAddress> employeeAddressRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AddressTypeRepository;
            _addressTypeReadRepository = AddressTypeReadRepository;
            _advisorAddressRepository = advisorAddressRepository;
            _businessUnitAddressRepository = businessUnitAddressRepository;
            _customerAddressRepository = customerAddressRepository;
            _employeeAddressRepository = employeeAddressRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/addressTypes/{AddressTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an AddressType",
            Description = "Deletes an AddressType",
            OperationId = "addressTypes.delete",
            Tags = new[] { "AddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAddressTypeResponse>> HandleAsync(
            [FromRoute] DeleteAddressTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAddressTypeResponse(request.CorrelationId());

            var addressType = await _addressTypeReadRepository.GetByIdAsync(request.AddressTypeId);

            if (addressType == null)
            {
                return NotFound();
            }

            var advisorAddressSpec = new GetAdvisorAddressWithAddressTypeKeySpec(addressType.AddressTypeId);
            var advisorAddresses = await _advisorAddressRepository.ListAsync(advisorAddressSpec);
            await _advisorAddressRepository.DeleteRangeAsync(advisorAddresses);
            var businessUnitAddressSpec = new GetBusinessUnitAddressWithAddressTypeKeySpec(addressType.AddressTypeId);
            var businessUnitAddresses = await _businessUnitAddressRepository.ListAsync(businessUnitAddressSpec);
            await _businessUnitAddressRepository.DeleteRangeAsync(businessUnitAddresses);
            var customerAddressSpec = new GetCustomerAddressWithAddressTypeKeySpec(addressType.AddressTypeId);
            var customerAddresses = await _customerAddressRepository.ListAsync(customerAddressSpec);
            await _customerAddressRepository.DeleteRangeAsync(customerAddresses);
            var employeeAddressSpec = new GetEmployeeAddressWithAddressTypeKeySpec(addressType.AddressTypeId);
            var employeeAddresses = await _employeeAddressRepository.ListAsync(employeeAddressSpec);
            await _employeeAddressRepository.DeleteRangeAsync(employeeAddresses);

            var addressTypeDeletedEvent = new AddressTypeDeletedEvent(addressType, "Mongo-History");
            _messagePublisher.Publish(addressTypeDeletedEvent);

            await _repository.DeleteAsync(addressType);

            return Ok(response);
        }
    }
}