using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.Infrastructure.BusinessRulesException;
using CarSomeWebAPI.Common;
using CarSomeWebAPI.CL.CarDetailsCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Caching;
using CarSomeWebAPI.Data.Entities;
using AutoMapper;
using CarSomeWebAPI.Infrastructure.Helper;

namespace CarSomeWebAPI.CL.CustomerCL
{
    public class CustomerCL : ICustomerCL
    {
        private readonly IMapper mapper;
        private readonly ICarDetailsCL carDetailsCL;
        ObjectCache cache = MemoryCache.Default;
        Utilities util = new Utilities();

        public CustomerCL(IMapper mapper, ICarDetailsCL carDetailsCL)
        {
            this.mapper = mapper;
            this.carDetailsCL = carDetailsCL;
        }

        public async Task<List<CustomerDto>> GetCustomers()
        {
            var cacheKey = CacheKeys.CustomerCacheKeys.CUSTOMERS;
            var customerCached = (List<Customer>)cache.Get(cacheKey);

            if (customerCached == null)
            {
                throw new NotFoundException();
            }

            await Task.CompletedTask;

            return mapper.Map<List<CustomerDto>>(customerCached);
        }

        public async Task<CustomerDto> GetCustomerByID(string ID)
        {
            var customers = new List<Customer>();
            var cacheKey = CacheKeys.CustomerCacheKeys.CUSTOMERS;
            var customerCached = (List<Customer>)cache.Get(cacheKey);
            var customerByID = new Customer();

            if (customerCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                customerByID = customerCached.SingleOrDefault(ic => ic.CustomerID == ID);

                if (customerByID == null)
                {
                    throw new NotFoundException();
                }
            }

            await Task.CompletedTask;

            return mapper.Map<CustomerDto>(customerByID);
        }

        public async Task<CustomerDto> GetCustomerByAtoCID(string ID, Customer customer)
        {
            var customers = new List<Customer>();
            var cacheKey = CacheKeys.CustomerCacheKeys.CUSTOMERS;
            var customerCached = (List<Customer>)cache.Get(cacheKey);
            var customerByID = new Customer();

            if (customerCached == null)
            {
                customers.Add(customer);
                cache.Set(cacheKey, customers, DateTime.Now.AddMinutes(60), null);
            }

            else
            {
                customerByID = customerCached.SingleOrDefault(ic => ic.CustomerID == ID);

                if (customerByID == null)
                {
                    customers.Add(customer);
                    cache.Set(cacheKey, customers, DateTime.Now.AddMinutes(60), null);
                }
            }

            await Task.CompletedTask;

            return mapper.Map<CustomerDto>(customerByID);
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var customers = new List<Customer>();
            var cacheKey = CacheKeys.CustomerCacheKeys.CUSTOMERS;
            var customerCached = (List<Customer>)cache.Get(cacheKey);
            var customerByID = new Customer();

            if (customerCached == null)
            {
                var entity = PopulateCustomer(customerDto);
                customers.Add(entity);
                cache.Set(cacheKey, customers, DateTime.Now.AddMinutes(60), null);
                customerByID = entity;
            }

            else
            {
                customerByID = customerCached.SingleOrDefault(ic => ic.CustomerID == customerDto.CustomerID);

                if (customerByID != null)
                {
                    throw new RecordExistingException();
                }

                var entity = PopulateCustomer(customerDto);
                customers.AddRange(customerCached);
                customers.Add(entity);
                cache.Set(cacheKey, customers, DateTime.Now.AddMinutes(60), null);
                customerByID = entity;
            }

            await Task.CompletedTask;

            return mapper.Map<CustomerDto>(customerByID);
        }

        public async Task<string> UpdateCustomer(string ID, CustomerDto customerDto)
        {
            var cacheKey = CacheKeys.CustomerCacheKeys.CUSTOMERS;
            var customerCached = (List<Customer>)cache.Get(cacheKey);
            var customerByID = new Customer();

            if (customerCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                customerByID = customerCached.SingleOrDefault(ic => ic.CustomerID == ID);

                if (customerByID == null)
                {
                    throw new NotFoundException();
                }

                var entity = UpdateCustomer(customerDto, customerByID);

                customerCached.Remove(customerByID);
                customerCached.Add(entity);
                cache.Set(cacheKey, customerCached, DateTime.Now.AddMinutes(60), null);
            }

            await Task.CompletedTask;

            return customerDto.CustomerID;
        }

        public async Task<string> DeleteCustomer(string ID)
        {
            var cacheKey = CacheKeys.CustomerCacheKeys.CUSTOMERS;
            var customerCached = (List<Customer>)cache.Get(cacheKey);
            var customerByID = new Customer();

            if (customerCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                customerByID = customerCached.SingleOrDefault(ic => ic.CustomerID == ID);

                if (customerByID == null)
                {
                    throw new NotFoundException();
                }

                customerCached.Remove(customerByID);
                cache.Set(cacheKey, customerCached, DateTime.Now.AddMinutes(60), null);
            }

            await Task.CompletedTask;

            return ID;
        }

        private Customer PopulateCustomer(CustomerDto customerDto)
        {
            var entity = new Customer()
            {
                CustomerID = util.GenerateCustomerID(),
                CustomerName = customerDto.CustomerName,
                ContactInfo = customerDto.ContactInfo,
                CarDetails = new CarDetails
                {
                    CarDetailID = util.GenerateCarDetailsID(),
                    CarInformation = customerDto.CarDetails.CarInformation
                }
            };

            return entity;
        }

        private static Customer UpdateCustomer(CustomerDto customerDto, Customer customer)
        {
            customer.CustomerID = customerDto.CustomerID;
            customer.CustomerName = customerDto.CustomerName;
            customer.ContactInfo = customerDto.ContactInfo;
            customer.CarDetails.CarDetailID = customerDto.CarDetails.CarDetailID;
            customer.CarDetails.CarInformation = customerDto.CarDetails.CarInformation;

            return customer;
        }

        private void SaveCarDetails(CustomerDto customerDto)
        {
            customerDto.CarDetails = new CarDetails
            {
                CarDetailID = customerDto.CarDetails.CarDetailID,
                CarInformation = customerDto.CarDetails.CarInformation
            };

            var carDetails = mapper.Map<CarDetailsDto>(customerDto.CarDetails);

            var carID = carDetailsCL.GetCarDetailIDByID((customerDto.CarDetails.CarDetailID));

            if (carID == null)
            {
                carDetailsCL.UpdateCarDetails(customerDto.CarDetails.CarDetailID, carDetails);
            }
        }
    }
}
