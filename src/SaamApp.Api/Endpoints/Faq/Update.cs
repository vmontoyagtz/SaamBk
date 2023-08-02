using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Faq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.FaqEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateFaqRequest>.WithActionResult<UpdateFaqResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Faq> _repository;

        public Update(
            IRepository<Faq> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/faqs")]
        [SwaggerOperation(
            Summary = "Updates a Faq",
            Description = "Updates a Faq",
            OperationId = "faqs.update",
            Tags = new[] { "FaqEndpoints" })
        ]
        public override async Task<ActionResult<UpdateFaqResponse>> HandleAsync(UpdateFaqRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateFaqResponse(request.CorrelationId());

            var faqToUpdate = _mapper.Map<Faq>(request);

            var faqToUpdateTest = await _repository.GetByIdAsync(request.FaqId);
            if (faqToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(faqToUpdate);

            var faqUpdatedEvent = new FaqUpdatedEvent(faqToUpdate, "Mongo-History");
            _messagePublisher.Publish(faqUpdatedEvent);

            var dto = _mapper.Map<FaqDto>(faqToUpdate);
            response.Faq = dto;

            return Ok(response);
        }
    }
}