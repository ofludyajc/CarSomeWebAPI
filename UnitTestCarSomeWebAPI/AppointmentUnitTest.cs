using CarSomeWebAPI;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.Data.Entities;
using System;


namespace UnitTestCarSomeWebAPI
{
    [TestClass]
    public class AppointmentUnitTest
    {
        [TestMethod]
        public void GetAppointments()
        {
            bool checker = false;
            var appointment = Mock.Of<CarSomeWebAPI.Services.IAppointmentService>().GetAppointments();

            if (appointment != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void GetAppointmentByID()
        {
            bool checker = false;
            var ID = "101";

            var appointment = Mock.Of<CarSomeWebAPI.Services.IAppointmentService>().GetAppointmentByID(ID);

            if (appointment != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void CreateAppointment()
        {
            bool checker = false;
            AppointmentDto appointmentDto = new AppointmentDto
            {
                AppointmentID = string.Empty,
                InspectionCenterID = 101,
                CustomerID = string.Empty,
                InspectionDate = DateTime.Now.AddDays(15),
                InspectionCentre = new InspectionCenter
                {
                    InspectionCenterID = 101,
                    ICName = "Inspection Center A",
                    ICAddress = "Petaling Jaya",
                    ICContactNumber = "011-1111111"
                },
                CustomerInfo = new Customer
                {
                    CustomerID = String.Empty,
                    CustomerName = "Oflud",
                    ContactInfo = "013-1313131",
                    CarDetails = new CarDetails
                    {
                        CarDetailID = String.Empty,
                        CarInformation = "Sedan"
                    }
                }
            };

            var appointment = Mock.Of<CarSomeWebAPI.Services.IAppointmentService>().CreateNewAppointment(appointmentDto);

            if (appointment != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void UpdateAppointment()
        {
            bool checker = false;
            var ID = "101";
            AppointmentDto appointmentDto = new AppointmentDto
            {
                AppointmentID = string.Empty,
                InspectionCenterID = 101,
                CustomerID = string.Empty,
                InspectionDate = DateTime.Now.AddDays(15),
                InspectionCentre = new InspectionCenter
                {
                    InspectionCenterID = 101,
                    ICName = "Inspection Center A",
                    ICAddress = "Petaling Jaya",
                    ICContactNumber = "011-1111111"
                },
                CustomerInfo = new Customer
                {
                    CustomerID = String.Empty,
                    CustomerName = "Oflud",
                    ContactInfo = "013-1313131",
                    CarDetails = new CarDetails
                    {
                        CarDetailID = String.Empty,
                        CarInformation = "Sedan"
                    }
                }
            };

            var appointment = Mock.Of<CarSomeWebAPI.Services.IAppointmentService>().UpdateAppointment(ID, appointmentDto);

            if (appointment != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void DeleteAppointment()
        {
            bool checker = false;
            var ID = "101";

            var appointment = Mock.Of<CarSomeWebAPI.Services.IAppointmentService>().DeleteAppointment(ID);

            if (appointment != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }
    }
}
