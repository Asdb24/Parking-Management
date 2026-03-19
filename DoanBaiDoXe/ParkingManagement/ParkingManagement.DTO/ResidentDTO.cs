using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho Resident (Cư dân)
    /// </summary>
    public class ResidentDTO
    {
        public int ResidentID { get; set; }
        public int ApartmentID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string IDCardNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsOwner { get; set; }
        public string RelationshipWithOwner { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }

        // Navigation properties
        public string ApartmentCode { get; set; }
        public string ApartmentNumber { get; set; }
        public string BuildingName { get; set; }
    }
}
