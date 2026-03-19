using System;
using System.Collections.Generic;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class ApartmentBLL
    {
        private readonly ApartmentDAL _apartmentDAL;

        public ApartmentBLL()
        {
            _apartmentDAL = new ApartmentDAL();
        }

        public List<ApartmentDTO> GetAll()
        {
            return _apartmentDAL.GetAll();
        }

        public List<ApartmentDTO> GetByBuilding(int buildingId)
        {
            return _apartmentDAL.GetByBuilding(buildingId);
        }

        public ApartmentDTO GetById(int apartmentId)
        {
            return _apartmentDAL.GetById(apartmentId);
        }

        public List<ApartmentDTO> Search(string keyword, int? buildingId = null)
        {
            return _apartmentDAL.Search(keyword, buildingId);
        }

        public int Insert(ApartmentDTO apartment)
        {
            // Validate
            if (apartment.BuildingID <= 0)
                throw new Exception("Vui lòng chọn tòa nhà!");
            
            if (string.IsNullOrEmpty(apartment.ApartmentCode))
                throw new Exception("Mã căn hộ không được để trống!");
            
            if (string.IsNullOrEmpty(apartment.ApartmentNumber))
                throw new Exception("Số căn hộ không được để trống!");
            
            if (apartment.Floor <= 0)
                throw new Exception("Tầng phải lớn hơn 0!");

            return _apartmentDAL.Insert(apartment);
        }

        public bool Update(ApartmentDTO apartment)
        {
            if (apartment.BuildingID <= 0)
                throw new Exception("Vui lòng chọn tòa nhà!");
            
            if (string.IsNullOrEmpty(apartment.ApartmentCode))
                throw new Exception("Mã căn hộ không được để trống!");
            
            if (string.IsNullOrEmpty(apartment.ApartmentNumber))
                throw new Exception("Số căn hộ không được để trống!");

            return _apartmentDAL.Update(apartment);
        }

        public bool Delete(int apartmentId)
        {
            return _apartmentDAL.Delete(apartmentId);
        }
    }
}
