using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorBank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorBankEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorBankRequest>.WithActionResult<
        DeleteAdvisorBankResponse>
    {
        private readonly IRepository<AdvisorBank> _advisorBankReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorBank> _repository;

        public Delete(IRepository<AdvisorBank> AdvisorBankRepository,
            IRepository<AdvisorBank> AdvisorBankReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorBankRepository;
            _advisorBankReadRepository = AdvisorBankReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorBanks/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorBank",
            Description = "Deletes an AdvisorBank",
            OperationId = "advisorBanks.delete",
            Tags = new[] { "AdvisorBankEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorBankResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorBankRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorBankResponse(request.CorrelationId());

            var advisorBank = await _advisorBankReadRepository.GetByIdAsync(request.RowId);

            if (advisorBank == null)
            {
                return NotFound();
            }


            var advisorBankDeletedEvent = new AdvisorBankDeletedEvent(advisorBank, "Mongo-History");
            _messagePublisher.Publish(advisorBankDeletedEvent);

            await _repository.DeleteAsync(advisorBank);

            return Ok(response);
        }
    }
}