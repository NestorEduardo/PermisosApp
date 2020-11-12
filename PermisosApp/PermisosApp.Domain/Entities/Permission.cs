using PermisosApp.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace PermisosApp.Domain.Entities
{
    public class Permission : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [StringLength(50)]
        public string NombreEmpleado { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(50)]
        public string ApellidoEmpleado { get; set; }

        [NavigationProperty]
        public virtual PermissionType PermissionType { get; set; }

        [Range(1, int.MaxValue)]
        public int PermissionTypeId { get; set; }
    }
}
