using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSomeWebAPI.Infrastructure.Dto
{
    public class InspectionCenterDto
    {
        public int InspectionCenterID { get; set; }

        public string ICName { get; set; }

        public string ICAddress { get; set; }

        public string ICContactNumber { get; set; }
    }
}
