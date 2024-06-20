using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.Entities;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IAppEFContext
    {
        DbSet<Candidate> Candidates { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}