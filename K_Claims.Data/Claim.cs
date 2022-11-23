public class Claim
{



    public Claim(string claimType, string claimDescr, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, string isValid)
    {
        ClaimType = claimType;
        ClaimDescr = claimDescr;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
        IsValid = isValid;
    }

    public int Id { get; set; }
    public string ClaimType { get; set; }
    public string ClaimDescr { get; set; }
    public decimal ClaimAmount { get; set; }
    public DateTime DateOfIncident { get; set; }
    public DateTime DateOfClaim { get; set; }
    public bool IsValid { get; set; }

}