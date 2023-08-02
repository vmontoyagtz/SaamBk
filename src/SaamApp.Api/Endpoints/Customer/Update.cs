using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SaamApp.Api.Hubs;
using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerRequest>.WithActionResult<UpdateCustomerResponse>
    {
        private readonly IMapper _mapper;

        //  private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Customer> _repository;

        private readonly IHubContext<SaamAppHub>
            _saamAppHub;

        public Update(
            IRepository<Customer> repository,
            IHubContext<SaamAppHub> SaamAppHub,
            // IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _saamAppHub = SaamAppHub;
            //  _messagePublisher = messagePublisher;
        }

        [HttpPut("api/customers")]
        [SwaggerOperation(
            Summary = "Updates a Customer",
            Description = "Updates a Customer",
            OperationId = "customers.update",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerResponse>> HandleAsync(UpdateCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerResponse(request.CorrelationId());

            var cusToUpdate = _mapper.Map<Customer>(request);

            try
            {
                cusToUpdate.UpdateGenderForCustomer(request.GenderId);
                await _repository.UpdateAsync(cusToUpdate, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var customerUpdatedEvent = new CustomerUpdatedEvent(cusToUpdate, "Mongo-History");
            // _messagePublisher.Publish(customerUpdatedEvent);

            var notification = $"Customer {cusToUpdate.CustomerFirstName} was updated. ";
            await _saamAppHub.Clients.All.SendAsync("ReceiveMessage", notification);

            var dto = _mapper.Map<CustomerDto>(cusToUpdate);
            response.Customer = dto;

            return Ok(response);
        }
    }
}