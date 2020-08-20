using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeThree
{
    class BadgeRepo
    {
        
      
        public readonly Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();

        //Create
        public void AddToDictionary(Badge badge)
        {
            dictionary.Add(badge.BadgeNum, badge.DoorList);
        }

        

        //Read
        public Dictionary<int, List<string>> FetchDictionary()
        {
            return dictionary;
        }

        //Update
        public bool UpdateBadgeInfoAddDoor(int id, string door, KeyValuePair<int, List<string>> keyAndValue)
        {
            var oldDoor = GetDoorListByID(id);
            if (oldDoor != null)
            {
                keyAndValue.Value.Add(door);

                return true;
            }
            else
            { return false; }

        }
        //Delete
        public bool UpdateBadgeInfoDeleteDoor(string door, int id, KeyValuePair<int, List<string>> keyAndValue)
         {
            var oldDoor = GetDoorListByID(id);
            if (oldDoor != null)
            {
                keyAndValue.Value.Remove(door);

                return true;
            }
            else
            { return false; }

        }

        //Helpers
        public List<string> GetDoorListByID(int id)
        {
            foreach (KeyValuePair<int, List<string>> ele1 in dictionary)
            {
                if (ele1.Key == id)
                {
                    return ele1.Value;
                   
                }
            }
            return null;
        }
    }
    
}
