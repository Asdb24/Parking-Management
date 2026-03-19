using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho User
    /// </summary>
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public int FailedLoginCount { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }

        // Navigation properties
        public string RoleName { get; set; }
        public int RoleID { get; set; }
    }
}
