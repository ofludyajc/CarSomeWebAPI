using System.Net;

namespace CarSomeWebAPI.Infrastructure.BusinessRulesException
{
    public class InvalidHoursException : BusinessRulesException
    {
        private const string message = "Invalid working hours, please pick from 9AM to 6PM only.";

        public InvalidHoursException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
