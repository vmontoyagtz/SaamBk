using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Faq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.FaqEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteFaqRequest>.WithActionResult<
        DeleteFaqResponse>
    {
        private readonly IRepository<Faq> _faqReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Faq> _repository;

        public Delete(IRepository<Faq> FaqRepository, IRepository<Faq> FaqReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = FaqRepository;
            _faqReadRepository = FaqReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/faqs/{FaqId}")]
        [SwaggerOperation(
            Summary = "Deletes an Faq",
            Description = "Deletes an Faq",
            OperationId = "faqs.delete",
            Tags = new[] { "FaqEndpoints" })
        ]
        public override async Task<ActionResult<DeleteFaqResponse>> HandleAsync(
            [FromRoute] DeleteFaqRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteFaqResponse(request.CorrelationId());

            var faq = await _faqReadRepository.GetByIdAsync(request.FaqId);

            if (faq == null)
            {
                return NotFound();
            }


            var faqDeletedEvent = new FaqDeletedEvent(faq, "Mongo-History");
            _messagePublisher.Publish(faqDeletedEvent);

            await _repository.DeleteAsync(faq);

            return Ok(response);
        }
    }
}