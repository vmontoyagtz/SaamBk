using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitPhoneNumberEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteBusinessUnitPhoneNumberRequest>.WithActionResult<
        DeleteBusinessUnitPhoneNumberResponse>
    {
        private readonly IRepository<BusinessUnitPhoneNumber> _businessUnitPhoneNumberReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitPhoneNumber> _repository;

        public Delete(IRepository<BusinessUnitPhoneNumber> BusinessUnitPhoneNumberRepository,
            IRepository<BusinessUnitPhoneNumber> BusinessUnitPhoneNumberReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = BusinessUnitPhoneNumberRepository;
            _businessUnitPhoneNumberReadRepository = BusinessUnitPhoneNumberReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/businessUnitPhoneNumbers/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an BusinessUnitPhoneNumber",
            Description = "Deletes an BusinessUnitPhoneNumber",
            OperationId = "businessUnitPhoneNumbers.delete",
            Tags = new[] { "BusinessUnitPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<DeleteBusinessUnitPhoneNumberResponse>> HandleAsync(
            [FromRoute] DeleteBusinessUnitPhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBusinessUnitPhoneNumberResponse(request.CorrelationId());

            var businessUnitPhoneNumber = await _businessUnitPhoneNumberReadRepository.GetByIdAsync(request.RowId);

            if (businessUnitPhoneNumber == null)
            {
                return NotFound();
            }


            var businessUnitPhoneNumberDeletedEvent =
                new BusinessUnitPhoneNumberDeletedEvent(businessUnitPhoneNumber, "Mongo-History");
            _messagePublisher.Publish(businessUnitPhoneNumberDeletedEvent);

            await _repository.DeleteAsync(businessUnitPhoneNumber);

            return Ok(response);
        }
    }
}