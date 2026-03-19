using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho ParkingZone (Khu vực đậu xe)
    /// </summary>
    public class ParkingZoneDTO
    {
        public int ZoneID { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public int? FloorLevel { get; set; }
        public int TotalSlots { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }

        // Computed properties
        public int AvailableSlots { get; set; }
        public int OccupiedSlots { get; set; }
    }
}
