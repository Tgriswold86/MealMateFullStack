using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMateModels
{
    public class MealCreate
    {
        [Required]
        public string Time { get; set; }
        public string Food { get; set; }
        public int Calories { get; set; }
        
        public override string ToString() => Time;
    }
}
