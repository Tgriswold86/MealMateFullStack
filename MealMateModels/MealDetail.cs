using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMateModels
{
    public class MealDetail
    {
        public int RID { get; set; }
        public string Time { get; set; }
        public string Food { get; set; }
        public int Calories { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{RID}] {Time}";
    }
}
