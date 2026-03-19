using System;
using System.Collections.Generic;
using System.Linq;
using ParkingManagement.DTO;

namespace ParkingManagement.DAL
{
    /// <summary>
    /// Data Access Layer cho Role - Entity Framework
    /// </summary>
    public class RoleDAL
    {
        public List<RoleDTO> GetAll()
        {
            using (var db = new ParkingManagementEntities())
            {
                return db.Roles
                    .Where(r => r.Status == true)
                    .OrderBy(r => r.RoleName)
                    .Select(r => new RoleDTO
                    {
                        RoleID = r.RoleID,
                        RoleName = r.RoleName,
                        Description = r.Description,
                        CreatedDate = r.CreatedDate ?? DateTime.Now,
                        Status = r.Status ?? true
                    })
                    .ToList();
            }
        }

        public RoleDTO GetById(int roleId)
        {
            using (var db = new ParkingManagementEntities())
            {
                var r = db.Roles.Find(roleId);
                if (r == null) return null;

                return new RoleDTO
                {
                    RoleID = r.RoleID,
                    RoleName = r.RoleName,
                    Description = r.Description,
                    CreatedDate = r.CreatedDate ?? DateTime.Now,
                    Status = r.Status ?? true
                };
            }
        }
    }
}
