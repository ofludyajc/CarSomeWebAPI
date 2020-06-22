using CarSomeWebAPI.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.BLL
{
    public interface IAppointmentBLL
    {
        Task<List<AppointmentDto>> GetAppointments();

        Task<AppointmentDto> GetAppointmentByID(string ID);

        Task<AppointmentDto> CreateNewAppointment(AppointmentDto appointmentDto);

        Task<string> UpdateAppointment(string ID, AppointmentDto appointmentDto);

        Task<string> DeleteAppointment(string ID);
    }
}
