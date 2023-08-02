using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorLogin;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorLoginEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorLoginRequest>.WithActionResult<
        DeleteAdvisorLoginResponse>
    {
        private readonly IRepository<AdvisorLogin> _advisorLoginReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorLogin> _repository;

        public Delete(IRepository<AdvisorLogin> AdvisorLoginRepository,
            IRepository<AdvisorLogin> AdvisorLoginReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorLoginRepository;
            _advisorLoginReadRepository = AdvisorLoginReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorLogins/{AdvisorLoginId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorLogin",
            Description = "Deletes an AdvisorLogin",
            OperationId = "advisorLogins.delete",
            Tags = new[] { "AdvisorLoginEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorLoginResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorLoginRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorLoginResponse(request.CorrelationId());

            var advisorLogin = await _advisorLoginReadRepository.GetByIdAsync(request.AdvisorLoginId);

            if (advisorLogin == null)
            {
                return NotFound();
            }


            var advisorLoginDeletedEvent = new AdvisorLoginDeletedEvent(advisorLogin, "Mongo-History");
            _messagePublisher.Publish(advisorLoginDeletedEvent);

            await _repository.DeleteAsync(advisorLogin);

            return Ok(response);
        }
    }
}