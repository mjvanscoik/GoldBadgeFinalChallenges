using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{
    public class ClaimRepository
    {
        public readonly Queue<Claim> claimQueue = new Queue<Claim>();

        //Create
        public void AddClaim(Claim claim)
        {
            claimQueue.Enqueue(claim);
        }
        //Read
        public Queue<Claim> GetClaim()
        {
            return claimQueue; 
        }

        //Update
        public bool UpdateExistingClaim(int id, Claim updatingClaim)
        {
            Claim currentClaim = GetClaimByID(id);
            if (currentClaim != null)
            {
                currentClaim.ClaimID = updatingClaim.ClaimID;
                currentClaim.ClaimDescription = updatingClaim.ClaimDescription;
                currentClaim.ClaimFinance = updatingClaim.ClaimFinance;
                currentClaim.ClaimType = updatingClaim.ClaimType;
                currentClaim.DateOfAccident = updatingClaim.DateOfAccident;
                currentClaim.DateOfClaim = updatingClaim.DateOfClaim;
                currentClaim.IsValid = updatingClaim.IsValid;

                return true;
            }
            else
            {
                return false;
            }
        }
        
        

        
        //Helpers -- Need a Peek method to see next item
        public Claim GetClaimByID(int id)
        {
            foreach (Claim claim in claimQueue)
            {
                if (claim.ClaimID == id)
                { return claim; }
            }
            return null;
        }
        public Claim PeekClaim()
        {
            var dingo = claimQueue.Peek();
            return dingo;
            
        }
        public void DequeueClaim()
        {
            claimQueue.Dequeue();
        }
        
    }
}
