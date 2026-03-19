using System;
using System.Collections.Generic;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class ParkingZoneBLL
    {
        private readonly ParkingZoneDAL _zoneDAL;

        public ParkingZoneBLL()
        {
            _zoneDAL = new ParkingZoneDAL();
        }

        public List<ParkingZoneDTO> GetAll()
        {
            return _zoneDAL.GetAll();
        }

        public ParkingZoneDTO GetById(int zoneId)
        {
            return _zoneDAL.GetById(zoneId);
        }

        public int Insert(ParkingZoneDTO zone)
        {
            if (string.IsNullOrEmpty(zone.ZoneCode))
                throw new Exception("Mã khu vực không được để trống!");
            
            if (string.IsNullOrEmpty(zone.ZoneName))
                throw new Exception("Tên khu vực không được để trống!");

            return _zoneDAL.Insert(zone);
        }

        public bool Update(ParkingZoneDTO zone)
        {
            if (string.IsNullOrEmpty(zone.ZoneCode))
                throw new Exception("Mã khu vực không được để trống!");
            
            if (string.IsNullOrEmpty(zone.ZoneName))
                throw new Exception("Tên khu vực không được để trống!");

            return _zoneDAL.Update(zone);
        }

        public bool Delete(int zoneId)
        {
            return _zoneDAL.Delete(zoneId);
        }
    }
}
