using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho ParkingFee (Bảng phí)
    /// </summary>
    public class ParkingFeeDTO
    {
        public int FeeID { get; set; }
        public int VehicleTypeID { get; set; }
        public string FeeName { get; set; }
        public string FeeType { get; set; } // Tháng, Ngày, Giờ
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }

        // Navigation properties
        public string VehicleTypeName { get; set; }
    }
}
