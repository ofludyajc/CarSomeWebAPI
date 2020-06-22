using CarSomeWebAPI.Data.Entities;

namespace CarSomeWebAPI.Infrastructure.Dto
{
    public class CarDetailsDto
    {
        public string CarDetailID { get; set; }

        public string CustomerID { get; set; }

        public string CarInformation { get; set; }

        public virtual Customer CustomerInfo { get; set; }
    }
}
