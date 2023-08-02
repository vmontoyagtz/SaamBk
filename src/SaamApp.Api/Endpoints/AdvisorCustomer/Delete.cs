using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorCustomer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorCustomerEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorCustomerRequest>.WithActionResult<
        DeleteAdvisorCustomerResponse>
    {
        private readonly IRepository<AdvisorCustomer> _advisorCustomerReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorCustomer> _repository;

        public Delete(IRepository<AdvisorCustomer> AdvisorCustomerRepository,
            IRepository<AdvisorCustomer> AdvisorCustomerReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorCustomerRepository;
            _advisorCustomerReadRepository = AdvisorCustomerReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorCustomers/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorCustomer",
            Description = "Deletes an AdvisorCustomer",
            OperationId = "advisorCustomers.delete",
            Tags = new[] { "AdvisorCustomerEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorCustomerResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorCustomerResponse(request.CorrelationId());

            var advisorCustomer = await _advisorCustomerReadRepository.GetByIdAsync(request.RowId);

            if (advisorCustomer == null)
            {
                return NotFound();
            }


            var advisorCustomerDeletedEvent = new AdvisorCustomerDeletedEvent(advisorCustomer, "Mongo-History");
            _messagePublisher.Publish(advisorCustomerDeletedEvent);

            await _repository.DeleteAsync(advisorCustomer);

            return Ok(response);
        }
    }
}