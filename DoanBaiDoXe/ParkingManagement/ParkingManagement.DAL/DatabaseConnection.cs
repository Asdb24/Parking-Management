using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Lớp kết nối cơ sở dữ liệu
    /// BẠN CẦN CẤU HÌNH CONNECTION STRING TRONG App.config
    /// </summary>
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        private static readonly object _lock = new object();
        private string _connectionString;

        private DatabaseConnection()
        {
            // Lấy connection string từ App.config
            // Bạn cần thêm vào App.config:
            // <connectionStrings>
            //     <add name="ParkingDB" connectionString="Data Source=DHTT\SQLEXPRESS01;Initial Catalog=ParkingManagement;Integrated Security=True" providerName="System.Data.SqlClient"/>
            // </connectionStrings>

            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["ParkingDB"]?.ConnectionString;

                if (string.IsNullOrEmpty(_connectionString))
                {
                    // Default connection string nếu chưa cấu hình
                    _connectionString = @"Data Source=DHTT\SQLEXPRESS01;Initial Catalog=ParkingManagement;Integrated Security=True";
                }
            }
            catch
            {
                _connectionString = @"Data Source=DHTT\SQLEXPRESS01;Initial Catalog=ParkingManagement;Integrated Security=True";
            }        }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseConnection();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Lấy connection string
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// Tạo và mở kết nối mới
        /// </summary>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Test kết nối database
        /// </summary>
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Test kết nối với message
        /// </summary>
        public bool TestConnection(out string message)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    message = "Kết nối thành công!";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = $"Lỗi kết nối: {ex.Message}";
                return false;
            }
        }
    }
}
