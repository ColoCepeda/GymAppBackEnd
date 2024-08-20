using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImageUrl { get; set; } 

        public Category Category { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public Machine? Machine { get; set; }

        public ICollection<SetExercise> SetExercises { get; set; } = new List<SetExercise>();
    }
}
