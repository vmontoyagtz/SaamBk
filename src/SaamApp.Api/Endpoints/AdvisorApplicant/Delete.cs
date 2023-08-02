using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorApplicant;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorApplicantEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorApplicantRequest>.WithActionResult<
        DeleteAdvisorApplicantResponse>
    {
        private readonly IRepository<AdvisorApplicant> _advisorApplicantReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorApplicant> _repository;

        public Delete(IRepository<AdvisorApplicant> AdvisorApplicantRepository,
            IRepository<AdvisorApplicant> AdvisorApplicantReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorApplicantRepository;
            _advisorApplicantReadRepository = AdvisorApplicantReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorApplicants/{AdvisorApplicantId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorApplicant",
            Description = "Deletes an AdvisorApplicant",
            OperationId = "advisorApplicants.delete",
            Tags = new[] { "AdvisorApplicantEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorApplicantResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorApplicantRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorApplicantResponse(request.CorrelationId());

            var advisorApplicant = await _advisorApplicantReadRepository.GetByIdAsync(request.AdvisorApplicantId);

            if (advisorApplicant == null)
            {
                return NotFound();
            }


            var advisorApplicantDeletedEvent = new AdvisorApplicantDeletedEvent(advisorApplicant, "Mongo-History");
            _messagePublisher.Publish(advisorApplicantDeletedEvent);

            await _repository.DeleteAsync(advisorApplicant);

            return Ok(response);
        }
    }
}