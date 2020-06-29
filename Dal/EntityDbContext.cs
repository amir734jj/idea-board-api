using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Models;
using static Dal.Utilities.ConnectionStringUtility;

namespace Dal
{
    public sealed class EntityDbContext : IdentityDbContext<User, IdentityRole<int>, int>, IDesignTimeDbContextFactory<EntityDbContext>
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructor that will be called by startup.cs
        /// </summary>
        /// <param name="optionsBuilderOptions"></param>
        // ReSharper disable once SuggestBaseTypeForParameter
        public EntityDbContext(DbContextOptions<EntityDbContext> optionsBuilderOptions) : base(optionsBuilderOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Ideas)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Idea>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Idea);
            
            modelBuilder.Entity<IdeaCategoryRelationship>()
                .HasKey(x => new {x.IdeaId, x.CategoryId});

            modelBuilder.Entity<IdeaCategoryRelationship>()
                .HasOne(x => x.Idea)
                .WithMany(x => x.IdeaCategoryRelationships)
                .HasForeignKey(x => x.CategoryId);
            
            modelBuilder.Entity<IdeaCategoryRelationship>()
                .HasOne(x => x.Category)
                .WithMany(x => x.IdeaCategoryRelationships)
                .HasForeignKey(x => x.CategoryId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        ///     This is used for DB migration locally
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public EntityDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var options = new DbContextOptionsBuilder<EntityDbContext>()
                .UseNpgsql(ConnectionStringUrlToPgResource(configuration.GetValue<string>("DATABASE_URL")))
                .Options;

            return new EntityDbContext(options);
        }
    }
}