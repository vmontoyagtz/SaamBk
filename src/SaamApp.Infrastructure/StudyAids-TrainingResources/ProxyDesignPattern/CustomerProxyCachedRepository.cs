using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Infrastructure.ProxyDesignPattern
{
    // <Summary>

    // Let's create a CachedRepository by combining the Strategy, Repository, and Proxy/Decorator patterns, this CachedRepository separates the caching logic from the repository implementation.
    // The Repository pattern abstracts the data access layer, which means that the rest of the system can work with a consistent interface, without worrying about the underlying implementation details. This makes it easier to make changes to the data access layer, such as adding caching, without having to modify the rest of the code.This also makes the system more modular and easier to maintain.
    // The Proxy/Decorator pattern allows for additional functionality to be added to an object without modifying the object itself. In the case of the CachedRepository pattern, a caching layer can be added to the Repository object without modifying the Repository object itself. This means that the existing code can continue to work with the Repository object as before, while the caching layer is added transparently. This makes the system more modular and easier to maintain.
    // The Strategy pattern allows for multiple caching strategies to be implemented and swapped in and out easily, without affecting the rest of the system. This means that if one caching strategy is not working well, it can be replaced with another without having to modify the rest of the code. This makes the system more modular and easier to maintain.
    // Overall, the combination of these patterns allows for a more modular and maintainable approach to caching in data access scenarios, which can result in significant performance improvements for applications.


    // Think of a hotel that offers different types of rooms(strategy) for its guests.Each room has a unique set of amenities and prices, and the hotel manages all the rooms through a central reservation system (repository). However, the hotel also offers an additional service of pre-caching certain rooms for frequent guests (proxy/decorator). This allows the frequent guests to quickly check-in and get to their pre-cached room without having to wait for the central reservation system to process their request.
    // Consider a library that maintains a central catalog of books (repository). The library offers different strategies for borrowing books, such as borrowing for a few days or borrowing for an extended period of time (strategy). Additionally, the library offers a pre-caching service (proxy/decorator) for popular books that are frequently requested by patrons.This service ensures that popular books are readily available for checkout without having to wait for the central catalog system to search for and retrieve the book.
    // Imagine a restaurant that offers different strategies for preparing and serving food (strategy). The restaurant maintains a central system for managing orders and inventory (repository). In addition, the restaurant employs a pre-caching service (proxy/decorator) for frequently ordered dishes, which allows the kitchen to quickly prepare and serve these dishes without having to wait for the central system to process the order.
    // In all of these analogies, the combination of the Strategy, Repository, and Proxy/Decorator patterns allow for a more modular and maintainable approach to the caching of data or services, which improves performance and reduces the load on the central system.


    // This code implements the CachedRepository pattern in C# using a combination
    // of the Strategy, Repository, and Proxy/Decorator patterns.
    // The CustomerProxyCachedRepository class is a proxy for the Customer entity
    // that wraps two repositories, one for reading and one for writing.
    // The class uses an IMemoryCache instance to cache data to avoid unnecessary
    // database calls and improve performance.

    // The constructor of the class takes in three parameters:
    // the IReadRepository<Customer> instance, the IRepository<Customer>
    // instance, and the IMemoryCache instance. These instances are used to read,
    // write, and cache data respectively.

    // The GetByIdAsync method first checks if the customer with the given
    // id exists in the cache. If it does, the method returns the cached
    // customer instance. If not, the method uses the _customerReadRepository
    // instance to retrieve the customer from the database. If the customer exists,
    // the method adds it to the cache using the _cache instance and returns the customer instance.

    // The ListAllAsync method uses the _customerReadRepository instance to retrieve
    // all customers from the database and return them.

    // The CountAll method uses the _customerReadRepository instance to retrieve
    // the number of customers in the database and returns the count.

    // The AddAsync, UpdateAsync, and DeleteAsync methods use the _customerWriteRepository
    // instance to add, update, and delete customers from the database, respectively.
    // After the operation is completed, the methods add or remove the customer from
    // the cache using the _cache instance.

    // Overall, this code shows how to implement the CachedRepository pattern in C#
    // using a combination of the Strategy, Repository, and Proxy/Decorator patterns
    // and the IMemoryCache class to cache data.
    // </Summary>
    public class CustomerProxyCachedRepository
    {
        // DefaultInfrastructureModule add the IReadRepository to be CachedRepository
        // If you use CachedRepository<T> to implement your repository, you don't need to worry about caching the data yourself. The CachedRepository<T> implementation will handle caching the data for you automatically.

        // You just need to specify the expiration time for the cache and the implementation will take care of refreshing the cache when the data expires.This can simplify your code and make it more maintainable, since you don't need to worry about implementing and managing the caching logic yourself.

        private readonly IMemoryCache _cache;
        private readonly IReadWithoutCacheRepository<Customer> _customerReadRepository;

        private readonly IRepository<Customer> _customerWriteRepository;

        public CustomerProxyCachedRepository(
            IReadWithoutCacheRepository<Customer> customerReadRepository,
            IRepository<Customer> customerWriteRepository,
            IMemoryCache cache
        )
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _cache = cache;
        }

        public async Task<Customer> GetByIdAsync(Guid customerId)
        {
            // checs whether the customer with the given customerId exists in the cache. If the customer is found in the cache, the method returns the cached customer object. If the key is not in the cache, the method returns false and sets the out parameter to null.
            if (_cache.TryGetValue(customerId, out Customer customer))
            {
                return customer;
            }

            // If the customer is not in the cache, the code retrieves it from the database and adds it to the cache for future access. This approach reduces the number of database queries, thereby improving performance.
            customer = await _customerReadRepository.GetByIdAsync(customerId);

            if (customer != null)
            {
                _cache.Set(customer.CustomerId, customer);
            }

            return customer;
        }


        public async Task<IEnumerable<Customer>> ListAllAsync()
        {
            return await _customerReadRepository.ListAsync();
        }

        public async Task<int> CountAll()
        {
            return await _customerReadRepository.CountAsync();
        }

        public async Task AddAsync(Customer entity)
        {
            await _customerWriteRepository.AddAsync(entity);

            _cache.Set(entity.CustomerId, entity);
        }

        public async Task UpdateAsync(Customer entity)
        {
            await _customerWriteRepository.UpdateAsync(entity);

            _cache.Set(entity.CustomerId, entity);
        }

        public async Task DeleteAsync(Customer entity)
        {
            await _customerWriteRepository.DeleteAsync(entity);

            _cache.Remove(entity.CustomerId);
        }
    }
}