using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho ParkingLog - Entity Framework
    /// </summary>
    public class ParkingLogDAL
    {
        /// <summary>
        /// Check-in xe - vẫn dùng SP vì có logic phức tạp
        /// </summary>
        public int CheckIn(int vehicleId, int? slotId, int checkInBy, string checkInImage = null)
        {
            using (var db = new ParkingManagementEntities())
            {
                var result = db.Database.SqlQuery<CheckInResult>(
                    "EXEC sp_CheckIn @VehicleID, @SlotID, @CheckInBy, @CheckInImage",
                    new SqlParameter("@VehicleID", vehicleId),
                    new SqlParameter("@SlotID", (object)slotId ?? DBNull.Value),
                    new SqlParameter("@CheckInBy", checkInBy),
                    new SqlParameter("@CheckInImage", (object)checkInImage ?? DBNull.Value)
                ).FirstOrDefault();

                return result?.LogID ?? 0;
            }
        }

        private class CheckInResult { public int LogID { get; set; } }

        /// <summary>
        /// Check-out xe - vẫn dùng SP vì tính phí phức tạp
        /// </summary>
        public bool CheckOut(int logId, int checkOutBy, string checkOutImage = null)
        {
            using (var db = new ParkingManagementEntities())
            {
                var result = db.Database.SqlQuery<CheckOutResult>(
                    "EXEC sp_CheckOut @LogID, @CheckOutBy, @CheckOutImage",
                    new SqlParameter("@LogID", logId),
                    new SqlParameter("@CheckOutBy", checkOutBy),
                    new SqlParameter("@CheckOutImage", (object)checkOutImage ?? DBNull.Value)
                ).FirstOrDefault();

                return result?.Result > 0;
            }
        }

        private class CheckOutResult { public int Result { get; set; } }

        public List<ParkingLogDTO> GetVehiclesInParking()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.ParkingLogs
                    .Include(pl => pl.Vehicles)
                    .Include(pl => pl.Vehicles.VehicleTypes)
                    .Include(pl => pl.Vehicles.Residents)
                    .Include(pl => pl.Vehicles.Residents.Apartments)
                    .Include(pl => pl.Vehicles.Residents.Apartments.Buildings)
                    .Include(pl => pl.ParkingSlots)
                    .Include(pl => pl.ParkingSlots.ParkingZones)
                    .Where(pl => pl.LogStatus == "Đang đậu")
                    .OrderByDescending(pl => pl.CheckInTime)
                    .Select(pl => new ParkingLogDTO
                    {
                        LogID = pl.LogID,
                        VehicleID = pl.VehicleID,
                        SlotID = pl.SlotID,
                        CheckInTime = pl.CheckInTime,
                        CheckOutTime = pl.CheckOutTime,
                        CheckInBy = pl.CheckInBy,
                        CheckOutBy = pl.CheckOutBy,
                        Fee = pl.Fee ?? 0,
                        LogStatus = pl.LogStatus,
                        LicensePlate = pl.Vehicles.LicensePlate,
                        VehicleTypeName = pl.Vehicles.VehicleTypes.TypeName,
                        VehicleBrand = pl.Vehicles.Brand,
                        VehicleColor = pl.Vehicles.Color,
                        ResidentName = pl.Vehicles.Residents.FullName,
                        ApartmentCode = pl.Vehicles.Residents.Apartments.ApartmentCode,
                        BuildingName = pl.Vehicles.Residents.Apartments.Buildings.BuildingName,
                        SlotCode = pl.ParkingSlots != null ? pl.ParkingSlots.SlotCode : null,
                        ZoneName = pl.ParkingSlots != null && pl.ParkingSlots.ParkingZones != null ? pl.ParkingSlots.ParkingZones.ZoneName : null
                    })
                    .ToList();
            }
        }

        public List<ParkingLogDTO> GetByDate(DateTime date)
        {
            using (var db = new ParkingManagementEntities())
            {
                var startDate = date.Date;
                var endDate = date.Date.AddDays(1);

                return db.ParkingLogs
                    .Include(pl => pl.Vehicles)
                    .Include(pl => pl.Vehicles.VehicleTypes)
                    .Include(pl => pl.Vehicles.Residents)
                    .Include(pl => pl.Vehicles.Residents.Apartments)
                    .Include(pl => pl.Vehicles.Residents.Apartments.Buildings)
                    .Include(pl => pl.ParkingSlots)
                    .Include(pl => pl.ParkingSlots.ParkingZones)
                    .Where(pl => pl.CheckInTime >= startDate && pl.CheckInTime < endDate)
                    .OrderByDescending(pl => pl.CheckInTime)
                    .Select(pl => new ParkingLogDTO
                    {
                        LogID = pl.LogID,
                        VehicleID = pl.VehicleID,
                        SlotID = pl.SlotID,
                        CheckInTime = pl.CheckInTime,
                        CheckOutTime = pl.CheckOutTime,
                        Fee = pl.Fee ?? 0,
                        LogStatus = pl.LogStatus,
                        LicensePlate = pl.Vehicles.LicensePlate,
                        VehicleTypeName = pl.Vehicles.VehicleTypes.TypeName,
                        ResidentName = pl.Vehicles.Residents.FullName,
                        ApartmentCode = pl.Vehicles.Residents.Apartments.ApartmentCode,
                        SlotCode = pl.ParkingSlots != null ? pl.ParkingSlots.SlotCode : null
                    })
                    .ToList();
            }
        }

        public List<ParkingLogDTO> GetRecentActivities(int top = 10)
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.ParkingLogs
                    .Include(pl => pl.Vehicles)
                    .Include(pl => pl.Vehicles.VehicleTypes)
                    .Include(pl => pl.Vehicles.Residents)
                    .Include(pl => pl.Vehicles.Residents.Apartments)
                    .Include(pl => pl.Vehicles.Residents.Apartments.Buildings)
                    .Include(pl => pl.ParkingSlots)
                    .Include(pl => pl.ParkingSlots.ParkingZones)
                    .OrderByDescending(pl => pl.CheckInTime)
                    .Take(top)
                    .Select(pl => new ParkingLogDTO
                    {
                        LogID = pl.LogID,
                        VehicleID = pl.VehicleID,
                        SlotID = pl.SlotID,
                        CheckInTime = pl.CheckInTime,
                        CheckOutTime = pl.CheckOutTime,
                        Fee = pl.Fee ?? 0,
                        LogStatus = pl.LogStatus,
                        LicensePlate = pl.Vehicles.LicensePlate,
                        VehicleTypeName = pl.Vehicles.VehicleTypes.TypeName,
                        VehicleBrand = pl.Vehicles.Brand,
                        VehicleColor = pl.Vehicles.Color,
                        ResidentName = pl.Vehicles.Residents.FullName,
                        ApartmentCode = pl.Vehicles.Residents.Apartments.ApartmentCode,
                        BuildingName = pl.Vehicles.Residents.Apartments.Buildings.BuildingName,
                        SlotCode = pl.ParkingSlots != null ? pl.ParkingSlots.SlotCode : null,
                        ZoneName = pl.ParkingSlots != null && pl.ParkingSlots.ParkingZones != null ? pl.ParkingSlots.ParkingZones.ZoneName : null
                    })
                    .ToList();
            }
        }
    }
}
