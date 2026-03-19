using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho ParkingSlot (Chỗ đậu xe)
    /// </summary>
    public class ParkingSlotDTO
    {
        public int SlotID { get; set; }
        public int ZoneID { get; set; }
        public string SlotCode { get; set; }
        public string SlotNumber { get; set; }
        public string SlotType { get; set; } // Cố định, Tạm thời
        public int? RowPosition { get; set; }
        public int? ColumnPosition { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string SlotStatus { get; set; } // Trống, Có xe, Bảo trì, Đã đăng ký

        // Navigation properties
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
        public int? FloorLevel { get; set; }

        // Vehicle info if occupied
        public string VehicleLicensePlate { get; set; }
        public string VehicleOwnerName { get; set; }
    }
}
