﻿using CarSomeWebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSomeWebAPI.Infrastructure.Dto
{
    public class AppointmentDto
    {
        public string AppointmentID { get; set; }

        public int InspectionCenterID { get; set; }

        public string CustomerID { get; set; }

        public DateTime InspectionDate { get; set; }

        public virtual InspectionCenter InspectionCentre { get; set; }

        public virtual Customer CustomerInfo { get; set; }
    }
}
