using Microsoft.EntityFrameworkCore;
using ProjectRenan.Data.Extensions;
using ProjectRenan.Data.Mappings;
using ProjectRenan.Domain.Entities;

namespace ProjectRenan.Data.Context
{
    public class ProjectRenanContext : DbContext
    {
        public ProjectRenanContext(DbContextOptions<ProjectRenanContext> option)
            : base(option) { }

        #region "DbSets"
        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }

    }
}
