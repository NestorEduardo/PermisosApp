using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;

namespace PermisosApp.Services.Abstract
{
    public interface IPermissionTypeService : IBaseService<PermissionType, IPermissionTypeRepository> { }
}
