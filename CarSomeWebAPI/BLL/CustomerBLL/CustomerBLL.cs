using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.CL.CustomerCL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.BLL
{
    public class CustomerBLL : ICustomerBLL
    {
        private readonly ICustomerCL customerCL;

        public CustomerBLL(ICustomerCL customerCL)
        {
            this.customerCL = customerCL;
        }

        public async Task<List<CustomerDto>> GetCustomers()
        {
            var customerList = await customerCL.GetCustomers();

            return customerList;
        }

        public async Task<CustomerDto> GetCustomerByID(string ID)
        {
            var customer = await customerCL.GetCustomerByID(ID);

            return customer;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var customer = await customerCL.CreateCustomer(customerDto);

            return customer;
        }

        public async Task<string> UpdateCustomer(string ID, CustomerDto customerDto)
        {
            var customerID = await customerCL.UpdateCustomer(ID, customerDto);

            return customerID;
        }

        public async Task<string> DeleteCustomer(string ID)
        {
            var customerID = await customerCL.DeleteCustomer(ID);

            return customerID;
        }
    }
}
