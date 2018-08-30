using MealMateData;
using MealMateContracts;
using MealMateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMateServices
{
    public class MealService : IMealMateService
    {

        private readonly Guid _userId;

        public MealService(Guid userId)
        {
            _userId = userId;
        }
        
        public bool CreateMeal(MealCreate model)
        {
            var entity =
                new Meal()
                {
                    UserId = _userId,
                    Time = model.Time,
                    Food = model.Food,
                    Calories = model.Calories,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Meals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MealListItem> GetMeals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Meals
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new MealListItem
                                {
                                    RID = e.RID,
                                    Time = e.Time,
                                    Food = e.Food,
                                    Calories = e.Calories,
                                    CreatedUtc = e.CreatedUtc,
                                    IsStarred = e.IsStarred,
                                }
                        );

                return query.ToArray();
            }
        }
        public MealDetail GetMealById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meals
                        .Single(e => e.RID == id && e.UserId == _userId);
                return
                    new MealDetail
                    {
                        RID = entity.RID,
                        Time = entity.Time,
                        Food = entity.Food,
                        Calories = entity.Calories,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateMeal(MealEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meals
                        .Single(e => e.RID == model.RID && e.UserId == _userId);

                entity.Time = model.Time;
                entity.Food = model.Food;
                entity.Calories = model.Calories;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.IsStarred = model.IsStarred;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMeal(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meals
                        .Single(e => e.RID == noteId && e.UserId == _userId);

                        ctx.Meals.Remove(entity);

         return ctx.SaveChanges() == 1;
            }
        }
    }
}


