using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_ChallengeThree;

namespace Tests_challengeThree
{
    [TestClass]
    public class UnitTest1
    {
        public readonly Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
        private readonly BadgeRepo _badgeRepo = new GB_ChallengeThree.BadgeRepo();


        [TestInitialize]
        public void Arrange()
        {
            var badge = new Badge(3);
            badge.DoorList.Add("bandicoot");
            badge.DoorList.Add("crash");
            
        }
        [TestMethod]
        public void AddToDictAdds()
        {
            var badge = new Badge(3);
            badge.DoorList.Add("bandicoot");
            badge.DoorList.Add("crash");

            _badgeRepo.AddToDictionary(badge);

            Assert.IsNotNull(dictionary);
        }

        [TestMethod]
        public void AddDoorAdds() // also tests GetDoorListByID
        {
            var badge = new Badge(3);
            badge.DoorList.Add("bandicoot");
            badge.DoorList.Add("crash");
            _badgeRepo.AddToDictionary(badge);
            string newDoor = ("a;lsdkfj");
            int id = 3;
            KeyValuePair<int, List<string>> badgeKeyAndValue = new KeyValuePair<int, List<string>>(badge.BadgeNum, badge.DoorList);

            var chicken = _badgeRepo.UpdateBadgeInfoAddDoor(id, newDoor, badgeKeyAndValue);

            Assert.IsTrue(chicken);

        }
        [TestMethod]
        public void DeleteDoorDeletes()
        {
            var badge = new Badge(3);
            badge.DoorList.Add("bandicoot");
            badge.DoorList.Add("crash");
            _badgeRepo.AddToDictionary(badge);
            string newDoor = ("a;lsdkfj");
            int id = 3;
            KeyValuePair<int, List<string>> badgeKeyAndValue = new KeyValuePair<int, List<string>>(badge.BadgeNum, badge.DoorList);

            var duck = _badgeRepo.UpdateBadgeInfoDeleteDoor(newDoor, id, badgeKeyAndValue);

            Assert.IsTrue(duck);
        }

    }
}
