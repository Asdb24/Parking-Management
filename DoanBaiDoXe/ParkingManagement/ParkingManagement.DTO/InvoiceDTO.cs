using System;
using System.Collections.Generic;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho Invoice (Hóa đơn)
    /// </summary>
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public string InvoiceCode { get; set; }
        public int ApartmentID { get; set; }
        public int InvoiceMonth { get; set; }
        public int InvoiceYear { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Note { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string InvoiceStatus { get; set; } // Chưa thanh toán, Đã thanh toán, Quá hạn

        // Navigation properties
        public string ApartmentCode { get; set; }
        public string ApartmentNumber { get; set; }
        public string BuildingName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public string CreatedByName { get; set; }

        // Details
        public List<InvoiceDetailDTO> Details { get; set; }

        public InvoiceDTO()
        {
            Details = new List<InvoiceDetailDTO>();
        }
    }
}
