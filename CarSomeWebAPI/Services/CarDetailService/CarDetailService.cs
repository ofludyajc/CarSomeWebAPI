using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.BLL.CarDetailsBLL;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSomeWebAPI.Services.CarDetailService
{
    public class CarDetailService : ICarDetailService
    {
        private readonly ICarDetailsBLL _carDetailsBLL;

        public CarDetailService(ICarDetailsBLL carDetailsBLL)
        {
            _carDetailsBLL = carDetailsBLL;
        }

        public async Task<List<CarDetailsDto>> GetCarDetailsList()
        {
            var result = await _carDetailsBLL.GetCarDetailsList();

            return result;
        }

        public async Task<CarDetailsDto> GetCarDetailsByID(string ID)
        {
            var result = await _carDetailsBLL.GetCarDetailsByID(ID);

            return result;
        }

        public async Task<string> CreateCarDetails(CarDetailsDto carDetailsDto)
        {
            var result = await _carDetailsBLL.CreateCarDetails(carDetailsDto);

            return result;
        }

        public async Task<string> UpdateCarDetails(string ID, CarDetailsDto carDetailsDto)
        {
            var result = await _carDetailsBLL.UpdateCarDetails(ID, carDetailsDto);

            return result;
        }

        public async Task<string> DeleteCarDetails(string ID)
        {
            var result = await _carDetailsBLL.DeleteCarDetails(ID);

            return result;
        }
    }
}
