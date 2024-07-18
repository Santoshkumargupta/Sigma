using Sigma.Model;

namespace Sigma.Service.IService
{
    public interface ICandidateService
    {
        Task<Candidate> GetCandidateByEmailAsync(string email);
         Task<string>  AddOrEditCandidateAsync(Candidate candidate);
    }
}
