using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorPhoneNumberEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorPhoneNumberRequest>.WithActionResult<
        UpdateAdvisorPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorPhoneNumber> _repository;

        public Update(
            IRepository<AdvisorPhoneNumber> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorPhoneNumbers")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorPhoneNumber",
            Description = "Updates a AdvisorPhoneNumber",
            OperationId = "advisorPhoneNumbers.update",
            Tags = new[] { "AdvisorPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorPhoneNumberResponse>> HandleAsync(
            UpdateAdvisorPhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorPhoneNumberResponse(request.CorrelationId());

            var apndpnvpnToUpdate = _mapper.Map<AdvisorPhoneNumber>(request);

            var advisorPhoneNumberToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (advisorPhoneNumberToUpdateTest is null)
            {
                return NotFound();
            }

            apndpnvpnToUpdate.UpdateAdvisorForAdvisorPhoneNumber(request.AdvisorId);
            apndpnvpnToUpdate.UpdatePhoneNumberForAdvisorPhoneNumber(request.PhoneNumberId);
            apndpnvpnToUpdate.UpdatePhoneNumberTypeForAdvisorPhoneNumber(request.PhoneNumberTypeId);
            await _repository.UpdateAsync(apndpnvpnToUpdate);

            var advisorPhoneNumberUpdatedEvent = new AdvisorPhoneNumberUpdatedEvent(apndpnvpnToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorPhoneNumberUpdatedEvent);

            var dto = _mapper.Map<AdvisorPhoneNumberDto>(apndpnvpnToUpdate);
            response.AdvisorPhoneNumber = dto;

            return Ok(response);
        }
    }
}