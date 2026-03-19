using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho Vehicle - Entity Framework
    /// </summary>
    public class VehicleDAL
    {
        public List<VehicleDTO> GetAll()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Vehicles
                    .Include(v => v.VehicleTypes)
                    .Include(v => v.Residents)
                    .Include(v => v.Residents.Apartments)
                    .Include(v => v.Residents.Apartments.Buildings)
                    .Include(v => v.ParkingSlots)
                    .Include(v => v.ParkingSlots.ParkingZones)
                    .OrderBy(v => v.LicensePlate)
                    .Select(v => new VehicleDTO
                    {
                        VehicleID = v.VehicleID,
                        ResidentID = v.ResidentID,
                        VehicleTypeID = v.VehicleTypeID,
                        SlotID = v.SlotID,
                        LicensePlate = v.LicensePlate,
                        Brand = v.Brand,
                        Model = v.Model,
                        Color = v.Color,
                        YearOfManufacture = v.YearOfManufacture,
                        CardNumber = v.CardNumber,
                        VehicleImage = v.VehicleImage,
                        LicensePlateImage = v.LicensePlateImage,
                        RegistrationDate = v.RegistrationDate ?? DateTime.Now,
                        ExpiryDate = v.ExpiryDate,
                        Note = v.Note,
                        CreatedDate = v.CreatedDate ?? DateTime.Now,
                        UpdatedDate = v.UpdatedDate,
                        Status = v.Status,
                        VehicleTypeName = v.VehicleTypes.TypeName,
                        ResidentName = v.Residents.FullName,
                        ResidentPhone = v.Residents.Phone,
                        ApartmentCode = v.Residents.Apartments.ApartmentCode,
                        BuildingName = v.Residents.Apartments.Buildings.BuildingName,
                        SlotCode = v.ParkingSlots != null ? v.ParkingSlots.SlotCode : null,
                        ZoneName = v.ParkingSlots != null && v.ParkingSlots.ParkingZones != null ? v.ParkingSlots.ParkingZones.ZoneName : null
                    })
                    .ToList();
            }
        }

        public VehicleDTO GetById(int vehicleId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var v = db.Vehicles
                    .Include(x => x.VehicleTypes)
                    .Include(x => x.Residents)
                    .Include(x => x.Residents.Apartments)
                    .Include(x => x.Residents.Apartments.Buildings)
                    .Include(x => x.ParkingSlots)
                    .Include(x => x.ParkingSlots.ParkingZones)
                    .FirstOrDefault(x => x.VehicleID == vehicleId);
                    
                if (v == null) return null;
                return MapToDTO(v);
            }
        }

        public VehicleDTO GetByLicensePlate(string licensePlate)
        {
            using (var db = new ParkingManagementEntities())
            {
                var v = db.Vehicles
                    .Include(x => x.VehicleTypes)
                    .Include(x => x.Residents)
                    .Include(x => x.Residents.Apartments)
                    .Include(x => x.Residents.Apartments.Buildings)
                    .Include(x => x.ParkingSlots)
                    .Include(x => x.ParkingSlots.ParkingZones)
                    .FirstOrDefault(x => x.LicensePlate == licensePlate);
                    
                if (v == null) return null;
                return MapToDTO(v);
            }
        }

        public VehicleDTO GetByCardNumber(string cardNumber)
        {
            using (var db = new ParkingManagementEntities())
            {
                var v = db.Vehicles
                    .Include(x => x.VehicleTypes)
                    .Include(x => x.Residents)
                    .Include(x => x.Residents.Apartments)
                    .Include(x => x.Residents.Apartments.Buildings)
                    .Include(x => x.ParkingSlots)
                    .Include(x => x.ParkingSlots.ParkingZones)
                    .FirstOrDefault(x => x.CardNumber == cardNumber);
                    
                if (v == null) return null;
                return MapToDTO(v);
            }
        }

        public List<VehicleDTO> Search(string searchText)
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Vehicles
                    .Include(v => v.VehicleTypes)
                    .Include(v => v.Residents)
                    .Include(v => v.Residents.Apartments)
                    .Include(v => v.Residents.Apartments.Buildings)
                    .Include(v => v.ParkingSlots)
                    .Include(v => v.ParkingSlots.ParkingZones)
                    .Where(v => v.LicensePlate.Contains(searchText) ||
                               v.CardNumber.Contains(searchText) ||
                               v.Residents.FullName.Contains(searchText) ||
                               v.Brand.Contains(searchText))
                    .OrderBy(v => v.LicensePlate)
                    .Select(v => new VehicleDTO
                    {
                        VehicleID = v.VehicleID,
                        ResidentID = v.ResidentID,
                        VehicleTypeID = v.VehicleTypeID,
                        SlotID = v.SlotID,
                        LicensePlate = v.LicensePlate,
                        Brand = v.Brand,
                        Model = v.Model,
                        Color = v.Color,
                        YearOfManufacture = v.YearOfManufacture,
                        CardNumber = v.CardNumber,
                        RegistrationDate = v.RegistrationDate ?? DateTime.Now,
                        ExpiryDate = v.ExpiryDate,
                        Status = v.Status,
                        VehicleTypeName = v.VehicleTypes.TypeName,
                        ResidentName = v.Residents.FullName,
                        ApartmentCode = v.Residents.Apartments.ApartmentCode,
                        BuildingName = v.Residents.Apartments.Buildings.BuildingName,
                        SlotCode = v.ParkingSlots != null ? v.ParkingSlots.SlotCode : null,
                        ZoneName = v.ParkingSlots != null && v.ParkingSlots.ParkingZones != null ? v.ParkingSlots.ParkingZones.ZoneName : null
                    })
                    .ToList();
            }
        }

        public List<VehicleDTO> GetByApartment(int apartmentId)
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Vehicles
                    .Include(v => v.VehicleTypes)
                    .Include(v => v.Residents)
                    .Include(v => v.Residents.Apartments)
                    .Include(v => v.Residents.Apartments.Buildings)
                    .Include(v => v.ParkingSlots)
                    .Include(v => v.ParkingSlots.ParkingZones)
                    .Where(v => v.Residents.ApartmentID == apartmentId)
                    .OrderBy(v => v.LicensePlate)
                    .Select(v => new VehicleDTO
                    {
                        VehicleID = v.VehicleID,
                        ResidentID = v.ResidentID,
                        VehicleTypeID = v.VehicleTypeID,
                        SlotID = v.SlotID,
                        LicensePlate = v.LicensePlate,
                        Brand = v.Brand,
                        Model = v.Model,
                        Color = v.Color,
                        Status = v.Status,
                        VehicleTypeName = v.VehicleTypes.TypeName,
                        ResidentName = v.Residents.FullName,
                        ApartmentCode = v.Residents.Apartments.ApartmentCode,
                        BuildingName = v.Residents.Apartments.Buildings.BuildingName,
                        SlotCode = v.ParkingSlots != null ? v.ParkingSlots.SlotCode : null
                    })
                    .ToList();
            }
        }

        public int Insert(VehicleDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = new Vehicles
                {
                    ResidentID = dto.ResidentID,
                    VehicleTypeID = dto.VehicleTypeID,
                    SlotID = dto.SlotID,
                    LicensePlate = dto.LicensePlate,
                    Brand = dto.Brand,
                    Model = dto.Model,
                    Color = dto.Color,
                    YearOfManufacture = dto.YearOfManufacture,
                    CardNumber = dto.CardNumber,
                    VehicleImage = dto.VehicleImage,
                    LicensePlateImage = dto.LicensePlateImage,
                    RegistrationDate = dto.RegistrationDate,
                    ExpiryDate = dto.ExpiryDate,
                    Note = dto.Note,
                    Status = dto.Status ?? "Hoạt động",
                    CreatedDate = DateTime.Now
                };

                db.Vehicles.Add(entity);
                db.SaveChanges();
                
                return entity.VehicleID;
            }
        }

        public bool Update(VehicleDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Vehicles.Find(dto.VehicleID);
                if (entity == null) return false;

                entity.ResidentID = dto.ResidentID;
                entity.VehicleTypeID = dto.VehicleTypeID;
                entity.SlotID = dto.SlotID;
                entity.LicensePlate = dto.LicensePlate;
                entity.Brand = dto.Brand;
                entity.Model = dto.Model;
                entity.Color = dto.Color;
                entity.YearOfManufacture = dto.YearOfManufacture;
                entity.CardNumber = dto.CardNumber;
                entity.VehicleImage = dto.VehicleImage;
                entity.LicensePlateImage = dto.LicensePlateImage;
                entity.ExpiryDate = dto.ExpiryDate;
                entity.Note = dto.Note;
                entity.Status = dto.Status;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(int vehicleId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Vehicles.Find(vehicleId);
                if (entity == null) return false;

                entity.Status = "Đã xóa";
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool IsLicensePlateExists(string licensePlate, int excludeId = 0)
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Vehicles.Any(v => v.LicensePlate == licensePlate && v.VehicleID != excludeId);
            }
        }

        private VehicleDTO MapToDTO(Vehicles v)
        {
            return new VehicleDTO
            {
                VehicleID = v.VehicleID,
                ResidentID = v.ResidentID,
                VehicleTypeID = v.VehicleTypeID,
                SlotID = v.SlotID,
                LicensePlate = v.LicensePlate,
                Brand = v.Brand,
                Model = v.Model,
                Color = v.Color,
                YearOfManufacture = v.YearOfManufacture,
                CardNumber = v.CardNumber,
                VehicleImage = v.VehicleImage,
                LicensePlateImage = v.LicensePlateImage,
                RegistrationDate = v.RegistrationDate ?? DateTime.Now,
                ExpiryDate = v.ExpiryDate,
                Note = v.Note,
                CreatedDate = v.CreatedDate ?? DateTime.Now,
                UpdatedDate = v.UpdatedDate,
                Status = v.Status,
                VehicleTypeName = v.VehicleTypes?.TypeName,
                ResidentName = v.Residents?.FullName,
                ResidentPhone = v.Residents?.Phone,
                ApartmentCode = v.Residents?.Apartments?.ApartmentCode,
                BuildingName = v.Residents?.Apartments?.Buildings?.BuildingName,
                SlotCode = v.ParkingSlots?.SlotCode,
                ZoneName = v.ParkingSlots?.ParkingZones?.ZoneName
            };
        }
    }
}
