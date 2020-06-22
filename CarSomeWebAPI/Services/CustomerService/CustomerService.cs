using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.BLL;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSomeWebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerBLL _customerBLL;

        public CustomerService(ICustomerBLL customerBLL)
        {
            _customerBLL = customerBLL;
        }

        public async Task<List<CustomerDto>> GetCustomers()
        {
            var result = await _customerBLL.GetCustomers();

            return result;
        }

        public async Task<CustomerDto> GetCustomerByID(string ID)
        {
            var result = await _customerBLL.GetCustomerByID(ID);

            return result;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var result = await _customerBLL.CreateCustomer(customerDto);

            return result;
        }

        public async Task<string> UpdateCustomer(string ID, CustomerDto customerDto)
        {
            var result = await _customerBLL.UpdateCustomer(ID, customerDto);

            return result;
        }

        public async Task<string> DeleteCustomer(string ID)
        {
            var result = await _customerBLL.DeleteCustomer(ID);

            return result;
        }
    }
}
