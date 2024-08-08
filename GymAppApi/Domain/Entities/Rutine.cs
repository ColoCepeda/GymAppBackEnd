using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Rutine
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public Difficulty Difficulty { get; set; } // Enum property

        public int Duration { get; set; } // Duration in minutes

        public List<Exercise> Exercises { get; set; } // List of exercises

        public Rutine()
        {
            Exercises = new List<Exercise>();
        }




    }
}
