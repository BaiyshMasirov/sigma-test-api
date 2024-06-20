using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface ICandidateService
    {
        Task<Result> UpsertAsync(UpsertCandidateRequest request);
    }
}