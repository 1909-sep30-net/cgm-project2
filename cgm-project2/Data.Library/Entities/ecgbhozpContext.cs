using Microsoft.EntityFrameworkCore;

namespace Data.Library.Entities
{
    public class ecgbhozpContext : DbContext
    {
        public ecgbhozpContext() 
        { }

        public ecgbhozpContext(DbContextOptions<ecgbhozpContext> options) : base(options)
        { }

        
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Category> Category{ get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");
            **/
           
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .UseIdentityColumn();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(9);
            });

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
