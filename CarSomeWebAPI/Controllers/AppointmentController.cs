using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace CarSomeWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentService appointmentService)
        {
            _logger = logger;
            this.appointmentService = appointmentService;
        }

        [HttpGet("GetAppointments")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
        {
            var result = await appointmentService.GetAppointments();

            return result;
        }

        [HttpGet("GetAppointment/{ID}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointmentByID(string ID)
        {
            var result = await appointmentService.GetAppointmentByID(ID);

            return result;
        }

        [HttpPost("CreateAppointments")]
        public async Task<AppointmentDto> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            var result = await appointmentService.CreateNewAppointment(appointmentDto);

            return result;
        }

        [HttpPut("UpdateAppointment/{ID}")]
        public async Task<string> UpdateAppointment(string ID, [FromBody] AppointmentDto appointmentDto)
        {
            var result = await appointmentService.UpdateAppointment(ID, appointmentDto);

            return result;
        }

        [HttpDelete("DeleteAppointment/{ID}")]
        public async Task<string> DeleteAppointment(string ID)
        {
            var result = await appointmentService.DeleteAppointment(ID);

            return result;
        }
    }
}