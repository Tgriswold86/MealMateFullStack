using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MealMateModels
{
    public class MealListItem
    {

        public int RID { get; set; }
        public string Time { get; set; }
        public string Food { get; set; }
        public int Calories { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [UIHint("Starred")]
        [Display(Name = "Important")]
        public bool IsStarred { get; set; }
        public override string ToString() => Time;
    }
}