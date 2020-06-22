using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.Infrastructure.BusinessRulesException;
using CarSomeWebAPI.Common;
using CarSomeWebAPI.Infrastructure.Helper;
using CarSomeWebAPI.Data.Entities;
using CarSomeWebAPI.CL.CustomerCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Caching;
using AutoMapper;


namespace CarSomeWebAPI.CL.AppointmentCL
{
    public class AppointmentCL : IAppointmentCL
    {
        private readonly IMapper mapper;
        private readonly ICustomerCL customerCL;
        Utilities util = new Utilities();
        ObjectCache cache = MemoryCache.Default;
        

        public AppointmentCL(IMapper mapper, ICustomerCL customerCL)
        {
            this.mapper = mapper;
            this.customerCL = customerCL;
        }

        public async Task<List<AppointmentDto>> GetAppointments()
        {
            var cacheKey = CacheKeys.AppointmentCacheKeys.APPOINTMENTS;
            var appointmentsCached = (List<Appointment>)cache.Get(cacheKey);

            if (appointmentsCached == null)
            {
                throw new NotFoundException();
            }

            await Task.CompletedTask;

            return mapper.Map<List<AppointmentDto>>(appointmentsCached);
        }

        public async Task<AppointmentDto> GetAppointmentByID(string ID)
        {
            var cacheKey = CacheKeys.AppointmentCacheKeys.APPOINTMENTS;
            var appointmentsCached = (List<Appointment>)cache.Get(cacheKey);
            var appointments = new List<Appointment>();
            var appointmentByID = new Appointment();

            if (appointmentsCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                appointmentByID = appointmentsCached.SingleOrDefault(ic => ic.AppointmentID == ID);

                if (appointmentByID == null)
                {
                    throw new NotFoundException();
                }
            }

            await Task.CompletedTask;

            return mapper.Map<AppointmentDto>(appointmentByID);
        }

        public List<AppointmentDto> GetAppointmentsBySchedule(DateTime inspectionDate)
        {
            var cacheKey = CacheKeys.AppointmentCacheKeys.APPOINTMENTS;
            var appointmentsCached = (List<Appointment>)cache.Get(cacheKey);
            var appointments = new List<Appointment>();

            if (appointmentsCached == null)
            {
                //Dont throw exception, do nothing because this is just for validation.
            }

            else
            {
                appointments = appointmentsCached.Where(ic => ic.InspectionDate.AddSeconds(-ic.InspectionDate.Second).AddMilliseconds(-ic.InspectionDate.Millisecond) == inspectionDate.AddSeconds(-inspectionDate.Second).AddMilliseconds(-inspectionDate.Millisecond)).ToList();

                if (appointments == null)
                {
                    throw new NotFoundException();
                }
            }

            return mapper.Map<List<AppointmentDto>>(appointments);
        }

        public async Task<AppointmentDto> CreateNewAppointment(AppointmentDto appointmentDto)
        {
            var cacheKey = CacheKeys.AppointmentCacheKeys.APPOINTMENTS;
            var appointmentsCached = (List<Appointment>)cache.Get(cacheKey);
            var appointments = new List<Appointment>();
            var appointmentByID = new Appointment();

            if (appointmentsCached == null)
            {
                var entity = await PopulateAppointment(appointmentDto);
                appointments.Add(entity);
                cache.Set(cacheKey, appointments, DateTime.Now.AddMinutes(60), null);
                appointmentByID = entity;
            }

            else
            {
                appointmentByID = appointmentsCached.SingleOrDefault(ic => ic.AppointmentID == appointmentDto.AppointmentID);

                if (appointmentByID != null)
                {
                    throw new RecordExistingException();
                }

                var entity = await PopulateAppointment(appointmentDto);
                appointments.AddRange(appointmentsCached);
                appointments.Add(entity);
                cache.Set(cacheKey, appointments, DateTime.Now.AddMinutes(60), null);
                appointmentByID = entity;
            }

            await Task.CompletedTask;

            return mapper.Map<AppointmentDto>(appointmentByID);
        }

        public async Task<string> UpdateAppointment(string ID, AppointmentDto appointmentDto)
        {
            var cacheKey = CacheKeys.AppointmentCacheKeys.APPOINTMENTS;
            var appointmentsCached = (List<Appointment>)cache.Get(cacheKey);
            var appointments = new List<Appointment>();
            var appointmentByID = new Appointment();

            if (appointmentsCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                appointmentByID = appointmentsCached.SingleOrDefault(ic => ic.AppointmentID == appointmentDto.AppointmentID);

                if (appointmentByID == null)
                {
                    throw new NotFoundException();
                }

                var entity = UpdateAppointment(appointmentDto, appointmentByID);
                appointmentsCached.Remove(appointmentByID);
                appointmentsCached.Add(entity);
                cache.Set(cacheKey, appointmentsCached, DateTime.Now.AddMinutes(60), null);
                appointmentByID = entity;
            }

            await Task.CompletedTask;

            return appointmentDto.AppointmentID;
        }

