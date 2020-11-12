using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;
using PermisosApp.Services.Abstract;

namespace PermisosApp.Services.Implementations
{
    public class PermissionTypeService : BaseService<PermissionType, IPermissionTypeRepository>, IPermissionTypeService
    {
        public PermissionTypeService(IPermissionTypeRepository permissionTypeRepository) : base(permissionTypeRepository) { }
    }
}
