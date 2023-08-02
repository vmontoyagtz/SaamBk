using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Api.FacadeDesignPattern
{
    // <Summary>


    // In this implementation, the EmployeeFacade class serves as a simplified interface for
    // client code to interact with the Employee entity. It encapsulates the complexity of
    // querying the entity and provides a simpler and more intuitive interface for client
    // code to interact with. This is where the Facade design pattern comes in.

    // The Facade design pattern is a structural design pattern that provides a simplified
    // interface to a complex system, making the system easier to use and understand.
    // It involves creating a new interface that is more convenient for the client code to use,
    // without changing the underlying implementation of the system.

    // In this case, the EmployeeFacade class provides a simplified interface for client
    // code to interact with the Employee entity, without exposing the details of the
    // implementation. It achieves this by using the EmployeeIsSupervisorSpecification
    // and EmployeeHasPhoneNumberSpecification classes to filter the entitys based
    // on certain criteria, and then returning the filtered results to the client code.

    // By encapsulating the complexity of querying the entity and providing a
    // simpler and more intuitive interface for client code to interact with,
    // the EmployeeFacade class makes it easier for other developers to use the
    // Employee entity in their code. It also makes the code more maintainable,
    // as changes to the implementation of the Employee entity can be made without
    // affecting the client code that uses the EmployeeFacade class.

    // our List Endpoints are implementations of the Facade design pattern. They encapsulates the complexity of accessing the entities through the "IRepository" interface, and provide a simplified interface to retrieve a list of the entity values. Our List endpoint classes have only one responsibility, which is to handle a request to retrieve a list of entity values, and they delegates the actual retrieval of entities to the repository class. By using the Facade pattern, the implementation of the repository class can be changed without affecting the implementation of the endpoint class, as long as the interface of the repository remains the same.

    // The GetByIdWithIncludes class is a single class that provides a specific functionality, which is to retrieve an entity by their ID with their related entities included.It does not encapsulate a complex subsystem or provide a simplified interface to it, which are key characteristics of the Facade Design Pattern.

    // The GetByIdWithIncludes class accesses the Employee entity repository and applies a specific specification to retrieve the data. It does not simplify the complexity of the Employee entity or its related entities to a single interface, which is the primary goal of the Facade pattern.Instead, the class relies on the specifications and the repository to retrieve and return the data.

    // In summary, GetByIdWithIncludes is a useful API endpoint that provides a specific functionality, but it does not implement the Facade Design Pattern by itself because it does not simplify the complexity of a subsystem or provide a unified interface to it.

    // </Summary>

    public class EmployeeFacade
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeFacade(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        //public async Task<IEnumerable<Employee>> ListActiveEmployeesAsync()
        //{
        //  //  var specification = new EmployeeIsActiveSpecification();
        //   // return await _employeeRepository.ListAsync(specification);
        //}

        //public async Task<IEnumerable<Employee>> ListByPhoneNumberTypeIdAsync()
        //{
        //    //var specification = new EmployeeHasPhoneNumberSpecification();
        //    //return await _employeeRepository.ListAsync(specification);
        //}
    }
}