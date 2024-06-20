using WebAPI.Extensions.Entities;
using WebAPI.Extensions.Interfaces;

namespace WebAPI.Extensions.Services
{
    public class CandidateRepository : IRepository<Candidate>
    {
        private readonly IAppEFContext _context;

        public CandidateRepository(IAppEFContext context)
        {
            _context = context;
        }

        public void Create(Candidate entity)
        {
            _context.Candidates.Add(entity);
        }

        public void Update(Candidate entity)
        {
            _context.Candidates.Update(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync(new());
        }
    }
}