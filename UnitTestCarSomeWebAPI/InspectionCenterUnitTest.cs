using CarSomeWebAPI;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.Data.Entities;
using System;

namespace UnitTestCarSomeWebAPI
{
    [TestClass]
    public class InspectionCenterUnitTest
    {
        [TestMethod]
        public void GetInspectionCenters()
        {
            bool checker = false;
            var inspectionCenterService = Mock.Of<CarSomeWebAPI.Services.IInspectionCenterService>().GetInspectionCenters();

            if (inspectionCenterService != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void GetInspectionCenterByID()
        {
            bool checker = false;
            var ID = 101;

            var inspectionCenterService = Mock.Of<CarSomeWebAPI.Services.IInspectionCenterService>().GetInspectionCenterByID(ID);

            if (inspectionCenterService != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void CreateInspectionCenter()
        {
            bool checker = false;
            InspectionCenterDto inspectionCenterDto = new InspectionCenterDto
            {
                InspectionCenterID = 101,
                ICName = "Inspection Center A",
                ICAddress = "Petaling Jaya",
                ICContactNumber = "011-1111111"
            };

            var inspectionCenterService = Mock.Of<CarSomeWebAPI.Services.IInspectionCenterService>().CreateInspectionCenter(inspectionCenterDto);

            if (inspectionCenterService != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void UpdateInspectionCenter()
        {
            bool checker = false;
            var ID = 101;
            InspectionCenterDto inspectionCenterDto = new InspectionCenterDto
            {
                InspectionCenterID = 101,
                ICName = "Inspection Center A",
                ICAddress = "Petaling Jaya",
                ICContactNumber = "011-1111111"
            };

            var inspectionCenterService = Mock.Of<CarSomeWebAPI.Services.IInspectionCenterService>().UpdateInspectionCenter(ID, inspectionCenterDto);

            if (inspectionCenterService != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }

        [TestMethod]
        public void DeleteInspectionCenter()
        {
            bool checker = false;
            var ID = 101;

            var inspectionCenterService = Mock.Of<CarSomeWebAPI.Services.IInspectionCenterService>().DeleteInspectionCenter(ID);

            if (inspectionCenterService != null)
            {
                checker = true;
            }

            Assert.AreEqual(checker, true);
        }
    }
}
