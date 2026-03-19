using System;
using System.Collections.Generic;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class ParkingLogBLL
    {
        private readonly ParkingLogDAL _logDAL;
        private readonly VehicleDAL _vehicleDAL;
        private readonly ParkingSlotDAL _slotDAL;

        public ParkingLogBLL()
        {
            _logDAL = new ParkingLogDAL();
            _vehicleDAL = new VehicleDAL();
            _slotDAL = new ParkingSlotDAL();
        }

        /// <summary>
        /// Check-in xe vào bãi
        /// </summary>
        public int CheckIn(int vehicleId, int? slotId, int checkInBy, string checkInImage = null)
        {
            // Validate vehicle
            var vehicle = _vehicleDAL.GetById(vehicleId);
            if (vehicle == null)
                throw new Exception("Không tìm thấy thông tin xe!");
            
            if (vehicle.Status != "Hoạt động")
                throw new Exception("Xe đang ở trạng thái không hoạt động!");
            
            // Check if vehicle is already in parking
            var existingLog = GetActiveLogByVehicle(vehicleId);
            if (existingLog != null)
                throw new Exception("Xe này đang ở trong bãi!");
            
            return _logDAL.CheckIn(vehicleId, slotId ?? vehicle.SlotID, checkInBy, checkInImage);
        }

        /// <summary>
        /// Check-in bằng biển số
        /// </summary>
        public int CheckInByLicensePlate(string licensePlate, int checkInBy, string checkInImage = null)
        {
            var vehicle = _vehicleDAL.GetByLicensePlate(licensePlate);
            if (vehicle == null)
                throw new Exception($"Không tìm thấy xe có biển số {licensePlate}!");
            
            return CheckIn(vehicle.VehicleID, null, checkInBy, checkInImage);
        }

        /// <summary>
        /// Check-in bằng thẻ xe
        /// </summary>
        public int CheckInByCard(string cardNumber, int checkInBy, string checkInImage = null)
        {
            var vehicle = _vehicleDAL.GetByCardNumber(cardNumber);
            if (vehicle == null)
                throw new Exception($"Không tìm thấy xe có thẻ {cardNumber}!");
            
            return CheckIn(vehicle.VehicleID, null, checkInBy, checkInImage);
        }

        /// <summary>
        /// Check-out xe ra khỏi bãi
        /// </summary>
        public bool CheckOut(int logId, int checkOutBy, string checkOutImage = null)
        {
            return _logDAL.CheckOut(logId, checkOutBy, checkOutImage);
        }

        /// <summary>
        /// Check-out bằng biển số
        /// </summary>
        public bool CheckOutByLicensePlate(string licensePlate, int checkOutBy, string checkOutImage = null)
        {
            var vehicle = _vehicleDAL.GetByLicensePlate(licensePlate);
            if (vehicle == null)
                throw new Exception($"Không tìm thấy xe có biển số {licensePlate}!");
            
            var log = GetActiveLogByVehicle(vehicle.VehicleID);
            if (log == null)
                throw new Exception("Xe này không ở trong bãi!");
            
            return CheckOut(log.LogID, checkOutBy, checkOutImage);
        }

        /// <summary>
        /// Lấy danh sách xe đang trong bãi
        /// </summary>
        public List<ParkingLogDTO> GetVehiclesInParking()
        {
            return _logDAL.GetVehiclesInParking();
        }

        /// <summary>
        /// Lấy lịch sử theo ngày
        /// </summary>
        public List<ParkingLogDTO> GetByDate(DateTime date)
        {
            return _logDAL.GetByDate(date);
        }

        /// <summary>
        /// Lấy log đang active của xe
        /// </summary>
        public ParkingLogDTO GetActiveLogByVehicle(int vehicleId)
        {
            var logs = _logDAL.GetVehiclesInParking();
            foreach (var log in logs)
            {
                if (log.VehicleID == vehicleId)
                    return log;
            }
            return null;
        }

        /// <summary>
        /// Lấy hoạt động gần nhất
        /// </summary>
        public List<ParkingLogDTO> GetRecentActivities(int top = 10)
        {
            return _logDAL.GetRecentActivities(top);
        }
    }
}
