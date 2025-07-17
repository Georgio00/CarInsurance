using ClaimManagement.Domain;

namespace ClaimManagement.Application;

public interface IClaimDataAccess
{
    Task<Claim>GetByIdAsync(string id); 
    Task<List<Claim>> GetByPolicyIdAsync(string PolicyId);
    Task AddAsync(Claim claim);
    Task UpdateAsync(Claim claim);
}
