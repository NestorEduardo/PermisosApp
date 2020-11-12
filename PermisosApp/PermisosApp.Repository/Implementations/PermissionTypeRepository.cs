using PermisosApp.Data;
using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;

namespace PermisosApp.Repository.Implementations
{
    public class PermissionTypeRepository : BaseRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(ApplicationDbContext database) : base(database) { }
    }
}
