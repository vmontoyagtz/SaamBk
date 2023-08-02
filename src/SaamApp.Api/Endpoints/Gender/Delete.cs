using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Gender;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GenderEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteGenderRequest>.WithActionResult<
        DeleteGenderResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Gender> _genderReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Gender> _repository;

        public Delete(IRepository<Gender> GenderRepository, IRepository<Gender> GenderReadRepository,
            IRepository<Advisor> advisorRepository,
            IRepository<Customer> customerRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = GenderRepository;
            _genderReadRepository = GenderReadRepository;
            _advisorRepository = advisorRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/genders/{GenderId}")]
        [SwaggerOperation(
            Summary = "Deletes an Gender",
            Description = "Deletes an Gender",
            OperationId = "genders.delete",
            Tags = new[] { "GenderEndpoints" })
        ]
        public override async Task<ActionResult<DeleteGenderResponse>> HandleAsync(
            [FromRoute] DeleteGenderRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteGenderResponse(request.CorrelationId());

            var gender = await _genderReadRepository.GetByIdAsync(request.GenderId);

            if (gender == null)
            {
                return NotFound();
            }

            var advisorSpec = new GetAdvisorWithGenderKeySpec(gender.GenderId);
            var advisors = await _advisorRepository.ListAsync(advisorSpec);
            await _advisorRepository.DeleteRangeAsync(advisors); // you could use soft delete with IsDeleted = true
            var customerSpec = new GetCustomerWithGenderKeySpec(gender.GenderId);
            var customers = await _customerRepository.ListAsync(customerSpec);
            await _customerRepository.DeleteRangeAsync(customers); // you could use soft delete with IsDeleted = true

            var genderDeletedEvent = new GenderDeletedEvent(gender, "Mongo-History");
            _messagePublisher.Publish(genderDeletedEvent);

            await _repository.DeleteAsync(gender);

            return Ok(response);
        }
    }
}