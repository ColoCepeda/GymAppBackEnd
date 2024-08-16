using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Application.Models.Dtos
{
    public class RutineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Difficulty Difficulty { get; set; }
        public int Duration { get; set; } 

       
        public List<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
    }
}