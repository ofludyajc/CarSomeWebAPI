using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSomeWebAPI.Data.Entities
{
    public class InspectionCenter
    {
        public int InspectionCenterID { get; set; }

        public string ICName { get; set; }

        public string ICAddress { get; set; }

        public string ICContactNumber { get; set; }
    }
}
