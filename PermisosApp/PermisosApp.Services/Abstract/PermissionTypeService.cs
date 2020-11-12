using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;

namespace PermisosApp.Services.Abstract
{
    public interface ICategoryService : IBaseService<PermissionType, IPermissionTypeRepository> { }
}
