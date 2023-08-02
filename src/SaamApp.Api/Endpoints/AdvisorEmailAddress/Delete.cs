using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorEmailAddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorEmailAddressRequest>.WithActionResult<
        DeleteAdvisorEmailAddressResponse>
    {
        private readonly IRepository<AdvisorEmailAddress> _advisorEmailAddressReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorEmailAddress> _repository;

        public Delete(IRepository<AdvisorEmailAddress> AdvisorEmailAddressRepository,
            IRepository<AdvisorEmailAddress> AdvisorEmailAddressReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorEmailAddressRepository;
            _advisorEmailAddressReadRepository = AdvisorEmailAddressReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorEmailAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorEmailAddress",
            Description = "Deletes an AdvisorEmailAddress",
            OperationId = "advisorEmailAddresses.delete",
            Tags = new[] { "AdvisorEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorEmailAddressResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorEmailAddressResponse(request.CorrelationId());

            var advisorEmailAddress = await _advisorEmailAddressReadRepository.GetByIdAsync(request.RowId);

            if (advisorEmailAddress == null)
            {
                return NotFound();
            }


            var advisorEmailAddressDeletedEvent =
                new AdvisorEmailAddressDeletedEvent(advisorEmailAddress, "Mongo-History");
            _messagePublisher.Publish(advisorEmailAddressDeletedEvent);

            await _repository.DeleteAsync(advisorEmailAddress);

            return Ok(response);
        }
    }
}