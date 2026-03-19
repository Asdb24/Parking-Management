using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class VehicleBLL
    {
        private readonly VehicleDAL _vehicleDAL;

        public VehicleBLL()
        {
            _vehicleDAL = new VehicleDAL();
        }

        public List<VehicleDTO> GetAll()
        {
            return _vehicleDAL.GetAll();
        }

        public VehicleDTO GetById(int vehicleId)
        {
            return _vehicleDAL.GetById(vehicleId);
        }

        public VehicleDTO GetByLicensePlate(string licensePlate)
        {
            return _vehicleDAL.GetByLicensePlate(licensePlate);
        }

        public VehicleDTO GetByCardNumber(string cardNumber)
        {
            return _vehicleDAL.GetByCardNumber(cardNumber);
        }

        public List<VehicleDTO> Search(string searchText)
        {
            return _vehicleDAL.Search(searchText);
        }

        public List<VehicleDTO> GetByApartment(int apartmentId)
        {
            return _vehicleDAL.GetByApartment(apartmentId);
        }

        public int Insert(VehicleDTO vehicle)
        {
            // Validate
            if (vehicle.ResidentID <= 0)
                throw new Exception("Vui lòng chọn chủ xe!");
            
            if (vehicle.VehicleTypeID <= 0)
                throw new Exception("Vui lòng chọn loại xe!");
            
            if (string.IsNullOrEmpty(vehicle.LicensePlate))
                throw new Exception("Biển số xe không được để trống!");
            
            // Validate biển số Việt Nam
            if (!IsValidLicensePlate(vehicle.LicensePlate))
                throw new Exception("Biển số xe không hợp lệ!");
            
            if (_vehicleDAL.IsLicensePlateExists(vehicle.LicensePlate))
                throw new Exception("Biển số xe đã tồn tại trong hệ thống!");

            vehicle.RegistrationDate = DateTime.Now;
            vehicle.Status = "Hoạt động";
            
            return _vehicleDAL.Insert(vehicle);
        }

        public bool Update(VehicleDTO vehicle)
        {
            if (vehicle.ResidentID <= 0)
                throw new Exception("Vui lòng chọn chủ xe!");
            
            if (vehicle.VehicleTypeID <= 0)
                throw new Exception("Vui lòng chọn loại xe!");
            
            if (string.IsNullOrEmpty(vehicle.LicensePlate))
                throw new Exception("Biển số xe không được để trống!");
            
            if (_vehicleDAL.IsLicensePlateExists(vehicle.LicensePlate, vehicle.VehicleID))
                throw new Exception("Biển số xe đã tồn tại trong hệ thống!");

            return _vehicleDAL.Update(vehicle);
        }

        public bool Delete(int vehicleId)
        {
            return _vehicleDAL.Delete(vehicleId);
        }

        /// <summary>
        /// Validate biển số xe Việt Nam
        /// </summary>
        private bool IsValidLicensePlate(string licensePlate)
        {
            // Pattern: 2 số + 1 chữ + 1 dấu gạch + 4-5 số
            // Ví dụ: 51A-12345, 30E-1234
            string pattern = @"^\d{2}[A-Z]-\d{4,5}$";
            return Regex.IsMatch(licensePlate.ToUpper(), pattern);
        }
    }
}
