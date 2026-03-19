using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho InvoiceDetail (Chi tiết hóa đơn)
    /// </summary>
    public class InvoiceDetailDTO
    {
        public int DetailID { get; set; }
        public int InvoiceID { get; set; }
        public int VehicleID { get; set; }
        public int FeeID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public string LicensePlate { get; set; }
        public string VehicleTypeName { get; set; }
        public string FeeName { get; set; }
        public string FeeType { get; set; }
    }
}
