using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Address;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAddressRequest>.WithActionResult<
        DeleteAddressResponse>
    {
        private readonly IRepository<Address> _addressReadRepository;
        private readonly IRepository<AdvisorAddress> _advisorAddressRepository;
        private readonly IRepository<BusinessUnitAddress> _businessUnitAddressRepository;
        private readonly IRepository<CustomerAddress> _customerAddressRepository;
        private readonly IRepository<EmployeeAddress> _employeeAddressRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Address> _repository;

        public Delete(IRepository<Address> AddressRepository, IRepository<Address> AddressReadRepository,
            IRepository<AdvisorAddress> advisorAddressRepository,
            IRepository<BusinessUnitAddress> businessUnitAddressRepository,
            IRepository<CustomerAddress> customerAddressRepository,
            IRepository<EmployeeAddress> employeeAddressRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AddressRepository;
            _addressReadRepository = AddressReadRepository;
            _advisorAddressRepository = advisorAddressRepository;
            _businessUnitAddressRepository = businessUnitAddressRepository;
            _customerAddressRepository = customerAddressRepository;
            _employeeAddressRepository = employeeAddressRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/addresses/{AddressId}")]
        [SwaggerOperation(
            Summary = "Deletes an Address",
            Description = "Deletes an Address",
            OperationId = "addresses.delete",
            Tags = new[] { "AddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAddressResponse>> HandleAsync(
            [FromRoute] DeleteAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAddressResponse(request.CorrelationId());

            var address = await _addressReadRepository.GetByIdAsync(request.AddressId);

            if (address == null)
            {
                return NotFound();
            }

            var advisorAddressSpec = new GetAdvisorAddressWithAddressKeySpec(address.AddressId);
            var advisorAddresses = await _advisorAddressRepository.ListAsync(advisorAddressSpec);
            await _advisorAddressRepository.DeleteRangeAsync(advisorAddresses);
            var businessUnitAddressSpec = new GetBusinessUnitAddressWithAddressKeySpec(address.AddressId);
            var businessUnitAddresses = await _businessUnitAddressRepository.ListAsync(businessUnitAddressSpec);
            await _businessUnitAddressRepository.DeleteRangeAsync(businessUnitAddresses);
            var customerAddressSpec = new GetCustomerAddressWithAddressKeySpec(address.AddressId);
            var customerAddresses = await _customerAddressRepository.ListAsync(customerAddressSpec);
            await _customerAddressRepository.DeleteRangeAsync(customerAddresses);
            var employeeAddressSpec = new GetEmployeeAddressWithAddressKeySpec(address.AddressId);
            var employeeAddresses = await _employeeAddressRepository.ListAsync(employeeAddressSpec);
            await _employeeAddressRepository.DeleteRangeAsync(employeeAddresses);

            var addressDeletedEvent = new AddressDeletedEvent(address, "Mongo-History");
            _messagePublisher.Publish(addressDeletedEvent);

            await _repository.DeleteAsync(address);

            return Ok(response);
        }
    }
}