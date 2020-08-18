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
        [TestMethod]
        public void List_ShouldFillListWithinEachMeal()
        {
            ///Arrange -- Setting up the playing field
            MealsRepository repo = new MealsRepository();
            Meals burger = new Meals(0, "String", "string", 3.5);
            List<Meals> menu = repo.AddMealToRepo();
            public bool burgerHasFries = burger.MealIngrediants.Contains(fries);


            burger.MealIngrediants.Add("Fries");
            repo.AddContentToDirectory(orange); //-will be "content" or "banana" in the class sheet

            repo.GetDirectory();
            //Act -- Get or run the code we want to test
            List<StreamingContent> directory = repo.GetDirectory(); //Does orange exist within the directory?

            bool directoryHasOrange = directory.Contains(orange); //directory, do you have orange?


            //Assert -- using the Assert class to verify the expected outcome. 
            Assert.IsTrue(directoryHasOrange);
        }
    }
}
