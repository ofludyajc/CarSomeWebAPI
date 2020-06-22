using System.Net;

namespace CarSomeWebAPI.Infrastructure.BusinessRulesException
{
    public class InvalidDateException : BusinessRulesException
    {
        private const string message = "Invalid date, please pick from Monday to Saturday only.";

        public InvalidDateException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
