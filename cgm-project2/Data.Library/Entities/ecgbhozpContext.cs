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
        //User
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
        //Title
            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.TitleId);

                entity.Property(e => e.TitleId)
                    .UseIdentityColumn();

                entity.Property(e => e.TitleString)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(t => t.User)
                    .WithMany(u => u.Titles)
                    .HasForeignKey(t => t.CreatorId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });
        //Result
            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.ResultId);

                entity.Property(e => e.ResultId)
                    .UseIdentityColumn();

                entity.HasOne(r => r.User)
                    .WithMany(u => u.Results)
                    .HasForeignKey(r => r.TakerId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.Title)
                    .WithMany(t => t.Results)
                    .HasForeignKey(r => r.TakerId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });
        //Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId)
                    .UseIdentityColumn();

                entity.Property(e => e.CategoryString)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CategoryDescription)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Rank)
                    .IsRequired();

                entity.HasOne(c => c.Title)
                    .WithMany(t => t.Categories)
                    .HasForeignKey(c => c.TitleId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

        //Question
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId)
                    .UseIdentityColumn();

                entity.Property(e => e.QuestionString)
                    .IsRequired()
                    .HasMaxLength(0);

                entity.HasOne(q => q.Title)
                    .WithMany(t => t.Questions)
                    .HasForeignKey(q => q.TitleId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

        //Title
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.AnswerId);

                entity.Property(e => e.AnswerId)
                    .UseIdentityColumn();

                entity.Property(e => e.AnswerString)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Weight)
                    .IsRequired();

                entity.HasOne(a => a.Question)
                    .WithMany(q => q.Answers)
                    .HasForeignKey(a => a.QuestionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Category)
                    .WithMany(c => c.Answers)
                    .HasForeignKey(a => a.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
