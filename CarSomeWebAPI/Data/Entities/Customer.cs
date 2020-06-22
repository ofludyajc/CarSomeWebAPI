
namespace CarSomeWebAPI.Data.Entities
{
    public class Customer
    {
        public string CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string ContactInfo { get; set; }

        public virtual CarDetails CarDetails { get; set; }

    }
}
