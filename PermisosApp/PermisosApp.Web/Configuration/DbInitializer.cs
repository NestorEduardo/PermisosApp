using PermisosApp.Data;
using PermisosApp.Domain.Entities;
using System.Linq;

namespace PermisosApp.Web.Configuration
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext database)
        {
            if (!database.Permissions.Any())
            {
                PermissionType permissionType1 = new PermissionType
                {
                    Description = "Enfermedad"
                };

                PermissionType permissionType2 = new PermissionType
                {
                    Description = "Personal"
                };


                PermissionType permissionType3 = new PermissionType
                {
                    Description = "Vacaciones"
                };

                database.PermissionTypes.Add(permissionType1);
                database.PermissionTypes.Add(permissionType2);
                database.PermissionTypes.Add(permissionType3);
                database.SaveChanges();

                Permission permission1 = new Permission
                {
                    ApellidoEmpleado = "De La Cruz",
                    NombreEmpleado = "Néstor",
                    PermissionTypeId = permissionType1.Id
                };

                Permission permission2 = new Permission
                {
                    ApellidoEmpleado = "Nadal",
                    NombreEmpleado = "Rafael",
                    PermissionTypeId = permissionType2.Id
                };

                Permission permission3 = new Permission
                {
                    ApellidoEmpleado = "Amanda",
                    NombreEmpleado = "Lopez",
                    PermissionTypeId = permissionType3.Id
                };

                database.Permissions.Add(permission1);
                database.Permissions.Add(permission2);
                database.Permissions.Add(permission3);

                database.SaveChanges();
            }
        }
    }
}