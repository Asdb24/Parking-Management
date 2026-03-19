using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho ParkingLog (Lịch sử ra/vào)
    /// </summary>
    public class ParkingLogDTO
    {
        public int LogID { get; set; }
        public int VehicleID { get; set; }
        public int? SlotID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string CheckInImage { get; set; }
        public string CheckOutImage { get; set; }
        public int? CheckInBy { get; set; }
        public int? CheckOutBy { get; set; }
        public string ParkingType { get; set; } // Thường xuyên, Khách
        public decimal Fee { get; set; }
        public string Note { get; set; }
        public string LogStatus { get; set; } // Đang đậu, Đã ra

        // Navigation properties
        public string LicensePlate { get; set; }
        public string VehicleTypeName { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleColor { get; set; }
        public string ResidentName { get; set; }
        public string ApartmentCode { get; set; }
        public string BuildingName { get; set; }
        public string SlotCode { get; set; }
        public string ZoneName { get; set; }
        public string CheckInByName { get; set; }
        public string CheckOutByName { get; set; }

        // Computed properties
        public TimeSpan? Duration
        {
            get
            {
                if (CheckOutTime.HasValue)
                    return CheckOutTime.Value - CheckInTime;
                return DateTime.Now - CheckInTime;
            }
        }

        public string DurationString
        {
            get
            {
                var duration = Duration;
                if (duration.HasValue)
                {
                    return $"{(int)duration.Value.TotalHours}h {duration.Value.Minutes}m";
                }
                return "";
            }
        }
    }
}
