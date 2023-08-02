using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.InvoiceDetail;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.InvoiceDetailEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateInvoiceDetailRequest>.WithActionResult<
        UpdateInvoiceDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<InvoiceDetail> _repository;

        public Update(
            IRepository<InvoiceDetail> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/invoiceDetails")]
        [SwaggerOperation(
            Summary = "Updates a InvoiceDetail",
            Description = "Updates a InvoiceDetail",
            OperationId = "invoiceDetails.update",
            Tags = new[] { "InvoiceDetailEndpoints" })
        ]
        public override async Task<ActionResult<UpdateInvoiceDetailResponse>> HandleAsync(
            UpdateInvoiceDetailRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateInvoiceDetailResponse(request.CorrelationId());

            var idndvdToUpdate = _mapper.Map<InvoiceDetail>(request);

            var invoiceDetailToUpdateTest = await _repository.GetByIdAsync(request.InvoiceDetailId);
            if (invoiceDetailToUpdateTest is null)
            {
                return NotFound();
            }

            idndvdToUpdate.UpdateInvoiceForInvoiceDetail(request.InvoiceId);
            idndvdToUpdate.UpdateProductForInvoiceDetail(request.ProductId);
            await _repository.UpdateAsync(idndvdToUpdate);

            var invoiceDetailUpdatedEvent = new InvoiceDetailUpdatedEvent(idndvdToUpdate, "Mongo-History");
            _messagePublisher.Publish(invoiceDetailUpdatedEvent);

            var dto = _mapper.Map<InvoiceDetailDto>(idndvdToUpdate);
            response.InvoiceDetail = dto;

            return Ok(response);
        }
    }
}