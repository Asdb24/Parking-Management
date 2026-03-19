using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho Resident - Entity Framework
    /// </summary>
    public class ResidentDAL
    {
        public List<ResidentDTO> GetAll()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Residents
                    .Include(r => r.Apartments)
                    .Include(r => r.Apartments.Buildings)
                    .Where(r => r.Status == true)
                    .OrderBy(r => r.FullName)
                    .Select(r => new ResidentDTO
                    {
                        ResidentID = r.ResidentID,
                        ApartmentID = r.ApartmentID,
                        FullName = r.FullName,
                        Gender = r.Gender,
                        DateOfBirth = r.DateOfBirth,
                        IDCardNumber = r.IDCardNumber,
                        Phone = r.Phone,
                        Email = r.Email,
                        IsOwner = r.IsOwner ?? false,
                        RelationshipWithOwner = r.RelationshipWithOwner,
                        Avatar = r.Avatar,
                        CreatedDate = r.CreatedDate ?? DateTime.Now,
                        UpdatedDate = r.UpdatedDate,
                        Status = r.Status ?? true,
                        ApartmentCode = r.Apartments.ApartmentCode,
                        ApartmentNumber = r.Apartments.ApartmentNumber,
                        BuildingName = r.Apartments.Buildings.BuildingName
                    })
                    .ToList();
            }
        }

        public List<ResidentDTO> GetByApartment(int apartmentId)
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Residents
                    .Include(r => r.Apartments)
                    .Include(r => r.Apartments.Buildings)
                    .Where(r => r.ApartmentID == apartmentId && r.Status == true)
                    .OrderByDescending(r => r.IsOwner)
                    .ThenBy(r => r.FullName)
                    .Select(r => new ResidentDTO
                    {
                        ResidentID = r.ResidentID,
                        ApartmentID = r.ApartmentID,
                        FullName = r.FullName,
                        Gender = r.Gender,
                        DateOfBirth = r.DateOfBirth,
                        IDCardNumber = r.IDCardNumber,
                        Phone = r.Phone,
                        Email = r.Email,
                        IsOwner = r.IsOwner ?? false,
                        RelationshipWithOwner = r.RelationshipWithOwner,
                        Avatar = r.Avatar,
                        Status = r.Status ?? true,
                        ApartmentCode = r.Apartments.ApartmentCode,
                        ApartmentNumber = r.Apartments.ApartmentNumber,
                        BuildingName = r.Apartments.Buildings.BuildingName
                    })
                    .ToList();
            }
        }

        public ResidentDTO GetById(int residentId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var r = db.Residents
                    .Include(x => x.Apartments)
                    .Include(x => x.Apartments.Buildings)
                    .FirstOrDefault(x => x.ResidentID == residentId);
                    
                if (r == null) return null;

                return new ResidentDTO
                {
                    ResidentID = r.ResidentID,
                    ApartmentID = r.ApartmentID,
                    FullName = r.FullName,
                    Gender = r.Gender,
                    DateOfBirth = r.DateOfBirth,
                    IDCardNumber = r.IDCardNumber,
                    Phone = r.Phone,
                    Email = r.Email,
                    IsOwner = r.IsOwner ?? false,
                    RelationshipWithOwner = r.RelationshipWithOwner,
                    Avatar = r.Avatar,
                    CreatedDate = r.CreatedDate ?? DateTime.Now,
                    UpdatedDate = r.UpdatedDate,
                    Status = r.Status ?? true,
                    ApartmentCode = r.Apartments?.ApartmentCode,
                    ApartmentNumber = r.Apartments?.ApartmentNumber,
                    BuildingName = r.Apartments?.Buildings?.BuildingName
                };
            }
        }

        public int Insert(ResidentDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = new Residents
                {
                    ApartmentID = dto.ApartmentID,
                    FullName = dto.FullName,
                    Gender = dto.Gender,
                    DateOfBirth = dto.DateOfBirth,
                    IDCardNumber = dto.IDCardNumber,
                    Phone = dto.Phone,
                    Email = dto.Email,
                    IsOwner = dto.IsOwner,
                    RelationshipWithOwner = dto.RelationshipWithOwner,
                    Avatar = dto.Avatar,
                    CreatedDate = DateTime.Now,
                    Status = true
                };

                db.Residents.Add(entity);
                db.SaveChanges();
                
                return entity.ResidentID;
            }
        }

        public bool Update(ResidentDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Residents.Find(dto.ResidentID);
                if (entity == null) return false;

                entity.ApartmentID = dto.ApartmentID;
                entity.FullName = dto.FullName;
                entity.Gender = dto.Gender;
                entity.DateOfBirth = dto.DateOfBirth;
                entity.IDCardNumber = dto.IDCardNumber;
                entity.Phone = dto.Phone;
                entity.Email = dto.Email;
                entity.IsOwner = dto.IsOwner;
                entity.RelationshipWithOwner = dto.RelationshipWithOwner;
                entity.Avatar = dto.Avatar;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(int residentId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Residents.Find(residentId);
                if (entity == null) return false;

                entity.Status = false;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }
    }
}
