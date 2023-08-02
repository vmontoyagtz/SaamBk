using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorApplicant;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorApplicantEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorApplicantRequest>.WithActionResult<
        UpdateAdvisorApplicantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorApplicant> _repository;

        public Update(
            IRepository<AdvisorApplicant> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorApplicants")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorApplicant",
            Description = "Updates a AdvisorApplicant",
            OperationId = "advisorApplicants.update",
            Tags = new[] { "AdvisorApplicantEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorApplicantResponse>> HandleAsync(
            UpdateAdvisorApplicantRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorApplicantResponse(request.CorrelationId());

            var aadavaToUpdate = _mapper.Map<AdvisorApplicant>(request);

            var advisorApplicantToUpdateTest = await _repository.GetByIdAsync(request.AdvisorApplicantId);
            if (advisorApplicantToUpdateTest is null)
            {
                return NotFound();
            }

            aadavaToUpdate.UpdateRegionAreaAdvisorCategoryForAdvisorApplicant(request.RegionAreaAdvisorCategoryId);
            await _repository.UpdateAsync(aadavaToUpdate);

            var advisorApplicantUpdatedEvent = new AdvisorApplicantUpdatedEvent(aadavaToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorApplicantUpdatedEvent);

            var dto = _mapper.Map<AdvisorApplicantDto>(aadavaToUpdate);
            response.AdvisorApplicant = dto;

            return Ok(response);
        }
    }
}