using CarSomeWebAPI.Infrastructure.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSomeWebAPI.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetCustomers();

        Task<CustomerDto> GetCustomerByID(string ID);

        Task<CustomerDto> CreateCustomer(CustomerDto customerDto);

        Task<string> UpdateCustomer(string ID, CustomerDto customerDto);

        Task<string> DeleteCustomer(string ID);
    }
}
