using System.ComponentModel.DataAnnotations;

namespace PermisosApp.Domain.Entities
{
    public class PermissionType : BaseEntity
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres.")]
        [Required]
        public string Description { get; set; }
    }
}
