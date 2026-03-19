using System;

namespace ParkingManagement.DTO
{
    /// <summary>
    /// Data Transfer Object cho VehicleType (Loại phương tiện)
    /// </summary>
    public class VehicleTypeDTO
    {
        public int VehicleTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int SortOrder { get; set; }
        public bool Status { get; set; }
    }
}
