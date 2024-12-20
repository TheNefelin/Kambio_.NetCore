using ClassLibraryModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibraryServer.Connections
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
        {
        }

        public DbSet<RoleEntity> TKRoles { get; set; }
        public DbSet<UserEntity> TKUsers { get; set; }
    }
}
