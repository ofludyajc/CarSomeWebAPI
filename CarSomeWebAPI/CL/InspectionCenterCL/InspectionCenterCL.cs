using CarSomeWebAPI.Infrastructure.Dto;
using CarSomeWebAPI.Infrastructure.BusinessRulesException;
using CarSomeWebAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Caching;
using CarSomeWebAPI.Data.Entities;
using AutoMapper;

namespace CarSomeWebAPI.CL.InspectionCenterCL
{
    public class InspectionCenterCL : IInspectionCenterCL
    {
        private readonly IMapper mapper;
        ObjectCache cache = MemoryCache.Default;
        private readonly Constants constants = new Constants();

        public InspectionCenterCL(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<List<InspectionCenterDto>> GetInspectionCenters()
        {
            var inspectionCenters = new List<InspectionCenter>();
            var cacheKey = CacheKeys.InspectionCenterCacheKeys.INSPECTIONCENTERS;
            var icCached = (List<InspectionCenter>)cache.Get(cacheKey);

            if (icCached == null)
            {
                var ics = await Task.Run(() => constants.inspectionCenters);
                cache.Set(cacheKey, ics, DateTime.Now.AddMinutes(60), null);
                inspectionCenters = ics;
            }

            else
            {
                inspectionCenters = icCached;
            }

            return mapper.Map<List<InspectionCenterDto>>(inspectionCenters);
        }

        public async Task<InspectionCenterDto> GetInspectionCenterByID(int ID)
        {
            var cacheKey = CacheKeys.InspectionCenterCacheKeys.INSPECTIONCENTERS;
            var icCached = (List<InspectionCenter>)cache.Get(cacheKey);
            var icByID = new InspectionCenter();

            if (icCached == null)
            {
                var ics = await Task.Run(() => constants.inspectionCenters);
                icByID = ics.SingleOrDefault(ic => ic.InspectionCenterID == ID);

                if (icByID == null)
                {
                    throw new NotFoundException();
                }

                cache.Set(cacheKey, ics, DateTime.Now.AddMinutes(60), null);
            }

            else
            {
                icByID = icCached.SingleOrDefault(ic => ic.InspectionCenterID == ID);

                if (icByID == null)
                {
                    throw new NotFoundException();
                }
            }

            return mapper.Map<InspectionCenterDto>(icByID);
        }

        public async Task<int> CreateInspectionCenter(InspectionCenterDto inspectionCenterDto)
        {
            var inspectionCenters = new List<InspectionCenter>();
            var cacheKey = CacheKeys.InspectionCenterCacheKeys.INSPECTIONCENTERS;
            var icCached = (List<InspectionCenter>)cache.Get(cacheKey);
            var icByID = new InspectionCenter();

            if (icCached == null)
            {
                var ics = await Task.Run(() => constants.inspectionCenters);
                icByID = ics.SingleOrDefault(ic => ic.InspectionCenterID == inspectionCenterDto.InspectionCenterID);
                
                if (icByID != null)
                {
                    throw new RecordExistingException();
                }
                
                var entity = PopulateInspectionCenter(inspectionCenterDto);

                ics.Add(entity);
                cache.Set(cacheKey, ics, DateTime.Now.AddMinutes(60), null);
                inspectionCenters = ics;
            }

            else
            {
                icByID = icCached.SingleOrDefault(ic => ic.InspectionCenterID == inspectionCenterDto.InspectionCenterID);

                if (icByID != null)
                {
                    throw new RecordExistingException();
                }

                var entity = PopulateInspectionCenter(inspectionCenterDto);
                inspectionCenters.AddRange(icCached);
                inspectionCenters.Add(entity);
                cache.Set(cacheKey, inspectionCenters, DateTime.Now.AddMinutes(60), null);
            }

            return inspectionCenterDto.InspectionCenterID;
        }

        public async Task<int> UpdateInspectionCenter(int ID, InspectionCenterDto inspectionCenterDto)
        {
            var cacheKey = CacheKeys.InspectionCenterCacheKeys.INSPECTIONCENTERS;
            var icCached = (List<InspectionCenter>)cache.Get(cacheKey);
            var icByID = new InspectionCenter();

            if (icCached == null)
            {
                var ics = await Task.Run(() => constants.inspectionCenters);
                icByID = ics.FirstOrDefault(ic => ic.InspectionCenterID == ID);

                if (icByID == null)
                {
                    throw new NotFoundException();
                }

                var entity = UpdateInspectionCenter(inspectionCenterDto, icByID);

                ics.Remove(icByID);
                ics.Add(entity);
                cache.Set(cacheKey, ics, DateTime.Now.AddMinutes(60), null);
            }

            else
            {
                icByID = icCached.SingleOrDefault(ic => ic.InspectionCenterID == ID);

                if (icByID == null)
                {
                    throw new NotFoundException();
                }

                var entity = UpdateInspectionCenter(inspectionCenterDto, icByID);

                icCached.Remove(icByID);
                icCached.Add(entity);
                cache.Set(cacheKey, icCached, DateTime.Now.AddMinutes(60), null);
            }

            return inspectionCenterDto.InspectionCenterID;
        }

        public async Task<int> DeleteInspectionCenter(int ID)
        {
            var cacheKey = CacheKeys.InspectionCenterCacheKeys.INSPECTIONCENTERS;
            var icCached = (List<InspectionCenter>)cache.Get(cacheKey);
            var icByID = new InspectionCenter();

            if (icCached == null)
            {
                var ics = await Task.Run(() => constants.inspectionCenters);
                icByID = ics.SingleOrDefault(ic => ic.InspectionCenterID == ID);

                if (icByID == null)
                {
                    throw new NotFoundException();
                }

                ics.Remove(icByID);
                cache.Set(cacheKey, ics, DateTime.Now.AddMinutes(60), null);
            }

            else
            {
                icByID = icCached.SingleOrDefault(ic => ic.InspectionCenterID == ID);

                if (icByID == null)
                {
                    throw new NotFoundException();
                }

                icCached.Remove(icByID);
                cache.Set(cacheKey, icCached, DateTime.Now.AddMinutes(60), null);
            }

            return ID;
        }

        private static InspectionCenter PopulateInspectionCenter(InspectionCenterDto inspectionCenterDto)
        {
            var entity = new InspectionCenter()
            {
                InspectionCenterID = inspectionCenterDto.InspectionCenterID,
                ICName = inspectionCenterDto.ICName,
                ICAddress = inspectionCenterDto.ICAddress,
                ICContactNumber = inspectionCenterDto.ICContactNumber
            };

            return entity;
        }

        private static InspectionCenter UpdateInspectionCenter(InspectionCenterDto inspectionCenterDto, InspectionCenter inspectionCenter)
        {
            inspectionCenter.ICName = inspectionCenterDto.ICName;
            inspectionCenter.ICAddress = inspectionCenterDto.ICAddress;
            inspectionCenter.ICContactNumber = inspectionCenterDto.ICContactNumber;

            return inspectionCenter;
        }
    }
}
