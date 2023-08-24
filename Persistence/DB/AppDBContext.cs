using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DB
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public DbSet<Advertisement> Advertisements { get; set;}
        public DbSet<Agenda> Agendas { get; set;}
        public DbSet<ConstituentDocument> ConstituentDocuments { get; set;}
        public DbSet<Council> Councils { get; set;}
        public DbSet<CouncilMember> CouncilMembers { get; set; }
        public DbSet<CouncilPosition> CouncilPositions { get; set; }
        public DbSet<InformationDocument> InformationDocuments { get; set; }
        public DbSet<InformationDocumentType> InformationDocumentTypes { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<WorkPlan> WorkPlans { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<CouncilMemberUniversityPosition> CouncilMemberUniversityPositions { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public override int SaveChanges()
        {
            foreach (var entity in ChangeTracker.Entries())
            {
                if (entity.State == EntityState.Modified)
                    entity.Property("UpdatedAt").CurrentValue = DateTime.Now;
            }

            //var modifiedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

            //foreach (var entity in modifiedEntities)
            //{
            //    entity.Property("UpdatedAt").CurrentValue = DateTime.Now;
            //}

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entity in ChangeTracker.Entries())
            {
                if (entity.State == EntityState.Modified)
                    entity.Property("UpdatedAt").CurrentValue = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetCreateUpdateDefaultValues(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(@"Host=127.0.0.1;Port=5432;Database=Council;Username=postgres;Password=Ghbdtn123");
        //}

        private void SetCreateUpdateDefaultValues(ModelBuilder modelBuilder)
        {
            var now = "NOW()";

            modelBuilder.Entity<Advertisement>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<Advertisement>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<Agenda>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<Agenda>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<ConstituentDocument>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<ConstituentDocument>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<Council>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<Council>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<CouncilMember>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<CouncilMember>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<CouncilPosition>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<CouncilPosition>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<InformationDocument>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<InformationDocument>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<InformationDocumentType>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<InformationDocumentType>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<News>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<News>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<PhoneNumber>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<PhoneNumber>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<WorkPlan>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<WorkPlan>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<University>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<University>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);

            modelBuilder.Entity<CouncilMemberUniversityPosition>().Property(e => e.CreatedAt).HasDefaultValueSql(now);
            modelBuilder.Entity<CouncilMemberUniversityPosition>().Property(e => e.UpdatedAt).HasDefaultValueSql(now);
        }
    }
}
