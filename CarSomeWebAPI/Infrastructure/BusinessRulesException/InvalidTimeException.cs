using System.Net;

namespace CarSomeWebAPI.Infrastructure.BusinessRulesException
{
    public class InvalidTimeException : BusinessRulesException
    {
        private const string message = "Invalid time, please pick every 30 minutes.";

        public InvalidTimeException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
