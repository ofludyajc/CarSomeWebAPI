using CarSomeWebAPI.Data.Entities;
using CarSomeWebAPI.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.CL.CustomerCL
{
    public interface ICustomerCL
    {
        Task<List<CustomerDto>> GetCustomers();

        Task<CustomerDto> GetCustomerByID(string ID);

        Task<CustomerDto> GetCustomerByAtoCID(string ID, Customer customer);

        Task<CustomerDto> CreateCustomer(CustomerDto customerDto);

        Task<string> UpdateCustomer(string ID, CustomerDto customerDto);

        Task<string> DeleteCustomer(string ID);
    }
}
