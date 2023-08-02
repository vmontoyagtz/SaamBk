using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Gender;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.GenderEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateGenderRequest>.WithActionResult<UpdateGenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Gender> _repository;

        public Update(
            IRepository<Gender> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/genders")]
        [SwaggerOperation(
            Summary = "Updates a Gender",
            Description = "Updates a Gender",
            OperationId = "genders.update",
            Tags = new[] { "GenderEndpoints" })
        ]
        public override async Task<ActionResult<UpdateGenderResponse>> HandleAsync(UpdateGenderRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateGenderResponse(request.CorrelationId());

            var genToUpdate = _mapper.Map<Gender>(request);

            var genderToUpdateTest = await _repository.GetByIdAsync(request.GenderId);
            if (genderToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(genToUpdate);

            var genderUpdatedEvent = new GenderUpdatedEvent(genToUpdate, "Mongo-History");
            _messagePublisher.Publish(genderUpdatedEvent);

            var dto = _mapper.Map<GenderDto>(genToUpdate);
            response.Gender = dto;

            return Ok(response);
        }
    }
}