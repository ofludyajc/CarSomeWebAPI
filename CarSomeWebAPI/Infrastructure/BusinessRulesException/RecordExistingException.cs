using System.Net;

namespace CarSomeWebAPI.Infrastructure.BusinessRulesException
{
    public class RecordExistingException : BusinessRulesException
    {
        private const string message = "Record already existing.";

        public RecordExistingException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
