using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeOne
{
    public class MealsRepository
    {
        public readonly List<Meals> _mealRepo = new List<Meals>(); //Creates the meal list and all properties held by the class

        //CREATE READ UPDATE DELETE - CRUD
        public void AddMealToRepo(Meals meal) //CREATE
        {
            _mealRepo.Add(meal);
        }

        public List<Meals> GetMeals() //READ
        { 
            return _mealRepo;
        }

        public List<Meals> AddMealToRepo()
        {
            throw new NotImplementedException();
        }

        public void AddMenuItem(Meals meal) //UPDATE
        {
            _mealRepo.Add(meal);
        }
        public void RemoveMenuItem(Meals meal) //DELETE
        {
            _mealRepo.Remove(meal);
        }
    }
}
