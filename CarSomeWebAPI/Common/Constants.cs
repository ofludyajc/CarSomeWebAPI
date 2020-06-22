using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSomeWebAPI.Data.Entities;

namespace CarSomeWebAPI.Common
{
    public class Constants
    {
        public List<InspectionCenter> inspectionCenters = new List<InspectionCenter>
        {
            new InspectionCenter
            {
                InspectionCenterID = 101,
                ICName = "Inspection Center A",
                ICAddress = "Petaling Jaya",
                ICContactNumber = "011-1111111"
            },

            new InspectionCenter
            {
                InspectionCenterID = 102,
                ICName = "Inspection Center B",
                ICAddress = "KL Sentral",
                ICContactNumber = "012-1111111"
            },

            new InspectionCenter
            {
                InspectionCenterID = 103,
                ICName = "Inspection Center C",
                ICAddress = "Cyber Jaya",
                ICContactNumber = "013-1111111"
            },

            new InspectionCenter
            {
                InspectionCenterID = 104,
                ICName = "Inspection Center D",
                ICAddress = "Bukit Jalil",
                ICContactNumber = "014-1111111"
            },

            new InspectionCenter
            {
                InspectionCenterID = 105,
                ICName = "Inspection Center E",
                ICAddress = "KL City Center",
                ICContactNumber = "015-1111111"
            },
        };

        public const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    }
}
