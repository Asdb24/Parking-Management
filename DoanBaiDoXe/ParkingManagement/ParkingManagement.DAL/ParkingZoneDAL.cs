using System;
using System.Collections.Generic;
using System.Linq;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho ParkingZone - Entity Framework
    /// </summary>
    public class ParkingZoneDAL
    {
        public List<ParkingZoneDTO> GetAll()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.ParkingZones
                    .Where(pz => pz.Status == true)
                    .OrderBy(pz => pz.FloorLevel)
                    .ThenBy(pz => pz.ZoneCode)
                    .Select(pz => new ParkingZoneDTO
                    {
                        ZoneID = pz.ZoneID,
                        ZoneCode = pz.ZoneCode,
                        ZoneName = pz.ZoneName,
                        FloorLevel = pz.FloorLevel,
                        TotalSlots = pz.TotalSlots ?? 0,
                        Description = pz.Description,
                        CreatedDate = pz.CreatedDate ?? DateTime.Now,
                        UpdatedDate = pz.UpdatedDate,
                        Status = pz.Status ?? true,
                        AvailableSlots = db.ParkingSlots.Count(ps => ps.ZoneID == pz.ZoneID && ps.SlotStatus == "Trống"),
                        OccupiedSlots = db.ParkingSlots.Count(ps => ps.ZoneID == pz.ZoneID && ps.SlotStatus == "Có xe")
                    })
                    .ToList();
            }
        }

        public ParkingZoneDTO GetById(int zoneId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var pz = db.ParkingZones.Find(zoneId);
                if (pz == null) return null;

                return new ParkingZoneDTO
                {
                    ZoneID = pz.ZoneID,
                    ZoneCode = pz.ZoneCode,
                    ZoneName = pz.ZoneName,
                    FloorLevel = pz.FloorLevel,
                    TotalSlots = pz.TotalSlots ?? 0,
                    Description = pz.Description,
                    CreatedDate = pz.CreatedDate ?? DateTime.Now,
                    UpdatedDate = pz.UpdatedDate,
                    Status = pz.Status ?? true,
                    AvailableSlots = db.ParkingSlots.Count(ps => ps.ZoneID == pz.ZoneID && ps.SlotStatus == "Trống"),
                    OccupiedSlots = db.ParkingSlots.Count(ps => ps.ZoneID == pz.ZoneID && ps.SlotStatus == "Có xe")
                };
            }
        }

        public int Insert(ParkingZoneDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = new ParkingZones
                {
                    ZoneCode = dto.ZoneCode,
                    ZoneName = dto.ZoneName,
                    FloorLevel = dto.FloorLevel,
                    TotalSlots = dto.TotalSlots,
                    Description = dto.Description,
                    CreatedDate = DateTime.Now,
                    Status = true
                };

                db.ParkingZones.Add(entity);
                db.SaveChanges();
                
                return entity.ZoneID;
            }
        }

        public bool Update(ParkingZoneDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.ParkingZones.Find(dto.ZoneID);
                if (entity == null) return false;

                entity.ZoneCode = dto.ZoneCode;
                entity.ZoneName = dto.ZoneName;
                entity.FloorLevel = dto.FloorLevel;
                entity.TotalSlots = dto.TotalSlots;
                entity.Description = dto.Description;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(int zoneId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.ParkingZones.Find(zoneId);
                if (entity == null) return false;

                entity.Status = false;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }
    }
}
