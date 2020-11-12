using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;
using PermisosApp.Services.Abstract;

namespace PermisosApp.Services.Implementations
{
    public class PermissionService : BaseService<Permission, IPermissionRepository>, IPermissionService
    {
        public PermissionService(IPermissionRepository permissionRepository) : base(permissionRepository) { }
    }
}
