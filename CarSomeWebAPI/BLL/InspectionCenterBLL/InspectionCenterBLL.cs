using CarSomeWebAPI.CL.InspectionCenterCL;
using CarSomeWebAPI.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSomeWebAPI.BLL
{
    public class InspectionCenterBLL : IInspectionCenterBLL
    {
        private readonly IInspectionCenterCL inspectionCenterCL;

        public InspectionCenterBLL(IInspectionCenterCL inspectionCenterCL)
        {
            this.inspectionCenterCL = inspectionCenterCL;
        }

        public async Task<List<InspectionCenterDto>> GetInspectionCenters()
        {
            var inspectionCenters = await inspectionCenterCL.GetInspectionCenters();

            return inspectionCenters;
        }

        public async Task<InspectionCenterDto> GetInspectionCenterByID(int ID)
        {
            var inspectionCenter = await inspectionCenterCL.GetInspectionCenterByID(ID);

            return inspectionCenter;
        }

        public async Task<int> CreateInspectionCenter(InspectionCenterDto inspectionCenterDto)
        {
            var entity = await inspectionCenterCL.CreateInspectionCenter(inspectionCenterDto);

            return entity;
        }

        public async Task<int> UpdateInspectionCenter(int ID, InspectionCenterDto inspectionCenterDto)
        {
            var entity = await inspectionCenterCL.UpdateInspectionCenter(ID, inspectionCenterDto);

            return entity;
        }

        public async Task<int> DeleteInspectionCenter(int ID)
        {
            var entity = await inspectionCenterCL.DeleteInspectionCenter(ID);

            return entity;
        }
    }
}
