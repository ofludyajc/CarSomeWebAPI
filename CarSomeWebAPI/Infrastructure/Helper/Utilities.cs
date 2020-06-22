using CarSomeWebAPI.Common;
using System;
using System.Linq;

namespace CarSomeWebAPI.Infrastructure.Helper
{
    public class Utilities
    {
        private static readonly Random random = new Random();

        public string GenerateAppointmentID()
        {
            string randomString = GenerateRandomID();
            string dateToday = DateTime.Now.ToString("yyyyMMdd");
            return dateToday + randomString;
        }

        public string GenerateCustomerID()
        {
            string randomString = GenerateRandomID();
            string dateToday = DateTime.Now.ToString("yyyyMMdd");
            return dateToday + randomString;
        }

        public string GenerateCarDetailsID()
        {
            string randomString = GenerateRandomID();
            string dateToday = DateTime.Now.ToString("yyyyMMdd");
            return dateToday + randomString;
        }

        private string GenerateRandomID()
        {
            var randomString = Enumerable.Repeat(Constants.chars, 8).Select(s => s[random.Next(s.Length)]).ToArray();
            return new string(randomString);
        }
    }
}
