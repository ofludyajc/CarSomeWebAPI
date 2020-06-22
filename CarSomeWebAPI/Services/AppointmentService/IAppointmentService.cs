using CarSomeWebAPI.Infrastructure.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSomeWebAPI.Services
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetAppointments();

        Task<AppointmentDto> GetAppointmentByID(string ID);

        Task<AppointmentDto> CreateNewAppointment(AppointmentDto appointmentDto);

        Task<string> UpdateAppointment(string ID, AppointmentDto appointmentDto);

        Task<string> DeleteAppointment(string ID);
    }
}
