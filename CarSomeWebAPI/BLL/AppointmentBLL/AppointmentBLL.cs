using System;
using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.Infrastructure.BusinessRulesException;
using CarSomeWebAPI.CL.AppointmentCL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.BLL
{
    public class AppointmentBLL : IAppointmentBLL
    {
        private readonly IAppointmentCL appointmentCL;

        public AppointmentBLL(IAppointmentCL appointmentCL)
        {
            this.appointmentCL = appointmentCL;
        }

        public async Task<List<AppointmentDto>> GetAppointments()
        {
            var appointments = await appointmentCL.GetAppointments();

            return appointments;
        }

        public async Task<AppointmentDto> GetAppointmentByID(string ID)
        {
            var appointmentbyID = await appointmentCL.GetAppointmentByID(ID);

            return appointmentbyID;
        }

        public async Task<AppointmentDto> CreateNewAppointment(AppointmentDto appointmentDto)
        {
            ValidateInspectionDate(appointmentDto.InspectionDate);

            var appointmentbyID = await appointmentCL.CreateNewAppointment(appointmentDto);

            return appointmentbyID;
        }

        public async Task<string> UpdateAppointment(string ID, AppointmentDto appointmentDto)
        {
            ValidateInspectionDate(appointmentDto.InspectionDate);

            var appointmentID = await appointmentCL.UpdateAppointment(ID, appointmentDto);

            return appointmentID;
        }

        public async Task<string> DeleteAppointment(string ID)
        {
            var appointmentID = await appointmentCL.DeleteAppointment(ID);

            return appointmentID;
        }

        #region Validation

        private void ValidateInspectionDate(DateTime inspectionDate)
        {
            ValidateAdvanceBooking(inspectionDate);
            ValidateSundayorDayOff(inspectionDate);
            ValidateWorkingHours(inspectionDate);
            ValidateSlotTime(inspectionDate);
            ValidateRecordCount(inspectionDate);
        }

        private static void ValidateAdvanceBooking(DateTime inspectionDate)
        {
            if (inspectionDate < DateTime.Now.AddDays(14))
            {
                throw new InvalidBookingDate();
            }
        }

        private static void ValidateSundayorDayOff(DateTime inspectionDate)
        {
            if (inspectionDate.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new InvalidDateException();
            }
        }

        private static void ValidateWorkingHours(DateTime inspectionDate)
        {
            TimeSpan start = new TimeSpan(9, 0, 0);
            TimeSpan end = new TimeSpan(18, 0, 0);

            if (!(inspectionDate.TimeOfDay >= start) && (inspectionDate.TimeOfDay <= end))
            {
                throw new InvalidHoursException();
            }
        }

        private static void ValidateSlotTime(DateTime inspectionDate)
        {
            int minutes = inspectionDate.Minute;
            int excessMinutes = minutes % 10;
            int adjust = 30 - excessMinutes;

            if (adjust != 30)
            {
                throw new InvalidTimeException();
            }
        }

        private void ValidateRecordCount(DateTime inspectionDate)
        {
            /*** This line of code is to get appointmet records from DB ***/
            var appointments = appointmentCL.GetAppointmentsBySchedule(inspectionDate);

            //// Check slots for saturday
            if (inspectionDate.DayOfWeek == DayOfWeek.Saturday)
            {
                if (appointments.Count >= 4)
                {
                    throw new ScheduleFullException();
                }
            }

            //// Check slots for weekdays
            else if (!(inspectionDate.DayOfWeek == DayOfWeek.Sunday) || (inspectionDate.DayOfWeek == DayOfWeek.Saturday))
            {
                if (appointments.Count >= 2)
                {
                    throw new ScheduleFullException();
                }
            }
        }

        #endregion
    }
}
