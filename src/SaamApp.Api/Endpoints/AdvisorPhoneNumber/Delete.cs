using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorPhoneNumberEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorPhoneNumberRequest>.WithActionResult<
        DeleteAdvisorPhoneNumberResponse>
    {
        private readonly IRepository<AdvisorPhoneNumber> _advisorPhoneNumberReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorPhoneNumber> _repository;

        public Delete(IRepository<AdvisorPhoneNumber> AdvisorPhoneNumberRepository,
            IRepository<AdvisorPhoneNumber> AdvisorPhoneNumberReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorPhoneNumberRepository;
            _advisorPhoneNumberReadRepository = AdvisorPhoneNumberReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorPhoneNumbers/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorPhoneNumber",
            Description = "Deletes an AdvisorPhoneNumber",
            OperationId = "advisorPhoneNumbers.delete",
            Tags = new[] { "AdvisorPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorPhoneNumberResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorPhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorPhoneNumberResponse(request.CorrelationId());

            var advisorPhoneNumber = await _advisorPhoneNumberReadRepository.GetByIdAsync(request.RowId);

            if (advisorPhoneNumber == null)
            {
                return NotFound();
            }


            var advisorPhoneNumberDeletedEvent =
                new AdvisorPhoneNumberDeletedEvent(advisorPhoneNumber, "Mongo-History");
            _messagePublisher.Publish(advisorPhoneNumberDeletedEvent);

            await _repository.DeleteAsync(advisorPhoneNumber);

            return Ok(response);
        }
    }
}