using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMate.Data
{
    public class Meal
    
    {
        [Key]
        public int RID { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string Food { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
