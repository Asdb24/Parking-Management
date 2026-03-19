using System;
using System.Collections.Generic;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class BuildingBLL
    {
        private readonly BuildingDAL _buildingDAL;

        public BuildingBLL()
        {
            _buildingDAL = new BuildingDAL();
        }

        public List<BuildingDTO> GetAll()
        {
            return _buildingDAL.GetAll();
        }

        public BuildingDTO GetById(int buildingId)
        {
            return _buildingDAL.GetById(buildingId);
        }

        public int Insert(BuildingDTO building)
        {
            // Validate
            if (string.IsNullOrEmpty(building.BuildingCode))
                throw new Exception("Mã tòa nhà không được để trống!");
            
            if (string.IsNullOrEmpty(building.BuildingName))
                throw new Exception("Tên tòa nhà không được để trống!");
            
            if (_buildingDAL.IsCodeExists(building.BuildingCode))
                throw new Exception("Mã tòa nhà đã tồn tại!");

            return _buildingDAL.Insert(building);
        }

        public bool Update(BuildingDTO building)
        {
            if (string.IsNullOrEmpty(building.BuildingCode))
                throw new Exception("Mã tòa nhà không được để trống!");
            
            if (string.IsNullOrEmpty(building.BuildingName))
                throw new Exception("Tên tòa nhà không được để trống!");
            
            if (_buildingDAL.IsCodeExists(building.BuildingCode, building.BuildingID))
                throw new Exception("Mã tòa nhà đã tồn tại!");

            return _buildingDAL.Update(building);
        }

        public bool Delete(int buildingId)
        {
            return _buildingDAL.Delete(buildingId);
        }
    }
}
