using PolicyManagment.Domain;


namespace PolicyManagment.Application;

public interface IPolicyDataAccess
{
    Task<Policy> GetByIdAsync(string id);//retrieve a policy by irs unique ID
    Task<List<Policy>> GetAlAsync();//retreive all policies 
    Task AddAsync(Policy policy); //add a new policy
    Task UpdateAsync(Policy policy);//update an exsiting policy
    Task DeleteAsync(string id); //delete by id 


}
