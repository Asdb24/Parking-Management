using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho Building - Entity Framework
    /// </summary>
    public class BuildingDAL
    {
        /// <summary>
        /// Lấy tất cả buildings
        /// </summary>
        public List<BuildingDTO> GetAll()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Buildings
                    .Where(b => b.Status == true)
                    .OrderBy(b => b.BuildingCode)
                    .Select(b => new BuildingDTO
                    {
                        BuildingID = b.BuildingID,
                        BuildingCode = b.BuildingCode,
                        BuildingName = b.BuildingName,
                        TotalFloors = b.TotalFloors ?? 0,
                        TotalApartments = b.TotalApartments ?? 0,
                        Address = b.Address,
                        Description = b.Description,
                        CreatedDate = b.CreatedDate ?? DateTime.Now,
                        UpdatedDate = b.UpdatedDate,
                        Status = b.Status ?? true
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Lấy building theo ID
        /// </summary>
        public BuildingDTO GetById(int buildingId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var b = db.Buildings.Find(buildingId);
                if (b == null) return null;

                return new BuildingDTO
                {
                    BuildingID = b.BuildingID,
                    BuildingCode = b.BuildingCode,
                    BuildingName = b.BuildingName,
                    TotalFloors = b.TotalFloors ?? 0,
                    TotalApartments = b.TotalApartments ?? 0,
                    Address = b.Address,
                    Description = b.Description,
                    CreatedDate = b.CreatedDate ?? DateTime.Now,
                    UpdatedDate = b.UpdatedDate,
                    Status = b.Status ?? true
                };
            }
        }

        /// <summary>
        /// Thêm building mới
        /// </summary>
        public int Insert(BuildingDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = new Buildings
                {
                    BuildingCode = dto.BuildingCode,
                    BuildingName = dto.BuildingName,
                    TotalFloors = dto.TotalFloors,
                    TotalApartments = dto.TotalApartments,
                    Address = dto.Address,
                    Description = dto.Description,
                    CreatedDate = DateTime.Now,
                    Status = true
                };

                db.Buildings.Add(entity);
                db.SaveChanges();
                
                return entity.BuildingID;
            }
        }

        /// <summary>
        /// Cập nhật building
        /// </summary>
        public bool Update(BuildingDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Buildings.Find(dto.BuildingID);
                if (entity == null) return false;

                entity.BuildingCode = dto.BuildingCode;
                entity.BuildingName = dto.BuildingName;
                entity.TotalFloors = dto.TotalFloors;
                entity.TotalApartments = dto.TotalApartments;
                entity.Address = dto.Address;
                entity.Description = dto.Description;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Xóa building (soft delete)
        /// </summary>
        public bool Delete(int buildingId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Buildings.Find(buildingId);
                if (entity == null) return false;

                entity.Status = false;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Kiểm tra code đã tồn tại
        /// </summary>
        public bool IsCodeExists(string code, int excludeId = 0)
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Buildings.Any(b => b.BuildingCode == code && b.BuildingID != excludeId);
            }
        }
    }
}
