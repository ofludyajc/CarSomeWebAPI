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
using CarSomeWebAPI.Infrastructure.Helper;

namespace CarSomeWebAPI.CL.CarDetailsCL
{
    public class CarDetailsCL : ICarDetailsCL
    {
        private readonly IMapper mapper;
        ObjectCache cache = MemoryCache.Default;
        Utilities util = new Utilities();

        public CarDetailsCL(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<List<CarDetailsDto>> GetCarDetailsList()
        {
            var carDetailsList = new List<CarDetails>();
            var cacheKey = CacheKeys.CarDetailsCacheKeys.CARDETAILS;
            var cdCached = (List<CarDetails>)cache.Get(cacheKey);

            if (cdCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                carDetailsList = cdCached;
            }

            await Task.CompletedTask;

            return mapper.Map<List<CarDetailsDto>>(carDetailsList);
        }

        public async Task<CarDetailsDto> GetCarDetailsByID(string ID)
        {
            var cacheKey = CacheKeys.CarDetailsCacheKeys.CARDETAILS;
            var cdCached = (List<CarDetails>)cache.Get(cacheKey);
            var cdByID = new CarDetails();

            if (cdCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                cdByID = cdCached.SingleOrDefault(ic => ic.CarDetailID == ID);

                if (cdByID == null)
                {
                    throw new NotFoundException();
                }
            }

            await Task.CompletedTask;

            return mapper.Map<CarDetailsDto>(cdByID);
        }

        public async Task<string> GetCarDetailIDByID(string ID)
        {
            var cacheKey = CacheKeys.CarDetailsCacheKeys.CARDETAILS;
            var cdCached = (List<CarDetails>)cache.Get(cacheKey);
            var cdByID = new CarDetails();

            if (cdCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                cdByID = cdCached.SingleOrDefault(ic => ic.CarDetailID == ID);

                if (cdByID == null)
                {
                    throw new NotFoundException();
                }
            }

            await Task.CompletedTask;

            return ID;
        }

        public async Task<string> CreateCarDetails(CarDetailsDto carDetailsDto)
        {
            var carDetailsList = new List<CarDetails>();
            var cacheKey = CacheKeys.CarDetailsCacheKeys.CARDETAILS;
            var cdCached = (List<CarDetails>)cache.Get(cacheKey);
            var cdByID = new CarDetails();

            if (cdCached == null)
            {
                var entity = PopulateCarDetails(carDetailsDto);
                carDetailsList.Add(entity);
                cache.Set(cacheKey, carDetailsList, DateTime.Now.AddMinutes(60), null);
                cdByID = entity;
            }

            else
            {
                cdByID = cdCached.SingleOrDefault(ic => ic.CarDetailID == carDetailsDto.CarDetailID);

                if (cdByID != null)
                {
                    throw new RecordExistingException();
                }

                var entity = PopulateCarDetails(carDetailsDto);
                carDetailsList.AddRange(cdCached);
                carDetailsList.Add(entity);
                cache.Set(cacheKey, carDetailsList, DateTime.Now.AddMinutes(60), null);
                cdByID = entity;
            }

            await Task.CompletedTask;

            return cdByID.CarDetailID;
        }

        public async Task<string> UpdateCarDetails(string ID, CarDetailsDto carDetailsDto)
        {
            var cacheKey = CacheKeys.CarDetailsCacheKeys.CARDETAILS;
            var cdCached = (List<CarDetails>)cache.Get(cacheKey);
            var cdByID = new CarDetails();

            if (cdCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                cdByID = cdCached.SingleOrDefault(ic => ic.CarDetailID == ID);

                if (cdByID == null)
                {
                    throw new NotFoundException();
                }

                var entity = UpdateCarDetails(carDetailsDto, cdByID);

                cdCached.Remove(cdByID);
                cdCached.Add(entity);
                cache.Set(cacheKey, cdCached, DateTime.Now.AddMinutes(60), null);
            }

            await Task.CompletedTask;

            return ID;
        }

        public async Task<string> DeleteCarDetails(string ID)
        {
            var cacheKey = CacheKeys.CarDetailsCacheKeys.CARDETAILS;
            var cdCached = (List<CarDetails>)cache.Get(cacheKey);
            var cdByID = new CarDetails();

            if (cdCached == null)
            {
                throw new NotFoundException();
            }

            else
            {
                cdByID = cdCached.SingleOrDefault(ic => ic.CarDetailID == ID);

                if (cdByID == null)
                {
                    throw new NotFoundException();
                }

                cdCached.Remove(cdByID);
                cache.Set(cacheKey, cdCached, DateTime.Now.AddMinutes(60), null);
            }

            await Task.CompletedTask;

            return ID;
        }

        private CarDetails PopulateCarDetails(CarDetailsDto carDetailsDto)
        {
            var entity = new CarDetails()
            {
                CarDetailID = util.GenerateCarDetailsID(),
                CustomerID = util.GenerateCustomerID(),
                CarInformation = carDetailsDto.CarInformation,
                CustomerInfo = new Customer
                {
                    CustomerName = carDetailsDto.CustomerInfo.CustomerName,
                    ContactInfo = carDetailsDto.CustomerInfo.ContactInfo
                }
            };

            return entity;
        }

        private static CarDetails UpdateCarDetails(CarDetailsDto carDetailsDto, CarDetails carDetails)
        {
            carDetails.CarDetailID = carDetailsDto.CarDetailID;
            carDetails.CustomerID = carDetailsDto.CustomerID;
            carDetails.CarInformation = carDetailsDto.CarInformation;
            carDetails.CustomerInfo.CustomerID = carDetailsDto.CarDetailID;
            carDetails.CustomerInfo.CustomerName = carDetailsDto.CustomerInfo.CustomerName;
            carDetails.CustomerInfo.ContactInfo = carDetailsDto.CustomerInfo.ContactInfo;

            return carDetails;
        }
    }
}
