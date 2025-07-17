namespace ClaimManagement.Domain;

public class ClaimNote
{
    public required string Id { get; set; }
    public  required string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string Note { get; set; }

}
