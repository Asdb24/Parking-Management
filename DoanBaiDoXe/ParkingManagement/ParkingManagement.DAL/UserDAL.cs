using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho User - Entity Framework
    /// </summary>
    public class UserDAL
    {
        /// <summary>
        /// Đăng nhập - Sử dụng Stored Procedure sp_Login
        /// </summary>
        public UserDTO Login(string username, string passwordHash)
        {
            using (var db = new ParkingManagementEntities())
            {
                // Vẫn gọi Stored Procedure cho Login vì có logic phức tạp
                var result = db.Database.SqlQuery<LoginResult>(
                    "EXEC sp_Login @Username, @Password",
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", passwordHash)
                ).FirstOrDefault();

                if (result == null || result.UserID == 0) return null;

                return new UserDTO
                {
                    UserID = result.UserID,
                    Username = result.Username,
                    FullName = result.FullName,
                    Email = result.Email,
                    Phone = result.Phone,
                    Avatar = result.Avatar,
                    RoleID = result.RoleID,
                    RoleName = result.RoleName
                };
            }
        }

        // Class để map kết quả từ SP
        private class LoginResult
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Avatar { get; set; }
            public int RoleID { get; set; }
            public string RoleName { get; set; }
        }

        public List<UserDTO> GetAll()
        {
            using (var db = new ParkingManagementEntities())
            {
                var query = from u in db.Users
                            join ur in db.UserRoles on u.UserID equals ur.UserID into userRoles
                            from ur in userRoles.DefaultIfEmpty()
                            join r in db.Roles on ur.RoleID equals r.RoleID into roles
                            from r in roles.DefaultIfEmpty()
                            orderby u.FullName
                            select new UserDTO
                            {
                                UserID = u.UserID,
                                Username = u.Username,
                                PasswordHash = u.PasswordHash,
                                FullName = u.FullName,
                                Email = u.Email,
                                Phone = u.Phone,
                                Avatar = u.Avatar,
                                FailedLoginCount = u.FailedLoginCount ?? 0,
                                LastLoginDate = u.LastLoginDate,
                                CreatedDate = u.CreatedDate ?? DateTime.Now,
                                UpdatedDate = u.UpdatedDate,
                                Status = u.Status ?? true,
                                RoleID = r != null ? r.RoleID : 0,
                                RoleName = r != null ? r.RoleName : null
                            };

                return query.ToList();
            }
        }

        public UserDTO GetById(int userId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var u = db.Users.Find(userId);
                if (u == null) return null;

                var userRole = db.UserRoles.FirstOrDefault(ur => ur.UserID == userId);
                var role = userRole != null ? db.Roles.Find(userRole.RoleID) : null;

                return new UserDTO
                {
                    UserID = u.UserID,
                    Username = u.Username,
                    PasswordHash = u.PasswordHash,
                    FullName = u.FullName,
                    Email = u.Email,
                    Phone = u.Phone,
                    Avatar = u.Avatar,
                    FailedLoginCount = u.FailedLoginCount ?? 0,
                    LastLoginDate = u.LastLoginDate,
                    CreatedDate = u.CreatedDate ?? DateTime.Now,
                    UpdatedDate = u.UpdatedDate,
                    Status = u.Status ?? true,
                    RoleID = role?.RoleID ?? 0,
                    RoleName = role?.RoleName
                };
            }
        }

        public int Insert(UserDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = new Users
                {
                    Username = dto.Username,
                    PasswordHash = dto.PasswordHash,
                    FullName = dto.FullName,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    Avatar = dto.Avatar,
                    Status = dto.Status,
                    CreatedDate = DateTime.Now
                };

                db.Users.Add(entity);
                db.SaveChanges();

                // Thêm role cho user
                if (dto.RoleID > 0)
                {
                    var userRole = new UserRoles
                    {
                        UserID = entity.UserID,
                        RoleID = dto.RoleID,
                        AssignedDate = DateTime.Now
                    };
                    db.UserRoles.Add(userRole);
                    db.SaveChanges();
                }

                return entity.UserID;
            }
        }

        public bool Update(UserDTO dto)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Users.Find(dto.UserID);
                if (entity == null) return false;

                entity.FullName = dto.FullName;
                entity.Email = dto.Email;
                entity.Phone = dto.Phone;
                entity.Avatar = dto.Avatar;
                entity.Status = dto.Status;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool ChangePassword(int userId, string newPasswordHash)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Users.Find(userId);
                if (entity == null) return false;

                entity.PasswordHash = newPasswordHash;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(int userId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var entity = db.Users.Find(userId);
                if (entity == null) return false;

                entity.Status = false;
                entity.UpdatedDate = DateTime.Now;

                return db.SaveChanges() > 0;
            }
        }

        public bool IsUsernameExists(string username, int excludeUserId = 0)
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Users.Any(u => u.Username == username && u.UserID != excludeUserId);
            }
        }
    }
}
