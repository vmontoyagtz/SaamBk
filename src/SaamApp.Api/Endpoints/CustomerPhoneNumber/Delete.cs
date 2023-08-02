using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPhoneNumberEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerPhoneNumberRequest>.WithActionResult<
        DeleteCustomerPhoneNumberResponse>
    {
        private readonly IRepository<CustomerPhoneNumber> _customerPhoneNumberReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerPhoneNumber> _repository;

        public Delete(IRepository<CustomerPhoneNumber> CustomerPhoneNumberRepository,
            IRepository<CustomerPhoneNumber> CustomerPhoneNumberReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerPhoneNumberRepository;
            _customerPhoneNumberReadRepository = CustomerPhoneNumberReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerPhoneNumbers/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerPhoneNumber",
            Description = "Deletes an CustomerPhoneNumber",
            OperationId = "customerPhoneNumbers.delete",
            Tags = new[] { "CustomerPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerPhoneNumberResponse>> HandleAsync(
            [FromRoute] DeleteCustomerPhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerPhoneNumberResponse(request.CorrelationId());

            var customerPhoneNumber = await _customerPhoneNumberReadRepository.GetByIdAsync(request.RowId);

            if (customerPhoneNumber == null)
            {
                return NotFound();
            }


            var customerPhoneNumberDeletedEvent =
                new CustomerPhoneNumberDeletedEvent(customerPhoneNumber, "Mongo-History");
            _messagePublisher.Publish(customerPhoneNumberDeletedEvent);

            await _repository.DeleteAsync(customerPhoneNumber);

            return Ok(response);
        }
    }
}