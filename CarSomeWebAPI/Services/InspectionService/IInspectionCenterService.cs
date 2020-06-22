using CarSomeWebAPI.Infrastructure.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSomeWebAPI.Services
{
    public interface IInspectionCenterService
    {
        Task<List<InspectionCenterDto>> GetInspectionCenters();

        Task<InspectionCenterDto> GetInspectionCenterByID(int ID);

        Task<int> CreateInspectionCenter(InspectionCenterDto inspectionCenterDto);

        Task<int> UpdateInspectionCenter(int ID, InspectionCenterDto inspectionCenterDto);

        Task<int> DeleteInspectionCenter(int ID);
    }
}
