using System.Net;

namespace CarSomeWebAPI.Infrastructure.BusinessRulesException
{
    public class ScheduleFullException : BusinessRulesException
    {
        private const string message = "Slot already full, please pick another schedule";

        public ScheduleFullException() : base(HttpStatusCode.NotFound, message) { }
    }
}
