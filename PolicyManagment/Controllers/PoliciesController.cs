using Microsoft.AspNetCore.Mvc;
using PolicyManagment.Application;
using PolicyManagment.Domain;

namespace PolicyManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PoliciesController : ControllerBase
{

    private readonly IPolicyDataAccess _repository;
    
    public PoliciesController(IPolicyDataAccess repository)
    {
        _repository = repository;
    }


    [HttpPost]
    public async Task<IActionResult> CreatePolicy([FromBody] Policy policy)
    {
        await _repository.AddAsync(policy);//save to Mongodb

        return CreatedAtAction(nameof(GetPolicyById), new {id=policy.Id},policy);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult>GetPolicyById(string id)
    {
        var policy = await _repository.GetByIdAsync(id);

        if (policy == null) 
            return NotFound();

        return Ok(policy);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> UpdatePolicy(string id, [FromBody] Policy updatedPolicy)
    {
        var existing = await _repository.GetByIdAsync(id);

        if(existing == null)
            return NotFound();

        updatedPolicy.Id = id;

        await _repository.UpdateAsync(updatedPolicy);

        return NoContent();
    }


    [HttpDelete("{id}")]

    public async Task<IActionResult> DeletePolicy(string id)
    {
        var existing =await _repository.GetByIdAsync(id);

        if( existing == null)
            return NotFound();

        await _repository.DeleteAsync(id);//remove from db

        return NoContent();

    }


}
