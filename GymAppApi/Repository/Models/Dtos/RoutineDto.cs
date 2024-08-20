using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums;

namespace Application.Models.Dtos
{
    public class RoutineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Difficulty Difficulty { get; set; }
        public int Duration { get; set; }
        public ICollection<SetExercise> SetExercises { get; set; } = new List<SetExercise>();
    }
}