using System;
using System.Security.Cryptography;
using System.Text;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL;

        public UserBLL()
        {
            _userDAL = new UserDAL();
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            string passwordHash = HashPassword(password);
            return _userDAL.Login(username, passwordHash);
        }

        /// <summary>
        /// Lấy tất cả users
        /// </summary>
        public System.Collections.Generic.List<UserDTO> GetAll()
        {
            return _userDAL.GetAll();
        }

        /// <summary>
        /// Lấy user theo ID
        /// </summary>
        public UserDTO GetById(int userId)
        {
            return _userDAL.GetById(userId);
        }

        /// <summary>
        /// Thêm user mới
        /// </summary>
        public int Insert(UserDTO user, string password)
        {
            // Validate
            if (string.IsNullOrEmpty(user.Username))
                throw new Exception("Tên đăng nhập không được để trống!");
            
            if (string.IsNullOrEmpty(password))
                throw new Exception("Mật khẩu không được để trống!");
            
            if (string.IsNullOrEmpty(user.FullName))
                throw new Exception("Họ tên không được để trống!");
            
            if (_userDAL.IsUsernameExists(user.Username))
                throw new Exception("Tên đăng nhập đã tồn tại!");

            user.PasswordHash = HashPassword(password);
            user.Status = true;
            
            return _userDAL.Insert(user);
        }

        /// <summary>
        /// Cập nhật user
        /// </summary>
        public bool Update(UserDTO user)
        {
            if (string.IsNullOrEmpty(user.FullName))
                throw new Exception("Họ tên không được để trống!");
            
            return _userDAL.Update(user);
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var user = _userDAL.GetById(userId);
            if (user == null)
                throw new Exception("Không tìm thấy người dùng!");
            
            if (user.PasswordHash != HashPassword(oldPassword))
                throw new Exception("Mật khẩu cũ không đúng!");
            
            if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 6)
                throw new Exception("Mật khẩu mới phải có ít nhất 6 ký tự!");
            
            return _userDAL.ChangePassword(userId, HashPassword(newPassword));
        }

        /// <summary>
        /// Xóa user
        /// </summary>
        public bool Delete(int userId)
        {
            return _userDAL.Delete(userId);
        }

        /// <summary>
        /// Hash mật khẩu MD5
        /// </summary>
        private string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
