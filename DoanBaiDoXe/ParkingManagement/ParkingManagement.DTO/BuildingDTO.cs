using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho Building (Tòa nhà)
    /// </summary>
    public class BuildingDTO
    {
        public int BuildingID { get; set; }
        public string BuildingCode { get; set; }
        public string BuildingName { get; set; }
        public int TotalFloors { get; set; }
        public int TotalApartments { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}
