using System;
using System.Collections.Generic;
using System.Linq;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho VehicleType - Entity Framework
    /// </summary>
    public class VehicleTypeDAL
    {
        public List<VehicleTypeDTO> GetAll()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.VehicleTypes
                    .Where(v => v.Status == true)
                    .OrderBy(v => v.SortOrder)
                    .ThenBy(v => v.TypeName)
                    .Select(v => new VehicleTypeDTO
                    {
                        VehicleTypeID = v.VehicleTypeID,
                        TypeName = v.TypeName,
                        Description = v.Description,
                        Icon = v.Icon,
                        SortOrder = v.SortOrder ?? 0,
                        Status = v.Status ?? true
                    })
                    .ToList();
            }
        }

        public VehicleTypeDTO GetById(int vehicleTypeId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var v = db.VehicleTypes.Find(vehicleTypeId);
                if (v == null) return null;

                return new VehicleTypeDTO
                {
                    VehicleTypeID = v.VehicleTypeID,
                    TypeName = v.TypeName,
                    Description = v.Description,
                    Icon = v.Icon,
                    SortOrder = v.SortOrder ?? 0,
                    Status = v.Status ?? true
                };
            }
        }

        public int Insert(VehicleTypeDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = new VehicleTypes
                {
                    TypeName = dto.TypeName,
                    Description = dto.Description,
                    Icon = dto.Icon,
                    SortOrder = dto.SortOrder,
                    Status = true
                };

                db.VehicleTypes.Add(entity);
                db.SaveChanges();
                
                return entity.VehicleTypeID;
            }
        }

        public bool Update(VehicleTypeDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.VehicleTypes.Find(dto.VehicleTypeID);
                if (entity == null) return false;

                entity.TypeName = dto.TypeName;
                entity.Description = dto.Description;
                entity.Icon = dto.Icon;
                entity.SortOrder = dto.SortOrder;

                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(int vehicleTypeId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.VehicleTypes.Find(vehicleTypeId);
                if (entity == null) return false;

                entity.Status = false;
                return db.SaveChanges() > 0;
            }
        }
    }
}
