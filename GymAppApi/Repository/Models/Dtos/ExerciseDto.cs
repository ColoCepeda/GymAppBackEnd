using System;
using Domain.Enums;
using Domain.Entities;

namespace Application.Models.Dtos
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } 

        public string Category { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public Machine? Machine { get; set; }
    }
}
