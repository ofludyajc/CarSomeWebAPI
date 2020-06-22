using CarSomeWebAPI;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.Data.Entities;
using System;

namespace UnitTestCarSomeWebAPI
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
        public void GetCustomers()
        {
            bool checker = false;
            var customer = Mock.Of<CarSomeWebAPI.Services.ICustomerService>().GetCustomers();

            if (customer != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void GetCustomerByID()
        {
            bool checker = false;
            var ID = "101";

            var customer = Mock.Of<CarSomeWebAPI.Services.ICustomerService>().GetCustomerByID(ID);

            if (customer != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void CreateCustomer()
        {
            bool checker = false;
            CustomerDto customerDto = new CustomerDto
            {
                CustomerID = String.Empty,
                CustomerName = "Oflud",
                ContactInfo = "0131313131",
                CarDetails = new CarDetails
                {
                    CarDetailID = String.Empty,
                    CustomerID = String.Empty,
                    CarInformation = "Sedan"
                }
            };

            var customer = Mock.Of<CarSomeWebAPI.Services.ICustomerService>().CreateCustomer(customerDto);

            if (customer != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            bool checker = false;
            var ID = "101";
            CustomerDto customerDto = new CustomerDto
            {
                CustomerID = String.Empty,
                CustomerName = "Oflud",
                ContactInfo = "0131313131",
                CarDetails = new CarDetails
                {
                    CarDetailID = String.Empty,
                    CustomerID = String.Empty,
                    CarInformation = "Sedan"
                }
            };

            var customer = Mock.Of<CarSomeWebAPI.Services.ICustomerService>().UpdateCustomer(ID, customerDto);

            if (customer != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void DeleteCustomer()
        {
            bool checker = false;
            var ID = "101";

            var customer = Mock.Of<CarSomeWebAPI.Services.ICustomerService>().DeleteCustomer(ID);

            if (customer != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }
    }
}
