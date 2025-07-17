namespace PolicyManagment.Domain;

public class Policy
{
    public required string Id { get; set; }
    public required string PolicyNumber { get; set; }
    public required string CarPlateNumber { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpirationDate {  get; set; }
    public decimal Premium { get; set; }
    public PolicyStatus Status { get; set; } 
    public required Insured Insured { get; set; }

 }
