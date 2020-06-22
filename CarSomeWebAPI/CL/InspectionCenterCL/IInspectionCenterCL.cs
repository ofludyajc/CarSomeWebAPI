using CarSomeWebAPI.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.CL.InspectionCenterCL
{
    public interface IInspectionCenterCL
    {
        Task<List<InspectionCenterDto>> GetInspectionCenters();

        Task<InspectionCenterDto> GetInspectionCenterByID(int ID);

        Task<int> CreateInspectionCenter(InspectionCenterDto inspectionCenterDto);

        Task<int> UpdateInspectionCenter(int ID, InspectionCenterDto inspectionCenterDto);

        Task<int> DeleteInspectionCenter(int ID);
    }
}
