using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AiFeedbackEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAiFeedbackRequest>.WithActionResult<
        UpdateAiFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiFeedback> _repository;

        public Update(
            IRepository<AiFeedback> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/aiFeedbacks")]
        [SwaggerOperation(
            Summary = "Updates a AiFeedback",
            Description = "Updates a AiFeedback",
            OperationId = "aiFeedbacks.update",
            Tags = new[] { "AiFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAiFeedbackResponse>> HandleAsync(UpdateAiFeedbackRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAiFeedbackResponse(request.CorrelationId());

            var afiffToUpdate = _mapper.Map<AiFeedback>(request);

            var aiFeedbackToUpdateTest = await _repository.GetByIdAsync(request.AiFeedbackId);
            if (aiFeedbackToUpdateTest is null)
            {
                return NotFound();
            }

            afiffToUpdate.UpdateCustomerForAiFeedback(request.CustomerId);
            await _repository.UpdateAsync(afiffToUpdate);

            var aiFeedbackUpdatedEvent = new AiFeedbackUpdatedEvent(afiffToUpdate, "Mongo-History");
            _messagePublisher.Publish(aiFeedbackUpdatedEvent);

            var dto = _mapper.Map<AiFeedbackDto>(afiffToUpdate);
            response.AiFeedback = dto;

            return Ok(response);
        }
    }
}