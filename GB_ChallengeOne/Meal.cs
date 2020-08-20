using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeOne
{
    public class Meal
    {
        public Meal(int mealNumber, string mealName, string mealDescription, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            MealIngrediants = new List<string>();
        }
        public int MealNumber
        { get; set; }
        public string MealName
        { get; set; }
        public string MealDescription
        { get; set; }
        public List<string> MealIngrediants
        {get; set; }
        public double MealPrice
        { get; set; }
    }
}
