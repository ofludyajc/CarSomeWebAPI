using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.CL.CarDetailsCL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.BLL.CarDetailsBLL
{
    public class CarDetailsBLL : ICarDetailsBLL
    {
        private readonly ICarDetailsCL carDetailsCL;

        public CarDetailsBLL(ICarDetailsCL carDetailsCL)
        {
            this.carDetailsCL = carDetailsCL;
        }

        public async Task<List<CarDetailsDto>> GetCarDetailsList()
        {
            var carDetailsList = await carDetailsCL.GetCarDetailsList();

            return carDetailsList;
        }

        public async Task<CarDetailsDto> GetCarDetailsByID(string ID)
        {
            var carDetails = await carDetailsCL.GetCarDetailsByID(ID);

            return carDetails;
        }

        public async Task<string> CreateCarDetails(CarDetailsDto carDetailsDto)
        {
            var carDetailsID = await carDetailsCL.CreateCarDetails(carDetailsDto);

            return carDetailsID;
        }

        public async Task<string> UpdateCarDetails(string ID, CarDetailsDto carDetailsDto)
        {
            var carDetailsID = await carDetailsCL.UpdateCarDetails(ID, carDetailsDto);

            return carDetailsID;
        }

        public async Task<string> DeleteCarDetails(string ID)
        {
            var carDetailsID = await carDetailsCL.DeleteCarDetails(ID);

            return carDetailsID;
        }
    }
}
