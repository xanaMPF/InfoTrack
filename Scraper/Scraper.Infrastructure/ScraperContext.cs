using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Scraper.Infrastructure.Models;

#nullable disable

namespace Scraper.Infrastructure
{
    public partial class ScraperContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public ScraperContext()
        {
        }

        public ScraperContext(DbContextOptions<ScraperContext> options, IConfiguration configuration)
            : base(options)
        {
            this.Configuration = configuration;
        }

        public virtual DbSet<SearchEngine> SearchEngines { get; set; }
        public virtual DbSet<SearchHistory> SearchHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:Database"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<SearchEngine>(entity =>
            {
                entity.ToTable("SearchEngine");

                entity.Property(e => e.BaseAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Limit)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RegexTag)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<SearchHistory>(entity =>
            {
                entity.ToTable("SearchHistory");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.SearchEngine)
                    .WithMany(p => p.SearchHistories)
                    .HasForeignKey(d => d.SearchEngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SearchHis__Searc__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
