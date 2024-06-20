using WebAPI.Infrastructure.Entities;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IRepository<Candidate> _candidateRepository;
        private readonly ILogger<CandidateService> _logger;

        public CandidateService(IRepository<Candidate> candidateRepository,
                                ILogger<CandidateService> logger)
        {
            _candidateRepository = candidateRepository;
            _logger = logger;
        }

        public async Task<Result> UpsertAsync(UpsertCandidateRequest request)
        {
            try
            {
                var entity = await _candidateRepository.GetCandidateByEmailAsync(request.Email);

                if (entity != null)
                {
                    GetUpdatedCandidate(request, entity);
                    _candidateRepository.Update(entity);
                }

                _candidateRepository.Create(GenerateCandidate(request));
                await _candidateRepository.SaveAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Upsert faield with error");
                return Result.Failure("Upsert failure");
            }
        }

        private Candidate GenerateCandidate(UpsertCandidateRequest request)
        {
            return new Candidate()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                IsNeedCall = request.IsNeedCall,
                CallStartDate = request.CallStartDate,
                CallEndDate = request.CallEndDate,
                LinkedinProfile = request.LinkedinProfile,
                Comment = request.Comment
            };
        }

        private void GetUpdatedCandidate(UpsertCandidateRequest request, Candidate entity)
        {
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Email = request.Email;
            entity.IsNeedCall = request.IsNeedCall;
            entity.CallStartDate = request.CallStartDate;
            entity.CallEndDate = request.CallEndDate;
            entity.LinkedinProfile = request.LinkedinProfile;
            entity.Comment = request.Comment;
        }
    }
}