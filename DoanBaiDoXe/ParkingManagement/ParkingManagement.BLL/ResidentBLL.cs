using System;
using System.Collections.Generic;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class ResidentBLL
    {
        private readonly ResidentDAL _residentDAL;

        public ResidentBLL()
        {
            _residentDAL = new ResidentDAL();
        }

        public List<ResidentDTO> GetAll()
        {
            return _residentDAL.GetAll();
        }

        public List<ResidentDTO> GetByApartment(int apartmentId)
        {
            return _residentDAL.GetByApartment(apartmentId);
        }

        public ResidentDTO GetById(int residentId)
        {
            return _residentDAL.GetById(residentId);
        }

        public int Insert(ResidentDTO resident)
        {
            if (resident.ApartmentID <= 0)
                throw new Exception("Vui lòng chọn căn hộ!");
            
            if (string.IsNullOrEmpty(resident.FullName))
                throw new Exception("Họ tên không được để trống!");

            return _residentDAL.Insert(resident);
        }

        public bool Update(ResidentDTO resident)
        {
            if (resident.ApartmentID <= 0)
                throw new Exception("Vui lòng chọn căn hộ!");
            
            if (string.IsNullOrEmpty(resident.FullName))
                throw new Exception("Họ tên không được để trống!");

            return _residentDAL.Update(resident);
        }

        public bool Delete(int residentId)
        {
            return _residentDAL.Delete(residentId);
        }
    }
}
