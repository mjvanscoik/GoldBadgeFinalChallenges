using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{
    public class Claim
    {
        
        public Claim(int claimID, string claimType, string claimDescription, double claimFinance, DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimFinance = claimFinance;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public double ClaimFinance { get; set; }
        public DateTime DateOfAccident { get; set; }    
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        
    }
    //public enum TypeOfClaim
    //{
    //    Car = 1, 
    //    Home = 2, 
    //    Theft = 3, 
    //    Fire = 4
    //}
}
