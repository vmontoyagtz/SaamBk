using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerPhoneNumberEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerPhoneNumberRequest>.WithActionResult<
        UpdateCustomerPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerPhoneNumber> _repository;

        public Update(
            IRepository<CustomerPhoneNumber> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerPhoneNumbers")]
        [SwaggerOperation(
            Summary = "Updates a CustomerPhoneNumber",
            Description = "Updates a CustomerPhoneNumber",
            OperationId = "customerPhoneNumbers.update",
            Tags = new[] { "CustomerPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerPhoneNumberResponse>> HandleAsync(
            UpdateCustomerPhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerPhoneNumberResponse(request.CorrelationId());

            var cpnupnspnToUpdate = _mapper.Map<CustomerPhoneNumber>(request);

            var customerPhoneNumberToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (customerPhoneNumberToUpdateTest is null)
            {
                return NotFound();
            }

            cpnupnspnToUpdate.UpdateCustomerForCustomerPhoneNumber(request.CustomerId);
            cpnupnspnToUpdate.UpdatePhoneNumberForCustomerPhoneNumber(request.PhoneNumberId);
            cpnupnspnToUpdate.UpdatePhoneNumberTypeForCustomerPhoneNumber(request.PhoneNumberTypeId);
            await _repository.UpdateAsync(cpnupnspnToUpdate);

            var customerPhoneNumberUpdatedEvent =
                new CustomerPhoneNumberUpdatedEvent(cpnupnspnToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerPhoneNumberUpdatedEvent);

            var dto = _mapper.Map<CustomerPhoneNumberDto>(cpnupnspnToUpdate);
            response.CustomerPhoneNumber = dto;

            return Ok(response);
        }
    }
}