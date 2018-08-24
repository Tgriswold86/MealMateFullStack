using MealMateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMateContracts
{
    public interface IMealMateService
    {
        bool CreateMeal(MealCreate model);
        IEnumerable<MealListItem> GetMeals();
        MealDetail GetMealById(int id);
    }
}
