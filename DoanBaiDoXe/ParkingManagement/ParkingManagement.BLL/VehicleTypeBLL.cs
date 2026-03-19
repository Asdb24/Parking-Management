using System;
using System.Collections.Generic;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class VehicleTypeBLL
    {
        private readonly VehicleTypeDAL _vehicleTypeDAL;

        public VehicleTypeBLL()
        {
            _vehicleTypeDAL = new VehicleTypeDAL();
        }

        public List<VehicleTypeDTO> GetAll()
        {
            return _vehicleTypeDAL.GetAll();
        }

        public VehicleTypeDTO GetById(int vehicleTypeId)
        {
            return _vehicleTypeDAL.GetById(vehicleTypeId);
        }

        public int Insert(VehicleTypeDTO vehicleType)
        {
            if (string.IsNullOrEmpty(vehicleType.TypeName))
                throw new Exception("Tên loại xe không được để trống!");

            return _vehicleTypeDAL.Insert(vehicleType);
        }

        public bool Update(VehicleTypeDTO vehicleType)
        {
            if (string.IsNullOrEmpty(vehicleType.TypeName))
                throw new Exception("Tên loại xe không được để trống!");

            return _vehicleTypeDAL.Update(vehicleType);
        }

        public bool Delete(int vehicleTypeId)
        {
            return _vehicleTypeDAL.Delete(vehicleTypeId);
        }
    }
}
