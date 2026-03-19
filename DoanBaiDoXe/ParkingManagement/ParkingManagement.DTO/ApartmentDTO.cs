using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho Apartment (Căn hộ)
    /// </summary>
    public class ApartmentDTO
    {
        public int ApartmentID { get; set; }
        public int BuildingID { get; set; }
        public string ApartmentCode { get; set; }
        public string ApartmentNumber { get; set; }
        public int Floor { get; set; }
        public decimal? Area { get; set; }
        public int Bedrooms { get; set; }
        public string OwnerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }

        // Navigation properties
        public string BuildingName { get; set; }
        public string BuildingCode { get; set; }
    }
}
