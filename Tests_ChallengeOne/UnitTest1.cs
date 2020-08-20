using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using GB_ChallengeOne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_ChallengeOne
{
    [TestClass]
    public class UnitTest1
    {
        // Update Existing Menu Items -- explicitly not needed in challenge.
        
        
        private MealsRepository _repo;
        private Meal _meal;
        private List<Meal> _mealList;

        [TestMethod]
        public void REPO_MenuItemShouldBeAdded()
        {
            ///Arrange -- Setting up the playing field
            _meal = new Meal(3, "Taco" , "Real good. Makes ya full", 4.20);
            _repo = new MealsRepository();



            //Act -- Get or run the code we want to test
            _repo.AddMenuItem(_meal);


            //Assert -- using the Assert class to verify the expected outcome. 
            Assert.IsNotNull(_meal.MealDescription);
        }
        [TestMethod]
        public void GetMealsShouldReturnMeals()
        {
            _repo = new MealsRepository();
            _mealList = new List<Meal>();
            _meal = new Meal(3, "Taco", "Real good. Makes ya full", 4.20);
            _mealList.Add(_meal);
            var chicken = _repo.GetMeals();
            Assert.IsNotNull(chicken);
        }
        [TestMethod]
        public void AddMethodShouldAddMeal() //Also tests get item by ID
        {
            MealsRepository repo = new MealsRepository();
            Meal meal = new Meal(3, "burger", "good", 2.50);
            repo.AddMenuItem(meal);

            repo.GetItemByID(meal.MealNumber); 

            List<Meal> mealList = repo.GetMeals(); //GetMeals returns a list. We are returning the list, and then assigning it a name.

            bool mealListHasMeal = mealList.Contains(meal);// Is it true that meal list now contains meal?

            Assert.IsTrue(mealListHasMeal);
        }
        [TestMethod]
        public void RemoveMenuItemRemovesMenuItem()
        {
            MealsRepository repo = new MealsRepository();
            Meal meal = new Meal(3, "burger", "good", 2.50);
            repo.AddMenuItem(meal);

            var num = meal.MealNumber;
            bool removesResult = repo.RemoveMenuItem(num);

            Assert.IsTrue(removesResult);
        }
    }
}
