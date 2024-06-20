using WebAPI.Extensions.Entities.Common;
using WebAPI.Infrastructure.Entities;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<Candidate> GetCandidateByEmailAsync(string email);

        void Create(T item); // create object

        void Update(T item); // update object

        Task SaveAsync();  // save changes
    }
}