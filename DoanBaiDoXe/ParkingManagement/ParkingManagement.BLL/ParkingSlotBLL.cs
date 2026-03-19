using System;
using System.Collections.Generic;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class ParkingSlotBLL
    {
        private readonly ParkingSlotDAL _slotDAL;

        public ParkingSlotBLL()
        {
            _slotDAL = new ParkingSlotDAL();
        }

        public List<ParkingSlotDTO> GetAll()
        {
            return _slotDAL.GetAll();
        }

        public List<ParkingSlotDTO> GetByZone(int zoneId)
        {
            return _slotDAL.GetByZone(zoneId);
        }

        public List<ParkingSlotDTO> GetAvailableSlots()
        {
            return _slotDAL.GetAvailableSlots();
        }

        public ParkingSlotDTO GetById(int slotId)
        {
            return _slotDAL.GetById(slotId);
        }

        public bool UpdateStatus(int slotId, string status)
        {
            // Validate status
            string[] validStatuses = { "Trống", "Có xe", "Bảo trì", "Đã đăng ký" };
            bool isValid = false;
            foreach (var s in validStatuses)
            {
                if (s == status) { isValid = true; break; }
            }
            
            if (!isValid)
                throw new Exception("Trạng thái không hợp lệ!");
            
            return _slotDAL.UpdateStatus(slotId, status);
        }

        public int Insert(ParkingSlotDTO slot)
        {
            if (slot.ZoneID <= 0)
                throw new Exception("Vui lòng chọn khu vực!");
            
            if (string.IsNullOrEmpty(slot.SlotCode))
                throw new Exception("Mã chỗ đậu không được để trống!");
            
            if (string.IsNullOrEmpty(slot.SlotNumber))
                throw new Exception("Số chỗ đậu không được để trống!");

            return _slotDAL.Insert(slot);
        }

        public bool Update(ParkingSlotDTO slot)
        {
            if (slot.ZoneID <= 0)
                throw new Exception("Vui lòng chọn khu vực!");
            
            if (string.IsNullOrEmpty(slot.SlotCode))
                throw new Exception("Mã chỗ đậu không được để trống!");

            return _slotDAL.Update(slot);
        }

        public bool Delete(int slotId)
        {
            return _slotDAL.Delete(slotId);
        }

        public Dictionary<string, int> GetSlotCountByStatus()
        {
            return _slotDAL.GetSlotCountByStatus();
        }
    }
}
