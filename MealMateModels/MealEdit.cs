using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMateModels
{
    public class MealEdit
    {
        public int RID { get; set; }
        public bool IsStarred { get; set; }
        public string Time { get; set; }
        public string Food { get; set; }
        public int Calories { get; set; }

    }
}
