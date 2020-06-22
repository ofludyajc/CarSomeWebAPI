using CarSomeWebAPI;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.Data.Entities;
using System;

namespace UnitTestCarSomeWebAPI
{
    [TestClass]
    public class CarDetailsUnitTest
    {
        [TestMethod]
        public void GetCarDetailsList()
        {
            bool checker = false;
            var carDetail = Mock.Of<CarSomeWebAPI.Services.CarDetailService.ICarDetailService>().GetCarDetailsList();

            if (carDetail != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void GetCarDetailByID()
        {
            bool checker = false;
            var ID = "101";

            var carDetail = Mock.Of<CarSomeWebAPI.Services.CarDetailService.ICarDetailService>().GetCarDetailsByID(ID);

            if (carDetail != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void CreateCarDetail()
        {
            bool checker = false;
            CarDetailsDto carDetailsDto = new CarDetailsDto
            {
                CarDetailID = String.Empty,
                CustomerID = String.Empty,
                CarInformation = "Sedan",
                CustomerInfo = new Customer
                {
                    CustomerID = String.Empty,
                    CustomerName = "Oflud",
                    ContactInfo = "0131313131"
                }
            };

            var carDetail = Mock.Of<CarSomeWebAPI.Services.CarDetailService.ICarDetailService>().CreateCarDetails(carDetailsDto);

            if (carDetail != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void UpdateCarDetail()
        {
            bool checker = false;
            var ID = "101";
            CarDetailsDto carDetailsDto = new CarDetailsDto
            {
                CarDetailID = String.Empty,
                CustomerID = String.Empty,
                CarInformation = "Sedan",
                CustomerInfo = new Customer
                {
                    CustomerID = String.Empty,
                    CustomerName = "Oflud",
                    ContactInfo = "0131313131"
                }
            };

            var carDetail = Mock.Of<CarSomeWebAPI.Services.CarDetailService.ICarDetailService>().UpdateCarDetails(ID, carDetailsDto);

            if (carDetail != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void DeleteCarDetail()
        {
            bool checker = false;
            var ID = "101";

            var carDetail = Mock.Of<CarSomeWebAPI.Services.CarDetailService.ICarDetailService>().DeleteCarDetails(ID);

            if (carDetail != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }
    }
}
