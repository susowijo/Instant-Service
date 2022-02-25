using InstantService.BO;
using Microsoft.EntityFrameworkCore;

namespace InstantService.API.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class InstantServiceContext: DbContext
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public InstantServiceContext(DbContextOptions<InstantServiceContext> options) : base(options)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Module> Modules { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<RolePermission> RolePermissions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Collection> Collections { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Media> Medias { get; set; }
    }
}