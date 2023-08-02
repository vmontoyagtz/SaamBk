using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorLogin;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorLoginEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorLoginRequest>.WithActionResult<
        UpdateAdvisorLoginResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorLogin> _repository;

        public Update(
            IRepository<AdvisorLogin> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorLogins")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorLogin",
            Description = "Updates a AdvisorLogin",
            OperationId = "advisorLogins.update",
            Tags = new[] { "AdvisorLoginEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorLoginResponse>> HandleAsync(
            UpdateAdvisorLoginRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorLoginResponse(request.CorrelationId());

            var aldlvlToUpdate = _mapper.Map<AdvisorLogin>(request);

            var advisorLoginToUpdateTest = await _repository.GetByIdAsync(request.AdvisorLoginId);
            if (advisorLoginToUpdateTest is null)
            {
                return NotFound();
            }

            aldlvlToUpdate.UpdateAdvisorForAdvisorLogin(request.AdvisorId);
            await _repository.UpdateAsync(aldlvlToUpdate);

            var advisorLoginUpdatedEvent = new AdvisorLoginUpdatedEvent(aldlvlToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorLoginUpdatedEvent);

            var dto = _mapper.Map<AdvisorLoginDto>(aldlvlToUpdate);
            response.AdvisorLogin = dto;

            return Ok(response);
        }
    }
}