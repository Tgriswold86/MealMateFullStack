using MealMateModels;
using MealMateMVC.Models;
using MealMateServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MealMateMVC.Controllers
{
    public class MealController : Controller
    {
        // GET: Meal
        // TODO Authorize
       public ActionResult Index()
       {
        var userId = Guid.Parse(User.Identity.GetUserId());
        var service = new MealService(userId);
        var model = service.GetMeals();

     return View(model);
       }
        //Get Create View
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMealService();

            service.CreateMeal(model);

             return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMealService();
            var detail = service.GetMealById(id);
            var model =
                new MealEdit
                {
                    RID = detail.RID,
                    Time = detail.Time,
                    Food = detail.Food,
                    Calories = detail.Calories
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

         return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMealService();

     if (service.UpdateMeal(model))
            {
                TempData["SaveResult"] = "Your meal was updated.";
                return RedirectToAction("Index");
            }

     ModelState.AddModelError("", "Sorry, something went wrong.");
            return View(model);
        }

        private MealService CreateMealService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);
            return service;
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMealService();

            service.DeleteMeal(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}