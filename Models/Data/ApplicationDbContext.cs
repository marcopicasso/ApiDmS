using Microsoft.EntityFrameworkCore;

namespace ApiDmS.Models.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext () { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<accessLevelAllowed> accessLevelAlloweds { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Folder> Folders { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Document> ()
                .Property (b => b.active)
                .HasDefaultValue (0);
            modelBuilder.Entity<Document> ()
                .Property (b => b.accessLevel)
                .HasDefaultValue (1);
        }

    }

}