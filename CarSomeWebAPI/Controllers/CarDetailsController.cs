using CarSomeWebAPI.Infrastructure.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarSomeWebAPI.Services.CarDetailService;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSomeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailsController : ControllerBase
    {
        private readonly ICarDetailService carDetailService;

        public CarDetailsController(ICarDetailService carDetailService)
        {
            this.carDetailService = carDetailService;
        }

        [HttpGet("GetCarDetailsList")]
        public async Task<ActionResult<IEnumerable<CarDetailsDto>>> GetCarDetailsList()
        {
            var result = await carDetailService.GetCarDetailsList();

            return result;
        }

        [HttpGet("GetCarDetails/{ID}")]
        public async Task<ActionResult<CarDetailsDto>> GetCarDetailsByID(string ID)
        {
            var result = await carDetailService.GetCarDetailsByID(ID);

            return result;
        }

        [HttpPost("CreateCarDetails")]
        public async Task<string> CreateCustomer([FromBody] CarDetailsDto carDetailsDto)
        {
            var result = await carDetailService.CreateCarDetails(carDetailsDto);

            return result;
        }

        [HttpPut("UpdateCarDetails/{ID}")]
        public async Task<string> UpdateCustomer(string ID, [FromBody] CarDetailsDto carDetailsDto)
        {
            var result = await carDetailService.UpdateCarDetails(ID, carDetailsDto);

            return result;
        }

        [HttpDelete("DeleteCarDetails{ID}")]
        public async Task<string> DeleteCustomer(string ID)
        {
            var result = await carDetailService.DeleteCarDetails(ID);

            return result;
        }
    }
}