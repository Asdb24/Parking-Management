using System;
using System.Collections.Generic;
using ParkingManagement.DAL;
using ParkingManagement.DTO;

namespace ParkingManagement.BLL
{
    public class DashboardBLL
    {
        private readonly DashboardDAL _dashboardDAL;

        public DashboardBLL()
        {
            _dashboardDAL = new DashboardDAL();
        }

        /// <summary>
        /// Lấy thống kê Dashboard
        /// </summary>
        public DashboardDTO GetDashboardStats()
        {
            return _dashboardDAL.GetDashboardStats();
        }

        /// <summary>
        /// Lấy thống kê theo loại xe
        /// </summary>
        public List<VehicleTypeStatDTO> GetVehicleTypeStats()
        {
            return _dashboardDAL.GetVehicleTypeStats();
        }

        /// <summary>
        /// Lấy thống kê theo ngày
        /// </summary>
        public List<DailyStatDTO> GetDailyStats(int days = 7)
        {
            return _dashboardDAL.GetDailyStats(days);
        }
    }
}
