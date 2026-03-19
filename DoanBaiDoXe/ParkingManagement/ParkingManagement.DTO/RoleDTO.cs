using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho Role
    /// </summary>
    public class RoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
