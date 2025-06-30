namespace PolicyManagment.Domain;

public class Policy
{
    public string Id { get; set; }
    public string PolicyNumber { get; set; }
    public string CarPlateNumber { get; set; }
    public DateTime EffectiveDate { get; set; }
    public decimal ExpirationDate {  get; set; }
    public PolicyStatus Status { get; set; } 
    public Insured Insured { get; set; }

 }
