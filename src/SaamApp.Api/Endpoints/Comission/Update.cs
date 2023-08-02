using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Comission;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.ComissionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateComissionRequest>.WithActionResult<
        UpdateComissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Comission> _repository;

        public Update(
            IRepository<Comission> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/comissions")]
        [SwaggerOperation(
            Summary = "Updates a Comission",
            Description = "Updates a Comission",
            OperationId = "comissions.update",
            Tags = new[] { "ComissionEndpoints" })
        ]
        public override async Task<ActionResult<UpdateComissionResponse>> HandleAsync(UpdateComissionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateComissionResponse(request.CorrelationId());

            var comToUpdate = _mapper.Map<Comission>(request);

            var comissionToUpdateTest = await _repository.GetByIdAsync(request.ComissionId);
            if (comissionToUpdateTest is null)
            {
                return NotFound();
            }

            comToUpdate.UpdateRegionAreaAdvisorCategoryForComission(request.RegionAreaAdvisorCategoryId);
            await _repository.UpdateAsync(comToUpdate);

            var comissionUpdatedEvent = new ComissionUpdatedEvent(comToUpdate, "Mongo-History");
            _messagePublisher.Publish(comissionUpdatedEvent);

            var dto = _mapper.Map<ComissionDto>(comToUpdate);
            response.Comission = dto;

            return Ok(response);
        }
    }
}