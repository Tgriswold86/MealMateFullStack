using MealMateModels;
using Stripe;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MealMateMVC.Controllers
{
    public class stripeController : Controller
    {


        public ActionResult Charge()
        {
            ViewBag.Message = "Learn how to process payments with Stripe";
            return View(new StripeChargeModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Charge(StripeChargeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var chargeId = await ProcessPayment(model);
            // You should do something with the chargeId --> Persist it maybe?

            return View("Index");
        }

        private static async Task<string> ProcessPayment(StripeChargeModel model)
        {
            return await Task.Run(() =>
            {
                var myCharge = new StripeChargeCreateOptions
                {
                    // convert the amount of £12.50 to pennies i.e. 1250
                    Amount = (int)(model.Amount * 100),
                    Currency = "usd",
                    Description = "Description for test charge",
                    SourceTokenOrExistingSourceId = model.Token
         
                };

                var chargeService = new StripeChargeService();
                var stripeCharge = chargeService.Create(myCharge);

                return stripeCharge.Id;
            });
        }
    }
}
