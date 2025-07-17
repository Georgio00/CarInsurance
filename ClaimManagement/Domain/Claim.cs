namespace ClaimManagement.Domain;
    public class Claim
    {

        public required string Id { get; set; }
        public required string PolicyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public required string Description { get; set; }
        public decimal Amount { get; set; }
        public ClaimStatus Status { get; set; }
        public required Insured Insured { get; set; }
        public List<ClaimNote> Notes { get; set; } = new();
    }

