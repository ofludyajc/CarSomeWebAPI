using CarSomeWebAPI.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.BLL
{
    public interface ICustomerBLL
    {
        Task<List<CustomerDto>> GetCustomers();

        Task<CustomerDto> GetCustomerByID(string ID);

        Task<CustomerDto> CreateCustomer(CustomerDto customerDto);

        Task<string> UpdateCustomer(string ID, CustomerDto customerDto);

        Task<string> DeleteCustomer(string ID);
    }
}
