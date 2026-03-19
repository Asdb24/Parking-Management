using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho Dashboard Statistics
    /// </summary>
    public class DashboardDTO
    {
        // Tổng quan
        public int TotalVehicles { get; set; }
        public int TotalSlots { get; set; }
        public int VehiclesInParking { get; set; }
        public int AvailableSlots { get; set; }
        public decimal TodayRevenue { get; set; }
        public int TodayCheckIns { get; set; }
        public int TodayCheckOuts { get; set; }

        // Thống kê theo loại xe
        public int Car4Seats { get; set; }
        public int Car7Seats { get; set; }
        public int SUV { get; set; }
        public int Pickup { get; set; }
        public int Van { get; set; }

        // Thống kê thanh toán
        public int TotalInvoices { get; set; }
        public int PaidInvoices { get; set; }
        public int UnpaidInvoices { get; set; }
        public int OverdueInvoices { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal TotalAmountPaid { get; set; }
    }

    /// <summary>
    /// Thống kê theo ngày
    /// </summary>
    public class DailyStatDTO
    {
        public DateTime Date { get; set; }
        public int CheckIns { get; set; }
        public int CheckOuts { get; set; }
        public decimal Revenue { get; set; }
    }

    /// <summary>
    /// Thống kê theo loại xe
    /// </summary>
    public class VehicleTypeStatDTO
    {
        public string VehicleTypeName { get; set; }
        public int Count { get; set; }
        public decimal Percentage { get; set; }
        public decimal Revenue { get; set; }
    }
}
