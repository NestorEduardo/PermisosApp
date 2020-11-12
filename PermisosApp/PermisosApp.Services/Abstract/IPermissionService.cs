using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;

namespace PermisosApp.Services.Abstract
{
    public interface IPermissionService : IBaseService<Permission, IPermissionRepository> { }
}
