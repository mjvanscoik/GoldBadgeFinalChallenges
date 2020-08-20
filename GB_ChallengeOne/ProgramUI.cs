using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeOne
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private readonly MealsRepository _mealsRepo = new MealsRepository();
        public void Start()
        {
            SeedMenuData();
            Menu();
        }
        public void Menu()
        {
            Console.Clear();

            Console.WriteLine("Welcome to the Komodo Cafe. Below are ways to view and modify meals. Please use the number pad to select your preferred option.");
            Console.WriteLine("1. Display Menu Items.\n" +
                "2. Add new menu item.\n" +
                "3. Delete existing menu item.\n" +
                "4. Exit Program.");

            char userInput = Console.ReadKey().KeyChar;

            switch (userInput)
            {
                case '1':
                    GetMenu();
                    break;
                case '2':
                    AddMenuItem();
                    break;
                case '3':
                    RemoveMenuItem();
                    break;
                case '4':
                _isRunning = false;
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Error. Please try again...");
                    Console.ReadKey();
                    Menu();
                    break;
            }
            while (_isRunning)
            { 
                Console.Clear();
            }
            Console.ReadLine();

        }
        private void GetMenu()
        {

            Console.Clear();
            List<Meal> listOfMeals = _mealsRepo.GetMeals();
            foreach (Meal meal in listOfMeals)
            {
                DisplayItem(meal);
            }

            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            Menu();

        }
        public void DisplayItem(Meal meal)
        {
            Console.WriteLine($"{meal.MealName}\n" +
                $"{meal.MealPrice}\n" +
                $"{meal.MealDescription}\n" +
                $"{string.Join<string>(", ", meal.MealIngrediants)}\n" +
                $"Meal number: {meal.MealNumber}\n" +
                $" ");
            
        }
        public void SeedMenuData()
        {
            var burger = new Meal(1, "Burger and Fries", "A simple burger with fresh-out-the-fryer shoe-string fries", 4.99);
            burger.MealIngrediants.Add("Pickles");
            burger.MealIngrediants.Add("Ketchup");
            burger.MealIngrediants.Add("Cheese");
            burger.MealIngrediants.Add("Fries");

            var hotDog = new Meal(2, "Hot Dog", "A simple classic betwixt some oven-baked buns.", 2.99);
            hotDog.MealIngrediants.Add("Relish");
            hotDog.MealIngrediants.Add("Mustard");

            _mealsRepo.AddMenuItem(burger);
            _mealsRepo.AddMenuItem(hotDog);
        }
        public void AddMenuItem()
        {
            Console.Clear();
            Console.Write("Enter the name of the dish: ");
            string newMealName = Console.ReadLine();

            Console.Write("Enter a description for the dish: ");
            string newMealDescription = Console.ReadLine();

            Console.Write("Enter the PRICE: ");
            double newMealPrice = double.Parse(Console.ReadLine());

            Console.Write("Enter the meal Number: ");
            int newMealNumber = int.Parse(Console.ReadLine());
            Meal newMeal = new Meal(newMealNumber, newMealName, newMealDescription, newMealPrice);
            _mealsRepo.AddMenuItem(newMeal);
            AddToIngredientList(newMeal);
        }

        public void AddToIngredientList(Meal newMeal)//comes from user
        {
            Console.Clear();
            Console.Write("Add one ingredient into the console and press enter, rinse and repeat. When you are finished, please type 'end' and press enter: ");
            string userInput = Console.ReadLine();
            if (userInput == "end")
            { Menu(); }
            else
            {
                Console.Clear();
                newMeal.MealIngrediants.Add(userInput);
                AddToIngredientList(newMeal);
            }
        }
        
        
        //This method gets called when a user wants to remove a menu item. Within this method, we will ask the user what item they would like to delete. Then we will delete that item via a method in our repository
        //The parameter in this method is the Meal we are going to delete
        public void RemoveMenuItem()//remove param
        {//gets menu and displays it for the user
            Console.Clear();
            GetMenuAfterDeletion();
            Console.WriteLine("\nEnter the item number of the meal you want to delete.");
            //receives an ID from the user to choose a meal to delete
            int userInput = Int16.Parse(Console.ReadLine());
            //evaluates whether the user's input is the same ID as the target meal we passed into the the method that we are going to delete
            bool wasDeleted =_mealsRepo.RemoveMenuItem(userInput); //capturing the bool value return.
            if (wasDeleted == true)
            {
                Console.WriteLine("Your menu item was successfully deleted. Press ENTER");
                Console.ReadLine();
                Menu();
            }
            else
            {
                Console.WriteLine("Content could not be deleted. Press ENTER and try again.");
                Console.ReadLine();
                Menu();
            }
                    
        }
        private void GetMenuAfterDeletion()
        {

            Console.Clear();
            List<Meal> listOfMeals = _mealsRepo.GetMeals();
            foreach (Meal meal in listOfMeals)
            {
                DisplayItemAfterDeletion(meal);
            }

           

        }
        public void DisplayItemAfterDeletion(Meal meal)
        {
            Console.WriteLine($"{meal.MealName}\n" +
                $"{meal.MealPrice}\n" +
                $"{meal.MealDescription}\n" +
                $"{string.Join<string>(", ", meal.MealIngrediants)}\n" +
                $"Meal number: {meal.MealNumber}\n" +
                $" ");

        }







    }
}
    






    


       
    


                


            





