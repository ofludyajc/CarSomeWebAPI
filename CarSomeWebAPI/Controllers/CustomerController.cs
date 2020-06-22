using CarSomeWebAPI.Infrastructure.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarSomeWebAPI.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSomeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("GetCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var result = await customerService.GetCustomers();

            return result;
        }

        [HttpGet("GetCustomerBy/{ID}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerByID(string ID)
        {
            var result = await customerService.GetCustomerByID(ID);

            return result;
        }

        [HttpPost("CreateCustomer")]
        public async Task<CustomerDto> CreateCustomer([FromBody] CustomerDto inspectionCenterDto)
        {
            var result = await customerService.CreateCustomer(inspectionCenterDto);

            return result;
        }

        [HttpPut("UpdateCustomerBy/{ID}")]
        public async Task<string> UpdateCustomer(string ID, [FromBody] CustomerDto inspectionCenterDto)
        {
            var result = await customerService.UpdateCustomer(ID, inspectionCenterDto);

            return result;
        }

        [HttpDelete("DeleteCustomerBy/{ID}")]
        public async Task<string> DeleteCustomer(string ID)
        {
            var result = await customerService.DeleteCustomer(ID);

            return result;
        }
    }
}