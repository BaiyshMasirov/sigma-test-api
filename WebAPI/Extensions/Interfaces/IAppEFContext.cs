using Microsoft.EntityFrameworkCore;
using WebAPI.Extensions.Entities;

namespace WebAPI.Extensions.Interfaces
{
    public interface IAppEFContext
    {
        DbSet<Candidate> Candidates { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}