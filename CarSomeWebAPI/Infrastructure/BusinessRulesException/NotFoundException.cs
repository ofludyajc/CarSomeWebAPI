using System.Net;

namespace CarSomeWebAPI.Infrastructure.BusinessRulesException
{
    public class NotFoundException : BusinessRulesException
    {
        private const string message = "Record not found";

        public NotFoundException() : base(HttpStatusCode.NotFound, message) { }
    }
}
