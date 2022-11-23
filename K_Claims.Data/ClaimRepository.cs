
public class ClaimRepository
{
    //WE NEED 1ST COME 1ST SERVED BEHAVIOR....
    //THERE IS A COLLECTION THAT WILL DO THAT FOR US....
    //F.I.F.O (First in First Out)  => Queue<T>
    private readonly Queue<ClaimRepository> _clDatabase = new Queue<ClaimRepository>();
    private int _count;
    //Create
    public bool AddClaimToDatabase(ClaimRepository claim)
    {
        if (claim is null)
        {
            return false;
        }
        else
        {
            _count++;
            claim.Id = _count;
            _clDatabase.Enqueue(claim); //how we add with a queue...
            return true;
        }
    }
    //Read (All)
    public Queue<ClaimRepository> GetClaims()
    {
        return _clDatabase;
    }

    //Read (one)
    public ClaimRepository GetClaim()
    {
        //this allows us to "see" whose next in line (doesn't remove it)
        ClaimRepository clEntity = _clDatabase.Peek();
        return clEntity;
    }

    //Delete -> Processing the Claim 
    public bool ProcessClaim()
    {
        if (_clDatabase.Count > 1)
        {
            _clDatabase.Dequeue();
            return true;
        }
        return false;
    }
}
