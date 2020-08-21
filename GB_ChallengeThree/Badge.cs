using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GB_ChallengeThree
{
    public class Badge
    {
        public Badge(int badgeNum)
        {
            BadgeNum = badgeNum;
            DoorList = new List<string>();
        }
        public int BadgeNum { get; set; }
        public List<string> DoorList { get; set; }
        //Key - Badge ID, Value - Doors
    }
}
