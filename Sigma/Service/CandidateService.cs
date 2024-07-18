using Microsoft.EntityFrameworkCore;
using Sigma.Data;
using Sigma.Model;
using Sigma.Service.IService;

namespace Sigma.Service
{
    public class CandidateService: ICandidateService
    {
        private readonly SigmaDbContext _dbContext;

        public CandidateService(SigmaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email)
        {
            return await _dbContext.Candidates
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<string> AddOrEditCandidateAsync(Candidate candidate)
        {
            var existingCandidate = await _dbContext.Candidates
                .FirstOrDefaultAsync(c => c.Email == candidate.Email);

            string response = string.Empty;
            if (existingCandidate == null)
            {
                _dbContext.Candidates.Add(candidate);
                response = "Created";
            }
            else
            {
                // Update existing candidate
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.CallTime = candidate.CallTime;
                existingCandidate.LinkedInUrl = candidate.LinkedInUrl;
                existingCandidate.GitHubUrl = candidate.GitHubUrl;
                existingCandidate.Comment = candidate.Comment;
                _dbContext.Candidates.Update(existingCandidate);
                response = "Updated";

            }

            await _dbContext.SaveChangesAsync();
            return response;
        }

    }
}
