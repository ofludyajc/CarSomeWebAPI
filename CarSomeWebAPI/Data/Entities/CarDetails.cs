using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSomeWebAPI.Data.Entities
{
    public class CarDetails
    {
        public string CarDetailID { get; set; }

        public string CustomerID { get; set; }

        public string CarInformation { get; set; }

        public virtual Customer CustomerInfo { get; set; }
    }
}
