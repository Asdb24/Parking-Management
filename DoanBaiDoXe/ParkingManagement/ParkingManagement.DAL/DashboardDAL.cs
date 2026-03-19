using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho Dashboard - Entity Framework
    /// </summary>
    public class DashboardDAL
    {
        public DashboardDTO GetDashboardStats()
        {
            using (var db = new ParkingManagementEntities())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);

                return new DashboardDTO
                {
                    // Tổng xe
                    TotalVehicles = db.Vehicles.Count(v => v.Status == "Hoạt động"),
                    
                    // Tổng chỗ đậu
                    TotalSlots = db.ParkingSlots.Count(),
                    
                    // Xe trong bãi
                    VehiclesInParking = db.ParkingLogs.Count(pl => pl.LogStatus == "Đang đậu"),
                    
                    // Chỗ trống
                    AvailableSlots = db.ParkingSlots.Count(ps => ps.SlotStatus == "Trống"),
                    
                    // Doanh thu hôm nay
                    TodayRevenue = db.Invoices
                        .Where(i => i.InvoiceStatus == "Đã thanh toán" && i.PaidDate >= today && i.PaidDate < tomorrow)
                        .Sum(i => (decimal?)i.FinalAmount) ?? 0,
                    
                    // Check-in hôm nay
                    TodayCheckIns = db.ParkingLogs.Count(pl => pl.CheckInTime >= today && pl.CheckInTime < tomorrow),
                    
                    // Check-out hôm nay
                    TodayCheckOuts = db.ParkingLogs.Count(pl => pl.CheckOutTime >= today && pl.CheckOutTime < tomorrow),
                    
                    // Thống kê hóa đơn
                    TotalInvoices = db.Invoices.Count(),
                    PaidInvoices = db.Invoices.Count(i => i.InvoiceStatus == "Đã thanh toán"),
                    UnpaidInvoices = db.Invoices.Count(i => i.InvoiceStatus == "Chưa thanh toán"),
                    OverdueInvoices = db.Invoices.Count(i => i.InvoiceStatus == "Quá hạn")
                };
            }
        }

        public List<VehicleTypeStatDTO> GetVehicleTypeStats()
        {
            using (var db = new ParkingManagementEntities())
            {
                var stats = db.VehicleTypes
                    .Select(vt => new VehicleTypeStatDTO
                    {
                        VehicleTypeName = vt.TypeName,
                        Count = db.Vehicles.Count(v => v.VehicleTypeID == vt.VehicleTypeID && v.Status == "Hoạt động")
                    })
                    .OrderByDescending(s => s.Count)
                    .ToList();

                int total = stats.Sum(s => s.Count);
                foreach (var stat in stats)
                {
                    stat.Percentage = total > 0 ? (decimal)stat.Count / total * 100 : 0;
                }

                return stats;
            }
        }

        public List<DailyStatDTO> GetDailyStats(int days = 7)
        {
            using (var db = new ParkingManagementEntities())
            {
                var startDate = DateTime.Today.AddDays(-days);

                var logs = db.ParkingLogs
                    .Where(pl => pl.CheckInTime >= startDate)
                    .ToList();

                var grouped = logs
                    .GroupBy(pl => pl.CheckInTime.Date)
                    .Select(g => new DailyStatDTO
                    {
                        Date = g.Key,
                        CheckIns = g.Count(),
                        CheckOuts = g.Count(pl => pl.CheckOutTime != null)
                    })
                    .OrderBy(s => s.Date)
                    .ToList();

                return grouped;
            }
        }
    }
}
