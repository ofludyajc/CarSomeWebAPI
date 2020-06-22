using CarSomeWebAPI.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.CL.AppointmentCL
{
    public interface IAppointmentCL
    {
        Task<List<AppointmentDto>> GetAppointments();

        Task<AppointmentDto> GetAppointmentByID(string ID);

        List<AppointmentDto> GetAppointmentsBySchedule(DateTime inspectionDate);

        Task<AppointmentDto> CreateNewAppointment(AppointmentDto appointmentDto);

        Task<string> UpdateAppointment(string ID, AppointmentDto appointmentDto);

        Task<string> DeleteAppointment(string ID);
    }
}
