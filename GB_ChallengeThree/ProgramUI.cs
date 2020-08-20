using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GB_ChallengeThree
{
    class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
        public void Start()
        {
            SeedBadges();
            MainMenu();
        }
        public void SeedBadges()
        {
            Badge badgeOne = new Badge(12345);
            badgeOne.DoorList.Add("A7");

            Badge badgeTwo = new Badge(22345);
            badgeTwo.DoorList.Add("A1");
            badgeTwo.DoorList.Add("A4");
            badgeTwo.DoorList.Add("B1");
            badgeTwo.DoorList.Add("B2");

            Badge badgeThree = new Badge(32345);
            badgeThree.DoorList.Add("A4");
            badgeThree.DoorList.Add("A5");

            _badgeRepo.AddToDictionary(badgeOne);
            _badgeRepo.AddToDictionary(badgeTwo);
            _badgeRepo.AddToDictionary(badgeThree);
        }
        //Main Menu - 1. Add Badge
        //2. Edit a badge
        //3. List all badges
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                "\n" +
                "\n" +
                "1. Add a badge.\n" +
                "2. Edit a badge.\n" +
                "3. List all Badges.\n" +
                "4. Exit program.");
            char userInput = Console.ReadKey().KeyChar;

            switch (userInput)
            {
                case '1':
                    AddNewBadge();
                    break;
                case '2':
                    CallBadgeToUpdate();
                    break;
                case '3':
                    GetAllBadges();
                    break;
                case '4':
                    //
                    return;
                default:
                    Console.WriteLine("There seems to have been an error. Press any key to return to main menu.");
                    Console.ReadKey();
                    MainMenu();
                    break;

            }


        }



        //1. What is badge number?
        //2. Door to add?
        //3. Additional doors (y/n)
        //4. Return to main
        public void AddNewBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter the new badge number: ");
            int userInputNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the first door that badge should have access to");
            string newDoor = Console.ReadLine();
            Badge newBadge = new Badge(userInputNumber);
            newBadge.DoorList.Add(newDoor);
            _badgeRepo.AddToDictionary(newBadge);
           
            Console.WriteLine("New Badge successfully created. Is there another door you'd like to add? (y/n)");
            char userInput = Console.ReadKey().KeyChar;
            switch (userInput)
            {
                case 'y':
                    AddAnotherDoor(newBadge);
                    break;
                case 'n':
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Error. Please try again. Press any key to be redirected to main menu...");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }

        }
        public void AddAnotherDoor(Badge badge)
        {
            Console.WriteLine("Please enter a door: ");
            string userInput = Console.ReadLine();
            badge.DoorList.Add(userInput);
            Console.WriteLine("Door added successfully. Is there another door you'd like to add? (y/n)");
            char userInputTwo = Console.ReadKey().KeyChar;
            switch (userInputTwo)
            {
                case 'y':
                    AddAnotherDoor(badge);
                    break;
                case 'n':
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Error. Please try again. Press any key to be redirected to main menu...");
                    Console.ReadKey();
                    MainMenu();
                    break;

            }

        }
        //1.Get Badge by ID
        //2. Display doors currently accessable
        //3. (1. Add door/ 2. remove a door/3.return back to badge ID.)
        public void CallBadgeToUpdate()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number you'd like to update?");
            int userInputNum = int.Parse(Console.ReadLine());
            List<string> calledString = _badgeRepo.GetDoorListByID(userInputNum);
            KeyValuePair<int, List<string>> badgeKeyAndValue = new KeyValuePair<int, List<string>>(userInputNum, calledString);
            ManipulateDoors(userInputNum, badgeKeyAndValue);
            

        }
        public void ManipulateDoors(int userInputNum, KeyValuePair<int, List<string>> badgeKeyAndValue)
        {
            Console.Clear();
            Console.WriteLine("Badge Number             Door Access\n" +
                   "");
            DisplayBadge(badgeKeyAndValue);
            Console.WriteLine("Do you want to add or delete a door? Press:\n" +
                 "1. To add door.\n" +
                 "2. To remove door.\n" +
                 "3. Exit to main menu");
            char userInput = Console.ReadKey().KeyChar;
            switch (userInput)
            {
                case '1':
                    Console.WriteLine("What door do you want to add?");
                    string userInputDoorAdd = Console.ReadLine();
                    _badgeRepo.UpdateBadgeInfoAddDoor(userInputNum, userInputDoorAdd, badgeKeyAndValue);
                    ManipulateDoors(userInputNum, badgeKeyAndValue);
                    break;
                case '2':
                    Console.WriteLine("What door do you want to Delete?");
                    string userInputDoorDelete = Console.ReadLine();
                    _badgeRepo.UpdateBadgeInfoDeleteDoor(userInputDoorDelete, userInputNum, badgeKeyAndValue);
                    ManipulateDoors(userInputNum, badgeKeyAndValue);
                    break;
                case '3':
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Error. Please try again. Press any key to be redirected to main menu...");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }
            public void GetAllBadges()
            {
                Console.Clear();
                Console.WriteLine("Badge Number             Door Access\n" +
                   "");
                var dictionaryToDisplay = _badgeRepo.FetchDictionary();////
                foreach (KeyValuePair<int, List<string>> badge in dictionaryToDisplay)
                {
                    DisplayBadge(badge);
                }
                Console.WriteLine("\n" +
                    "Press any key to return to the main menu...");
                Console.ReadKey();
                MainMenu();
            }
            public void DisplayBadge(KeyValuePair<int, List<string>> badge)
            {
                string display;
                display = String.Format("{0}", badge.Key);
                string displayTwo;
                displayTwo = String.Join(", ", badge.Value);
                Console.WriteLine($"{display}                   {displayTwo}" +
                    $"");
            }

        
    } 
}
