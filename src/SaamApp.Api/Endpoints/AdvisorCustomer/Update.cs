using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorCustomer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorCustomerEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorCustomerRequest>.WithActionResult<
        UpdateAdvisorCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorCustomer> _repository;

        public Update(
            IRepository<AdvisorCustomer> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorCustomers")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorCustomer",
            Description = "Updates a AdvisorCustomer",
            OperationId = "advisorCustomers.update",
            Tags = new[] { "AdvisorCustomerEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorCustomerResponse>> HandleAsync(
            UpdateAdvisorCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorCustomerResponse(request.CorrelationId());

            var acdcvcToUpdate = _mapper.Map<AdvisorCustomer>(request);

            var advisorCustomerToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (advisorCustomerToUpdateTest is null)
            {
                return NotFound();
            }

            acdcvcToUpdate.UpdateAdvisorForAdvisorCustomer(request.AdvisorId);
            acdcvcToUpdate.UpdateCustomerForAdvisorCustomer(request.CustomerId);
            await _repository.UpdateAsync(acdcvcToUpdate);

            var advisorCustomerUpdatedEvent = new AdvisorCustomerUpdatedEvent(acdcvcToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorCustomerUpdatedEvent);

            var dto = _mapper.Map<AdvisorCustomerDto>(acdcvcToUpdate);
            response.AdvisorCustomer = dto;

            return Ok(response);
        }
    }
}