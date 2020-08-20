using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeOne
{
    public class MealsRepository
    {
        public readonly List<Meal> _mealRepo = new List<Meal>(); //Creates the meal list and all properties held by the class

        //CREATE READ UPDATE DELETE - CRUD
        public void AddMenuItem(Meal meal) //Create
        {
            _mealRepo.Add(meal);
        }
        

        public List<Meal> GetMeals() //READ
        { 
            return _mealRepo;
        }

        //Update
        public bool UpdateExistingMenuItem(int id, Meal newMeal)
        {
            Meal oldMeal = GetItemByID(id); //Find by ID
            if (oldMeal != null)
            {
                oldMeal.MealName = newMeal.MealName;
                oldMeal.MealDescription = newMeal.MealDescription;
                oldMeal.MealIngrediants = newMeal.MealIngrediants;
                oldMeal.MealNumber = newMeal.MealNumber;
                oldMeal.MealPrice = newMeal.MealPrice;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveMenuItem(int id) //DELETE
        {
            Meal meal = GetItemByID(id);

            if (meal == null)
            {
                return false;
            }

            int initialCount = _mealRepo.Count;
            _mealRepo.Remove(meal);

            if(initialCount > _mealRepo.Count)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }
        
        //Helper Method
        public Meal GetItemByID(int id)
        {
            foreach (Meal meal in _mealRepo)
            {
                if (meal.MealNumber == id)
                {
                    return meal;
                }
            }
                return null;
        }

    }
}
