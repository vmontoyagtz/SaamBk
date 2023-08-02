using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorAddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorAddressRequest>.WithActionResult<
        DeleteAdvisorAddressResponse>
    {
        private readonly IRepository<AdvisorAddress> _advisorAddressReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorAddress> _repository;

        public Delete(IRepository<AdvisorAddress> AdvisorAddressRepository,
            IRepository<AdvisorAddress> AdvisorAddressReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorAddressRepository;
            _advisorAddressReadRepository = AdvisorAddressReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorAddress",
            Description = "Deletes an AdvisorAddress",
            OperationId = "advisorAddresses.delete",
            Tags = new[] { "AdvisorAddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorAddressResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorAddressResponse(request.CorrelationId());

            var advisorAddress = await _advisorAddressReadRepository.GetByIdAsync(request.RowId);

            if (advisorAddress == null)
            {
                return NotFound();
            }


            var advisorAddressDeletedEvent = new AdvisorAddressDeletedEvent(advisorAddress, "Mongo-History");
            _messagePublisher.Publish(advisorAddressDeletedEvent);

            await _repository.DeleteAsync(advisorAddress);

            return Ok(response);
        }
    }
}