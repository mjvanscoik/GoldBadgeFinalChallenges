using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{
    public class ProgramUI

    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
        private readonly Queue<Claim> _claimsQueue = new Queue<Claim>();
        private bool _isRunning = true;
        public void SeedClaimData()
        {
            var claimOne = new Claim(1, "Car", "Car accident on 465", 400.00d, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), false);
            var claimTwo = new Claim(2, "Home", "House fire in kitchen.", 4000.00d, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            var claimThree = new Claim(3, "Theft", "Stolen pancakes.", 4.00d, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _claimRepo.AddClaim(claimOne);
            _claimRepo.AddClaim(claimTwo);
            _claimRepo.AddClaim(claimThree);

            IEnumerator enumerator = _claimsQueue.GetEnumerator();

        }
        public void Start()
        {
            SeedClaimData();
            MainMenu();
        }
        public void MainMenu()
        {
            
            Console.Clear();
            Console.WriteLine("Welcome to the Komodo insurance center. Please press the number corresponding to the function you'd like to execute.\n" +
                "1. List all claims.\n" +
                "2. Take care of next claim.\n" +
                "3. Enter a new claim.\n" +
                "4. Modify an existing claim.\n" +
                "5. Exit program.");

            var userInput = Console.ReadKey().KeyChar;

            switch (userInput)
            {
                case '1':
                    GetClaimsCollection();
                    break;
                case '2':
                    MoveToNextClaim();
                    break;
                case '3':
                    EnterNewClaim();
                    break;
                case '4':
                    UpdateClaim();
                    break;
                case '5':
                    _isRunning = false;
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Sorry, there was an error. Please try again.");
                    MainMenu();
                    break;
            }

            while (_isRunning)
            {
                Console.Clear();
            }
            Console.ReadKey(); //end of menu
        }
        public void GetClaimsCollection()
        {
            Console.Clear();
            Queue<Claim> listToDisplay = _claimRepo.GetClaim();
            foreach (Claim claim in listToDisplay)
            {
                DisplayClaim(claim);
            }

            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            MainMenu();
        }
        public void DisplayClaim(Claim claim)
        {
            string display;
            display = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", claim.ClaimID, claim.ClaimType, claim.ClaimDescription, claim.ClaimFinance, claim.DateOfAccident, claim.DateOfClaim, claim.IsValid);
            Console.WriteLine(display);
            Console.WriteLine(" ");
        }
        public void MoveToNextClaim()
        {
            Console.Clear();
            Claim displayNext = _claimRepo.PeekClaim(); //Need to display claim.
            Console.WriteLine("Here are the details for the next claim to be handled: \n" +
                " \n" +
                " ");
            DisplayClaim(displayNext);
            Console.WriteLine("\n" +
                "\n" +
                "\n" +
                "\n" +
                "Do you want to deal with this claim now? (y/n)");
            char userInput = Console.ReadKey().KeyChar;
            
            switch (userInput)
            {
                case 'y':
                    _claimRepo.DequeueClaim();
                    Console.WriteLine("This claim has been removed from the workflow...");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 'n':
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Error... Please indicate what you'd like to do by pressing the 'y' or 'n' key on your keyboard. Return to main menu...");
                    MainMenu();
                    break;
            }
           
        }
        public void EnterNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Please enter the information for the claim you'd like to store.\n" +
                "" +
                "");
            Console.WriteLine("Enter a case number: ");
            int newClaimID = int.Parse(Console.ReadLine());
            

            Console.WriteLine("Enter a case type: ");
            string newClaimType = Console.ReadLine();
           

            Console.WriteLine("Enter a case description: ");
            string newClaimClaimDescription = Console.ReadLine();
            

            Console.WriteLine("Enter a dollar ammount for the claim: ");
            double newClaimClaimFinance = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date (YYYY,MM,DD) of the incident: ");
            DateTime newClaimDateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date (YYYY,MM,DD) the claim was submitted: ");
            DateTime newClaimDateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is this a valid claim? Type true or false");
            bool newClaimIsValid = bool.Parse(Console.ReadLine());

            Claim newClaim = new Claim(newClaimID, newClaimType, newClaimClaimDescription, newClaimClaimFinance, newClaimDateOfAccident, newClaimDateOfClaim, newClaimIsValid);
            _claimRepo.AddClaim(newClaim);

            Console.WriteLine("Claim entered successfully. Press any key to return to menu...");
            Console.ReadKey();
            MainMenu();         
        }
        public void UpdateClaim()
        {
            Console.Clear();
            //Prompt user to enter ID of what they want to update
            Console.WriteLine("Enter the number ID of the claim you want to update: ");
            int userInput = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a case number: ");
            int newClaimID = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter a case type: ");
            string newClaimType = Console.ReadLine();


            Console.WriteLine("Enter a case description: ");
            string newClaimClaimDescription = Console.ReadLine();


            Console.WriteLine("Enter a dollar ammount for the claim: ");
            double newClaimClaimFinance = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date (YYYY,MM,DD) of the incident: ");
            DateTime newClaimDateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date (YYYY,MM,DD) the claim was submitted: ");
            DateTime newClaimDateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is this a valid claim? Type true or false");
            bool newClaimIsValid = bool.Parse(Console.ReadLine());

            Claim newClaim = new Claim(newClaimID, newClaimType, newClaimClaimDescription, newClaimClaimFinance, newClaimDateOfAccident, newClaimDateOfClaim, newClaimIsValid);
            _claimRepo.UpdateExistingClaim(userInput, newClaim);
            Console.WriteLine("Heck yeah! Nice update! Press any key to return to menu...");
            Console.ReadKey();
            MainMenu();
        }

    }
}
