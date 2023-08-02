using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorBankTransferInfoEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorBankTransferInfoRequest>.WithActionResult<
        DeleteAdvisorBankTransferInfoResponse>
    {
        private readonly IRepository<AdvisorBankTransferInfo> _advisorBankTransferInfoReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorBankTransferInfo> _repository;

        public Delete(IRepository<AdvisorBankTransferInfo> AdvisorBankTransferInfoRepository,
            IRepository<AdvisorBankTransferInfo> AdvisorBankTransferInfoReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorBankTransferInfoRepository;
            _advisorBankTransferInfoReadRepository = AdvisorBankTransferInfoReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorBankTransferInfoes/{AdvisorBankTransferInfoId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorBankTransferInfo",
            Description = "Deletes an AdvisorBankTransferInfo",
            OperationId = "advisorBankTransferInfoes.delete",
            Tags = new[] { "AdvisorBankTransferInfoEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorBankTransferInfoResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorBankTransferInfoRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorBankTransferInfoResponse(request.CorrelationId());

            var advisorBankTransferInfo =
                await _advisorBankTransferInfoReadRepository.GetByIdAsync(request.AdvisorBankTransferInfoId);

            if (advisorBankTransferInfo == null)
            {
                return NotFound();
            }


            var advisorBankTransferInfoDeletedEvent =
                new AdvisorBankTransferInfoDeletedEvent(advisorBankTransferInfo, "Mongo-History");
            _messagePublisher.Publish(advisorBankTransferInfoDeletedEvent);

            await _repository.DeleteAsync(advisorBankTransferInfo);

            return Ok(response);
        }
    }
}