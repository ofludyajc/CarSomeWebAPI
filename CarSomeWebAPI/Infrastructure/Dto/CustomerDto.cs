
using CarSomeWebAPI.Data.Entities;

namespace CarSomeWebAPI.Infrastructure.Dto
{
    public class CustomerDto
    {
        public string CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string ContactInfo { get; set; }

        public virtual CarDetails CarDetails { get; set; }
    }
}
