using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho Apartment - Entity Framework
    /// </summary>
    public class ApartmentDAL
    {
        public List<ApartmentDTO> GetAll()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Apartments
                    .Include(a => a.Buildings)
                    .Where(a => a.Status == true)
                    .OrderBy(a => a.Buildings.BuildingCode)
                    .ThenBy(a => a.Floor)
                    .ThenBy(a => a.ApartmentNumber)
                    .Select(a => new ApartmentDTO
                    {
                        ApartmentID = a.ApartmentID,
                        BuildingID = a.BuildingID,
                        ApartmentCode = a.ApartmentCode,
                        ApartmentNumber = a.ApartmentNumber,
                        Floor = a.Floor,
                        Area = a.Area,
                        Bedrooms = a.Bedrooms ?? 0,
                        OwnerName = a.OwnerName,
                        Phone = a.Phone,
                        Email = a.Email,
                        CreatedDate = a.CreatedDate ?? DateTime.Now,
                        UpdatedDate = a.UpdatedDate,
                        Status = a.Status ?? true,
                        BuildingName = a.Buildings.BuildingName,
                        BuildingCode = a.Buildings.BuildingCode
                    })
                    .ToList();
            }
        }

        public List<ApartmentDTO> GetByBuilding(int buildingId)
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Apartments
                    .Include(a => a.Buildings)
                    .Where(a => a.BuildingID == buildingId && a.Status == true)
                    .OrderBy(a => a.Floor)
                    .ThenBy(a => a.ApartmentNumber)
                    .Select(a => new ApartmentDTO
                    {
                        ApartmentID = a.ApartmentID,
                        BuildingID = a.BuildingID,
                        ApartmentCode = a.ApartmentCode,
                        ApartmentNumber = a.ApartmentNumber,
                        Floor = a.Floor,
                        Area = a.Area,
                        Bedrooms = a.Bedrooms ?? 0,
                        OwnerName = a.OwnerName,
                        Phone = a.Phone,
                        Email = a.Email,
                        CreatedDate = a.CreatedDate ?? DateTime.Now,
                        UpdatedDate = a.UpdatedDate,
                        Status = a.Status ?? true,
                        BuildingName = a.Buildings.BuildingName,
                        BuildingCode = a.Buildings.BuildingCode
                    })
                    .ToList();
            }
        }

        public ApartmentDTO GetById(int apartmentId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var a = db.Apartments.Include(x => x.Buildings).FirstOrDefault(x => x.ApartmentID == apartmentId);
                if (a == null) return null;

                return new ApartmentDTO
                {
                    ApartmentID = a.ApartmentID,
                    BuildingID = a.BuildingID,
                    ApartmentCode = a.ApartmentCode,
                    ApartmentNumber = a.ApartmentNumber,
                    Floor = a.Floor,
                    Area = a.Area,
                    Bedrooms = a.Bedrooms ?? 0,
                    OwnerName = a.OwnerName,
                    Phone = a.Phone,
                    Email = a.Email,
                    CreatedDate = a.CreatedDate ?? DateTime.Now,
                    UpdatedDate = a.UpdatedDate,
                    Status = a.Status ?? true,
                    BuildingName = a.Buildings?.BuildingName,
                    BuildingCode = a.Buildings?.BuildingCode
                };
            }
        }

        public List<ApartmentDTO> Search(string keyword, int? buildingId = null)
        {
            using (var db = new ParkingManagementEntities())
            {
                var query = db.Apartments
                    .Include(a => a.Buildings)
                    .Where(a => a.Status == true);

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(a => 
                        a.ApartmentCode.Contains(keyword) ||
                        a.ApartmentNumber.Contains(keyword) ||
                        a.OwnerName.Contains(keyword) ||
                        a.Phone.Contains(keyword));
                }

                if (buildingId.HasValue)
                {
                    query = query.Where(a => a.BuildingID == buildingId.Value);
                }

                return query
                    .OrderBy(a => a.Buildings.BuildingCode)
                    .ThenBy(a => a.Floor)
                    .ThenBy(a => a.ApartmentNumber)
                    .Select(a => new ApartmentDTO
                    {
                        ApartmentID = a.ApartmentID,
                        BuildingID = a.BuildingID,
                        ApartmentCode = a.ApartmentCode,
                        ApartmentNumber = a.ApartmentNumber,
                        Floor = a.Floor,
                        Area = a.Area,
                        Bedrooms = a.Bedrooms ?? 0,
                        OwnerName = a.OwnerName,
                        Phone = a.Phone,
                        Email = a.Email,
                        CreatedDate = a.CreatedDate ?? DateTime.Now,
                        UpdatedDate = a.UpdatedDate,
                        Status = a.Status ?? true,
                        BuildingName = a.Buildings.BuildingName,
                        BuildingCode = a.Buildings.BuildingCode
                    })
                    .ToList();
            }
        }

        public int Insert(ApartmentDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = new Apartments
                {
                    BuildingID = dto.BuildingID,
                    ApartmentCode = dto.ApartmentCode,
                    ApartmentNumber = dto.ApartmentNumber,
                    Floor = dto.Floor,
                    Area = dto.Area,
                    Bedrooms = dto.Bedrooms,
                    OwnerName = dto.OwnerName,
                    Phone = dto.Phone,
                    Email = dto.Email,
                    CreatedDate = DateTime.Now,
                    Status = true
                };

                db.Apartments.Add(entity);
                db.SaveChanges();
                
                return entity.ApartmentID;
            }
        }

        public bool Update(ApartmentDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Apartments.Find(dto.ApartmentID);
                if (entity == null) return false;

                entity.BuildingID = dto.BuildingID;
                entity.ApartmentCode = dto.ApartmentCode;
                entity.ApartmentNumber = dto.ApartmentNumber;
                entity.Floor = dto.Floor;
                entity.Area = dto.Area;
                entity.Bedrooms = dto.Bedrooms;
                entity.OwnerName = dto.OwnerName;
                entity.Phone = dto.Phone;
                entity.Email = dto.Email;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(int apartmentId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Apartments.Find(apartmentId);
                if (entity == null) return false;

                entity.Status = false;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }
    }
}
