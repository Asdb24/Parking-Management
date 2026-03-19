using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho Vehicle (Phương tiện)
    /// </summary>
    public class VehicleDTO
    {
        public int VehicleID { get; set; }
        public int ResidentID { get; set; }
        public int VehicleTypeID { get; set; }
        public int? SlotID { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? YearOfManufacture { get; set; }
        public string CardNumber { get; set; }
        public string VehicleImage { get; set; }
        public string LicensePlateImage { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public string ResidentName { get; set; }
        public string ResidentPhone { get; set; }
        public string ApartmentCode { get; set; }
        public string BuildingName { get; set; }
        public string VehicleTypeName { get; set; }
        public string SlotCode { get; set; }
        public string ZoneName { get; set; }
    }
}
