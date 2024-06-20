using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.Entities;
using WebAPI.Infrastructure.Interfaces;

namespace WebAPI.Infrastructure.Services
{
    public class CandidateRepository : IRepository<Candidate>
    {
        private readonly IAppEFContext _context;

        public CandidateRepository(IAppEFContext context)
        {
            _context = context;
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email)
         => await _context.Candidates.SingleOrDefaultAsync(x => x.Email == email);

        public void Create(Candidate entity)
         => _context.Candidates.Add(entity);

        public void Update(Candidate entity)
         => _context.Candidates.Update(entity);

        public async Task SaveAsync()
         => await _context.SaveChangesAsync(new());
    }
}