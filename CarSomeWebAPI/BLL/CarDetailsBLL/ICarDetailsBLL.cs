using CarSomeWebAPI.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.BLL.CarDetailsBLL
{
    public interface ICarDetailsBLL
    {
        Task<List<CarDetailsDto>> GetCarDetailsList();

        Task<CarDetailsDto> GetCarDetailsByID(string ID);

        Task<string> CreateCarDetails(CarDetailsDto customerDto);

        Task<string> UpdateCarDetails(string ID, CarDetailsDto customerDto);

        Task<string> DeleteCarDetails(string ID);
    }
}
