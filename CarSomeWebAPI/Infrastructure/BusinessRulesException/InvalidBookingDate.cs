using System.Net;

namespace CarSomeWebAPI.Infrastructure.BusinessRulesException
{
    public class InvalidBookingDate : BusinessRulesException
    {
        private const string message = "Invalid booking date, please book 2 weeks in advance.";

        public InvalidBookingDate() : base(HttpStatusCode.BadRequest, message) { }
    }
}
