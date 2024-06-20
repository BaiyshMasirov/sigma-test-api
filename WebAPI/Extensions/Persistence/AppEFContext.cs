using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Extensions.Entities;
using WebAPI.Extensions.Interfaces;

namespace WebAPI.Extensions.Persistence
{
    public class AppEFContext : DbContext, IAppEFContext
    {
        public DbSet<Candidate> Candidates { get; set; }

        public AppEFContext(DbContextOptions<AppEFContext> options)
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken token = new())
            => base.SaveChangesAsync(token);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
         
    }
}