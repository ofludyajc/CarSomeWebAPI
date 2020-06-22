using CarSomeWebAPI.Infrastructure.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarSomeWebAPI.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarSomeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionCenterController : ControllerBase
    {
        private readonly IInspectionCenterService inspectionCenterService;

        public InspectionCenterController(IInspectionCenterService inspectionCenterService)
        {
            this.inspectionCenterService = inspectionCenterService;
        }

        [HttpGet("GetInpsectionCenters")]
        public async Task<ActionResult<IEnumerable<InspectionCenterDto>>> GetInspectionCenters()
        {
            var result = await inspectionCenterService.GetInspectionCenters();

            return result;
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<InspectionCenterDto>> GetInspectionCenterByID(int ID)
        {
            var result = await inspectionCenterService.GetInspectionCenterByID(ID);

            return result;
        }

        [HttpPost("CreateInpsectionCenters")]
        public async Task<int> CreateInspectionCenter([FromBody] InspectionCenterDto inspectionCenterDto)
        {
            var result = await inspectionCenterService.CreateInspectionCenter(inspectionCenterDto);

            return result;
        }

        [HttpPut("UpdateInpsectionCenters/{ID}")]
        public async Task<int> UpdateInspectionCenter(int ID, [FromBody] InspectionCenterDto inspectionCenterDto)
        {
            var result = await inspectionCenterService.UpdateInspectionCenter(ID, inspectionCenterDto);

            return result;
        }

        [HttpDelete("DeleteInpsectionCenters/{ID}")]
        public async Task<int> DeleteInspectionCenter(int ID)
        {
            var result = await inspectionCenterService.DeleteInspectionCenter(ID);

            return result;
        }
    }
}