        public async Task<string> DeleteAppointment(string ID)
        {
            var cacheKey = CacheKeys.AppointmentCacheKeys.APPOINTMENTS;
            var appointmentsCached = (List<Appointment>)cache.Get(cacheKey);
            var appointmentByID = new Appointment();

            if (appointmentsCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                appointmentByID = appointmentsCached.SingleOrDefault(ic => ic.AppointmentID == ID);

                if (appointmentByID == null)
                {
                    throw new NotFoundException();
                }

                appointmentsCached.Remove(appointmentByID);
                cache.Set(cacheKey, appointmentsCached, DateTime.Now.AddMinutes(60), null);
            }

            await Task.CompletedTask;

            return ID;
        }

        private async Task<Appointment> PopulateAppointment(AppointmentDto appointmentDto)
        {
            var customer = await CheckExistingCustomer(appointmentDto);

            var entity = new Appointment()
            {
                AppointmentID = util.GenerateAppointmentID(),
                InspectionCenterID = appointmentDto.InspectionCenterID,
                CustomerID = customer.CustomerID,
                InspectionDate = appointmentDto.InspectionDate,
                InspectionCentre = new InspectionCenter
                {
                    InspectionCenterID = appointmentDto.InspectionCenterID,
                    ICName = appointmentDto.InspectionCentre.ICName,
                    ICAddress = appointmentDto.InspectionCentre.ICAddress,
                    ICContactNumber = appointmentDto.InspectionCentre.ICContactNumber
                },
                CustomerInfo = new Customer
                {
                    CustomerID = customer.CustomerID,
                    CustomerName = customer.CustomerName,
                    ContactInfo = customer.ContactInfo,
                    CarDetails = new CarDetails
                    {
                        CarDetailID = customer.CarDetails.CarDetailID,
                        CarInformation = customer.CarDetails.CarInformation,
                    }
                }
            };

            return entity;
        }

        private static Appointment UpdateAppointment(AppointmentDto appointmentDto, Appointment appointment)
        {
            appointment.AppointmentID = appointmentDto.AppointmentID;
            appointment.InspectionCenterID = appointmentDto.InspectionCenterID;
            appointment.CustomerID = appointmentDto.CustomerID;
            appointment.InspectionDate = appointmentDto.InspectionDate;
            appointment.InspectionCentre.InspectionCenterID = appointmentDto.InspectionCenterID;
            appointment.InspectionCentre.ICName = appointmentDto.InspectionCentre.ICName;
            appointment.InspectionCentre.ICAddress = appointmentDto.InspectionCentre.ICAddress;
            appointment.InspectionCentre.ICContactNumber = appointmentDto.InspectionCentre.ICContactNumber;
            appointment.CustomerInfo.CustomerID = appointmentDto.CustomerID;
            appointment.CustomerInfo.CustomerName = appointmentDto.CustomerInfo.CustomerName;
            appointment.CustomerInfo.ContactInfo = appointmentDto.CustomerInfo.ContactInfo;
            appointment.CustomerInfo.CarDetails.CustomerID = appointmentDto.CustomerID;
            appointment.CustomerInfo.CarDetails.CarDetailID = appointmentDto.CustomerInfo.CarDetails.CarDetailID;
            appointment.CustomerInfo.CarDetails.CarInformation = appointmentDto.CustomerInfo.CarDetails.CarInformation;

            return appointment;
        }

        private async Task<CustomerDto> CheckExistingCustomer(AppointmentDto appointmentDto)
        {
            if (appointmentDto.CustomerID == null || appointmentDto.CustomerID == "string")
            {
                appointmentDto.CustomerInfo.CustomerID = util.GenerateCustomerID();

                //var cacheKey = CacheKeys.CustomerCacheKeys.CUSTOMERS;
                //var customerCached = (List<Customer>)cache.Get(cacheKey);
                //customerCached.Add(appointmentDto.CustomerInfo);
                //cache.Set(cacheKey, customerCached, DateTime.Now.AddMinutes(60), null);

                var customer = await customerCL.CreateCustomer(mapper.Map<CustomerDto>(appointmentDto.CustomerInfo));

                return mapper.Map<CustomerDto>(customer);
            }

            else
            {
                var customer = await customerCL.GetCustomerByAtoCID(appointmentDto.CustomerID, appointmentDto.CustomerInfo);

                return customer;
            }
        }
    }
}
