using MealMateModels;
using MealMateServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MealMateMVC.Controllers.WebAPI
{
    public class MealController : ApiController
    {
        [Authorize]
        [RoutePrefix("api/Note")]
        public class NoteController : ApiController
        {
            private bool SetStarState(int noteId, bool newState)
            {
                // Create the service
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new MealService(userId);

             // Get the note
             var detail = service.GetMealById(noteId);

             // Create the NoteEdit model instance with the new star state
             var updatedNote =
                 new MealEdit
                 {
                     RID = detail.RID,
                     Time = detail.Time,
                     Food = detail.Food,
                     Calories = detail.Calories,
                     IsStarred = newState
                 };

             // Return a value indicating whether the update succeeded
             return service.UpdateMeal(updatedNote);
            }

         [Route("{id}/Star")]
            [HttpPut]
            public bool ToggleStarOn(int id) => SetStarState(id, true);

         [Route("{id}/Star")]
            [HttpDelete]
            public bool ToggleStarOff(int id) => SetStarState(id, false);
        }
    }
}

