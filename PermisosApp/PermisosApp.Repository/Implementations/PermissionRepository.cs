using PermisosApp.Data;
using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;

namespace PermisosApp.Repository.Implementations
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext database) : base(database) { }
    }
}
