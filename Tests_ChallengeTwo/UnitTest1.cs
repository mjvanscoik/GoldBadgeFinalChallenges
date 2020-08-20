using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using ChallengeTwo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_ChallengeTwo
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimRepository _claimRepo;
        private Claim _claim;
        
        

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepository();
            _claim = new Claim(6, "Injury", "GShock watch caused laser burn", 69.69, new DateTime(2019, 04, 25), new DateTime(2019, 04, 26), true);
            _claimRepo.AddClaim(_claim);

        }
        [TestMethod]
        public void AddClaimAddsClaimToQueue()
        {
            _claimRepo.AddClaim(_claim);

            Assert.IsNotNull(_claimRepo.claimQueue);
        }
        [TestMethod]
        public void GetClaimReturnsClaim()
        {
            _claimRepo.GetClaim();
            Assert.AreEqual(_claimRepo.claimQueue.Count, 1);
        }
        [TestMethod]
        public void UpdateExistingClaimUpdatesClaim()
        {
            

            Claim chickenRun = new Claim(3, "Poultry", "chicken sprained its ankle escaping from farm", 4.00, new DateTime(2019, 04, 28), new DateTime(2019, 05, 01), true);
            bool updatesContent = _claimRepo.UpdateExistingClaim(_claim.ClaimID, chickenRun);
            Assert.IsTrue(updatesContent);
        }
        [TestMethod]
        public void PeekClaimPeeksClaim()
        {
            Claim chickenRun = new Claim(3, "Poultry", "chicken sprained its ankle escaping from farm", 4.00, new DateTime(2019, 04, 28), new DateTime(2019, 05, 01), true);
            _claimRepo.AddClaim(chickenRun);
            _claimRepo.AddClaim(_claim);

            Claim fakeClaim =_claimRepo.PeekClaim();

            Assert.AreEqual(fakeClaim, _claim);
            Assert.AreNotEqual(fakeClaim, chickenRun);

        }
        [TestMethod]
        public void DequeueDequeues() //Works in console app. Can't figure out how to test it tho.
        {
            Claim chickenRun = new Claim(3, "Poultry", "chicken sprained its ankle escaping from farm", 4.00, new DateTime(2019, 04, 28), new DateTime(2019, 05, 01), true);
            _claimRepo.AddClaim(chickenRun);
            _claimRepo.AddClaim(_claim);

            _claimRepo.DequeueClaim();//This removes next item from claimsQueue.

            Assert.AreEqual(_claimRepo.claimQueue.Count, 1);//So there should only be one remaining here???
        }
    }
}
