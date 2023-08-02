using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.BusinessUnitPhoneNumberEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateBusinessUnitPhoneNumberRequest>.WithActionResult<
        UpdateBusinessUnitPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitPhoneNumber> _repository;

        public Update(
            IRepository<BusinessUnitPhoneNumber> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/businessUnitPhoneNumbers")]
        [SwaggerOperation(
            Summary = "Updates a BusinessUnitPhoneNumber",
            Description = "Updates a BusinessUnitPhoneNumber",
            OperationId = "businessUnitPhoneNumbers.update",
            Tags = new[] { "BusinessUnitPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<UpdateBusinessUnitPhoneNumberResponse>> HandleAsync(
            UpdateBusinessUnitPhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateBusinessUnitPhoneNumberResponse(request.CorrelationId());

            var bupnuupnsupnToUpdate = _mapper.Map<BusinessUnitPhoneNumber>(request);

            var businessUnitPhoneNumberToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitPhoneNumberToUpdateTest is null)
            {
                return NotFound();
            }

            bupnuupnsupnToUpdate.UpdateBusinessUnitForBusinessUnitPhoneNumber(request.BusinessUnitId);
            bupnuupnsupnToUpdate.UpdatePhoneNumberForBusinessUnitPhoneNumber(request.PhoneNumberId);
            bupnuupnsupnToUpdate.UpdatePhoneNumberTypeForBusinessUnitPhoneNumber(request.PhoneNumberTypeId);
            await _repository.UpdateAsync(bupnuupnsupnToUpdate);

            var businessUnitPhoneNumberUpdatedEvent =
                new BusinessUnitPhoneNumberUpdatedEvent(bupnuupnsupnToUpdate, "Mongo-History");
            _messagePublisher.Publish(businessUnitPhoneNumberUpdatedEvent);

            var dto = _mapper.Map<BusinessUnitPhoneNumberDto>(bupnuupnsupnToUpdate);
            response.BusinessUnitPhoneNumber = dto;

            return Ok(response);
        }
    }
}