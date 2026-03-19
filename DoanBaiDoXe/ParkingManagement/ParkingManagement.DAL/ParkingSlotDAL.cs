using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho ParkingSlot - Entity Framework
    /// </summary>
    public class ParkingSlotDAL
    {
        public List<ParkingSlotDTO> GetAll()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.ParkingSlots
                    .Include(ps => ps.ParkingZones)
                    .OrderBy(ps => ps.ParkingZones.FloorLevel)
                    .ThenBy(ps => ps.SlotCode)
                    .Select(ps => new ParkingSlotDTO
                    {
                        SlotID = ps.SlotID,
                        ZoneID = ps.ZoneID,
                        SlotCode = ps.SlotCode,
                        SlotNumber = ps.SlotNumber,
                        SlotType = ps.SlotType,
                        RowPosition = ps.RowPosition,
                        ColumnPosition = ps.ColumnPosition,
                        Width = ps.Width,
                        Length = ps.Length,
                        Description = ps.Description,
                        CreatedDate = ps.CreatedDate ?? DateTime.Now,
                        UpdatedDate = ps.UpdatedDate,
                        SlotStatus = ps.SlotStatus,
                        ZoneName = ps.ParkingZones.ZoneName,
                        ZoneCode = ps.ParkingZones.ZoneCode,
                        FloorLevel = ps.ParkingZones.FloorLevel
                    })
                    .ToList();
            }
        }

        public List<ParkingSlotDTO> GetByZone(int zoneId)
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.ParkingSlots
                    .Include(ps => ps.ParkingZones)
                    .Where(ps => ps.ZoneID == zoneId)
                    .OrderBy(ps => ps.RowPosition)
                    .ThenBy(ps => ps.ColumnPosition)
                    .Select(ps => new ParkingSlotDTO
                    {
                        SlotID = ps.SlotID,
                        ZoneID = ps.ZoneID,
                        SlotCode = ps.SlotCode,
                        SlotNumber = ps.SlotNumber,
                        SlotType = ps.SlotType,
                        RowPosition = ps.RowPosition,
                        ColumnPosition = ps.ColumnPosition,
                        SlotStatus = ps.SlotStatus,
                        ZoneName = ps.ParkingZones.ZoneName,
                        ZoneCode = ps.ParkingZones.ZoneCode,
                        FloorLevel = ps.ParkingZones.FloorLevel
                    })
                    .ToList();
            }
        }

        public List<ParkingSlotDTO> GetAvailableSlots()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.ParkingSlots
                    .Include(ps => ps.ParkingZones)
                    .Where(ps => ps.SlotStatus == "Trống")
                    .OrderBy(ps => ps.ParkingZones.FloorLevel)
                    .ThenBy(ps => ps.SlotCode)
                    .Select(ps => new ParkingSlotDTO
                    {
                        SlotID = ps.SlotID,
                        ZoneID = ps.ZoneID,
                        SlotCode = ps.SlotCode,
                        SlotNumber = ps.SlotNumber,
                        SlotStatus = ps.SlotStatus,
                        ZoneName = ps.ParkingZones.ZoneName,
                        ZoneCode = ps.ParkingZones.ZoneCode,
                        FloorLevel = ps.ParkingZones.FloorLevel
                    })
                    .ToList();
            }
        }

        public ParkingSlotDTO GetById(int slotId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var ps = db.ParkingSlots.Include(x => x.ParkingZones).FirstOrDefault(x => x.SlotID == slotId);
                if (ps == null) return null;

                return new ParkingSlotDTO
                {
                    SlotID = ps.SlotID,
                    ZoneID = ps.ZoneID,
                    SlotCode = ps.SlotCode,
                    SlotNumber = ps.SlotNumber,
                    SlotType = ps.SlotType,
                    RowPosition = ps.RowPosition,
                    ColumnPosition = ps.ColumnPosition,
                    Width = ps.Width,
                    Length = ps.Length,
                    Description = ps.Description,
                    CreatedDate = ps.CreatedDate ?? DateTime.Now,
                    UpdatedDate = ps.UpdatedDate,
                    SlotStatus = ps.SlotStatus,
                    ZoneName = ps.ParkingZones?.ZoneName,
                    ZoneCode = ps.ParkingZones?.ZoneCode,
                    FloorLevel = ps.ParkingZones?.FloorLevel
                };
            }
        }

        public bool UpdateStatus(int slotId, string status)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.ParkingSlots.Find(slotId);
                if (entity == null) return false;

                entity.SlotStatus = status;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public int Insert(ParkingSlotDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = new ParkingSlots
                {
                    ZoneID = dto.ZoneID,
                    SlotCode = dto.SlotCode,
                    SlotNumber = dto.SlotNumber,
                    SlotType = dto.SlotType ?? "Cố định",
                    RowPosition = dto.RowPosition,
                    ColumnPosition = dto.ColumnPosition,
                    Width = dto.Width,
                    Length = dto.Length,
                    Description = dto.Description,
                    SlotStatus = dto.SlotStatus ?? "Trống",
                    CreatedDate = DateTime.Now
                };

                db.ParkingSlots.Add(entity);
                db.SaveChanges();
                
                return entity.SlotID;
            }
        }

        public bool Update(ParkingSlotDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.ParkingSlots.Find(dto.SlotID);
                if (entity == null) return false;

                entity.ZoneID = dto.ZoneID;
                entity.SlotCode = dto.SlotCode;
                entity.SlotNumber = dto.SlotNumber;
                entity.SlotType = dto.SlotType ?? "Cố định";
                entity.RowPosition = dto.RowPosition;
                entity.ColumnPosition = dto.ColumnPosition;
                entity.Width = dto.Width;
                entity.Length = dto.Length;
                entity.Description = dto.Description;
                entity.SlotStatus = dto.SlotStatus ?? "Trống";
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(int slotId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.ParkingSlots.Find(slotId);
                if (entity == null) return false;

                db.ParkingSlots.Remove(entity);
                return db.SaveChanges() > 0;
            }
        }

        public Dictionary<string, int> GetSlotCountByStatus()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.ParkingSlots
                    .GroupBy(ps => ps.SlotStatus)
                    .ToDictionary(g => g.Key ?? "Unknown", g => g.Count());
            }
        }
    }
}
