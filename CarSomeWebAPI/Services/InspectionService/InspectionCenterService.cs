using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.BLL;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSomeWebAPI.Services
{
    public class InspectionCenterService : IInspectionCenterService
    {
        private readonly IInspectionCenterBLL _inspectionCenterBLL; //{ get; set; }

        public InspectionCenterService(IInspectionCenterBLL inspectionCenterBLL)
        {
            _inspectionCenterBLL = inspectionCenterBLL;
        }

        public async Task<List<InspectionCenterDto>> GetInspectionCenters()
        {
            var result = await _inspectionCenterBLL.GetInspectionCenters();

            return result;
        }

        public async Task<InspectionCenterDto> GetInspectionCenterByID(int ID)
        {
            var result = await _inspectionCenterBLL.GetInspectionCenterByID(ID);

            return result;
        }

        public async Task<int> CreateInspectionCenter(InspectionCenterDto inspectionCenterDto)
        {
            var result = await _inspectionCenterBLL.CreateInspectionCenter(inspectionCenterDto);

            return result;
        }

        public async Task<int> UpdateInspectionCenter(int ID, InspectionCenterDto inspectionCenterDto)
        {
            var result = await _inspectionCenterBLL.UpdateInspectionCenter(ID, inspectionCenterDto);

            return result;
        }

        public async Task<int> DeleteInspectionCenter(int ID)
        {
            var result = await _inspectionCenterBLL.DeleteInspectionCenter(ID);

            return result;
        }
    }
}
