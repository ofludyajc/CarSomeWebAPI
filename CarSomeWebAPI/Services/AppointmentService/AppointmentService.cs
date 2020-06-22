using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.BLL;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace CarSomeWebAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentBLL _appointmentBLL;

        public AppointmentService(IAppointmentBLL appointmentBLL)
        {
            _appointmentBLL = appointmentBLL;
        }

        public async Task<List<AppointmentDto>> GetAppointments()
        {
            var result = await _appointmentBLL.GetAppointments();

            return result;
        }

        public async Task<AppointmentDto> GetAppointmentByID(string ID)
        {
            var result = await _appointmentBLL.GetAppointmentByID(ID);

            return result;
        }

        public async Task<AppointmentDto> CreateNewAppointment(AppointmentDto appointmentDto)
        {
            var result = await _appointmentBLL.CreateNewAppointment(appointmentDto);

            return result;
        }

        public async Task<string> UpdateAppointment(string ID, AppointmentDto appointmentDto)
        {
            var result = await _appointmentBLL.UpdateAppointment(ID, appointmentDto);

            return result;
        }

        public async Task<string> DeleteAppointment(string ID)
        {
            var result = await _appointmentBLL.DeleteAppointment(ID);

            return result;
        }
    }
}
