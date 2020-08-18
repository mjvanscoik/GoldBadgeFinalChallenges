using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeOne
{
    public class ProgramUI
    {

        private readonly MealsRepository _mealsRepo = new MealsRepository();
        public void Menu()
        {
            Console.Clear();
            SeedMenuData();

            Console.WriteLine("Welcome to the Komodo Cafe. Below are ways to view and modify meals. Please use the number pad to select your preferred option.");
            Console.WriteLine("1. Display Menu Items.\n" +
                "2. Add new menu item.\n" +
                "3. Delete existing menu item.");

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
                    //Remove Method
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Error. Please try again...");
                    Console.ReadKey();
                    Menu();
                    break;


            }
            Console.WriteLine();

        }
        private void GetMenu()
        {

            Console.Clear();
            List<Meals> listOfMeals = _mealsRepo.GetMeals();
            foreach (Meals meal in listOfMeals)
            {
                DisplayItem(meal);
            }

        }
        public void DisplayItem(Meals meal)
        {
            Console.WriteLine($"{meal.MealName}\n" +
                $"{meal.MealPrice}\n" +
                $"{meal.MealDescription}\n" +
                $"{string.Join<string>(", ", meal.MealIngrediants)}\n" +
                $"Meal number: {meal.MealNumber}");
        }
        public void SeedMenuData()
        {
            var burger = new Meals(1, "Burger and Fries", "A simple burger with fresh-out-the-fryer shoe-string fries", 4.99);
            burger.MealIngrediants.Add("Pickles");
            burger.MealIngrediants.Add("Ketchup");
            burger.MealIngrediants.Add("Cheese");
            burger.MealIngrediants.Add("Fries");

            var hotDog = new Meals(2, "Hot Dog", "A simple classic betwixt some oven-baked buns.", 2.99);
            hotDog.MealIngrediants.Add("Relish");
            hotDog.MealIngrediants.Add("Mustard");

            _mealsRepo.AddMealToRepo(burger);
            _mealsRepo.AddMealToRepo(hotDog);
        }
        public void AddMenuItem()
        {

            Console.Write("Enter the name of the dish: ");
            string newMealName = Console.ReadLine();

            Console.Write("Enter a description for the dish: ");
            string newMealDescription = Console.ReadLine();

            Console.Write("Enter the price: ");
            double newMealPrice = double.Parse(Console.ReadLine());

            Console.Write("Enter the meal number: ");
            int newMealNumber = int.Parse(Console.ReadLine());
            Meals newMeal = new Meals(newMealNumber, newMealName, newMealDescription, newMealPrice);
            _mealsRepo.AddMealToRepo(newMeal);
        }
        public void AddToIngredientList();
        
            {
            Console.Write("List the ingrediants in the dish individually. Do not add commas. When you are finished, please type 'end' and press enter.");
           string userInput = Console.ReadLine();
           if (userInput == "end")
            {Menu();
    }
            else
        
    }
}
    






    


       
    


                


            





